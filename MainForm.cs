using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Timers;
using System.Drawing;
using System.Security.Principal;

namespace WorkTimeTracker
{
    public partial class MainForm : Form
    {
        private const string LogFilePath = "arbeitszeit_log.txt";
        private TimeSpan arbeitsSoll = TimeSpan.FromHours(8); // Parametrierbar
        private Label lblArbeitszeit;
        private System.Windows.Forms.Timer updateTimer;
        private DateTime? lastLoginTime = null; // Speichert die Zeit des letzten Logins
        private TimeSpan totalWorkingTime = TimeSpan.Zero; // Gesamtarbeitszeit, einschließlich der aktiven Zeit des Programms
        private DateTime programStartTime; // Speichert den Zeitpunkt, an dem das Programm gestartet wurde
        private bool isDragging = false;
        private Point dragStartPoint;

        public MainForm()
        {
            InitializeComponent();
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            InitializeUI();
            InitializeTimer();
            programStartTime = DateTime.Now; // Zeit des Programmstarts
            BerechneInitialArbeitszeit(); // Berechnet die initiale Arbeitszeit basierend auf Log-Einträgen
            AktualisiereAnzeige();
            GetLogOffLogInEventsOnLoad();
        }

        private void InitializeUI()
        {
            this.Text = "Work Time Tracker";
            this.Size = new System.Drawing.Size(400, 200);

            lblArbeitszeit = new Label
            {
                Text = "Arbeitszeit wird berechnet...",
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 50)
            };
            this.Controls.Add(lblArbeitszeit);


            this.Opacity = SettingsData.GetInstance().FormTransparency / 100.0;
            if (this.Opacity < 0.5)
            {
                this.Opacity = 0.5;
            }

            this.TopMost = SettingsData.GetInstance().ShowFormAlwaysOnTop;

            SetFormMinimalistic(SettingsData.GetInstance().ShowFormMinimalistic);

        }

        private void InitializeTimer()
        {
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 1000; // 1 Sekunde
            updateTimer.Tick += (sender, e) => AktualisiereAnzeige();
            updateTimer.Start();
        }


        private void SetFormMinimalistic(bool isMinimalistic)
        {
            if (isMinimalistic)
            {
                // Setzt das Form auf eine minimalistische Ansicht
                this.FormBorderStyle = FormBorderStyle.None;    // Kein Rahmen, kein Titel
                this.ControlBox = false;                        // Entfernt Schaltflächen für Minimieren, Maximieren und Schließen
                this.MaximizeBox = false;                       // Deaktiviert den Maximieren-Button
                this.MinimizeBox = false;                       // Deaktiviert den Minimieren-Button
                this.StartPosition = FormStartPosition.CenterScreen; // Setzt das Form in die Mitte des Bildschirms
                this.TopMost = true;                            // Optional: Lässt die Form immer im Vordergrund bleiben
            }
            else
            {
                // Setzt die Form zurück auf Standardansicht
                this.FormBorderStyle = FormBorderStyle.Sizable; // Standardrahmen
                this.ControlBox = true;                         // Schaltflächen aktivieren
                this.MaximizeBox = true;                        // Maximieren-Button aktivieren
                this.MinimizeBox = true;                        // Minimieren-Button aktivieren
            }
        }


        public void GetLogOffLogInEventsOnLoad()
        {

            string logType = "Security";
            string logonEventId = "4624"; // Logon Event ID
            string logoffEventId = "4634"; // Logoff Event ID

            // Get the current user's SID
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            string currentUserSid = currentUser.User.Value;

            EventLog eventLog = new EventLog(logType);

            foreach (EventLogEntry entry in eventLog.Entries)
            {
                if (entry.ReplacementStrings != null && entry.ReplacementStrings.Length > 0 && entry.ReplacementStrings[0] != null)
                {
                    Console.WriteLine($"MycurrentUserSid: {entry.ReplacementStrings[0]}");
                }


                if ((entry.InstanceId.ToString() == logonEventId || entry.InstanceId.ToString() == logoffEventId) &&
                    entry.ReplacementStrings[0] == currentUserSid) // Check if the SID matches
                {
                    if (entry.TimeGenerated > DateTime.Now.AddHours(-6))
                    {
                        Console.WriteLineMe($"Event ID: {entry.InstanceId}");
                        Console.WriteLine($"Time Generated: {entry.TimeGenerated}");
                        
                        //Console.WriteLine($"Message: {entry.Message}");
                        //Console.WriteLine(new string('-', 50));
                    }

                }
            }

        }


        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLogon ||
                e.Reason == SessionSwitchReason.SessionUnlock)
            {
                // Speichere den Zeitpunkt des letzten Logins
                File.AppendAllText(LogFilePath, "Login: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                lastLoginTime = DateTime.Now; // Speichern der Login-Zeit
            }
            else if (e.Reason == SessionSwitchReason.SessionLogoff ||
                     e.Reason == SessionSwitchReason.SessionLock)
            {
                // Berechne und speichere den Logoff-Zeitpunkt
                File.AppendAllText(LogFilePath, "Logoff: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
                if (lastLoginTime.HasValue)
                {
                    totalWorkingTime += DateTime.Now - lastLoginTime.Value; // Berechne die Zeit zwischen Logon und Logoff
                    lastLoginTime = null; // Setze die letzte Login-Zeit zurück
                }
            }
            AktualisiereAnzeige();
        }

        private void AktualisiereAnzeige()
        {
            SetFormMinimalistic(SettingsData.GetInstance().ShowFormMinimalistic);
            TimeSpan arbeitszeit = BerechneArbeitszeit();
            TimeSpan verbleibendeZeit = arbeitsSoll - arbeitszeit;

            lblArbeitszeit.Text = $"Gearbeitet: {arbeitszeit:h\\:mm\\:ss}\nVerbleibend: {verbleibendeZeit:h\\:mm\\:ss}";
        }

        private void BerechneInitialArbeitszeit()
        {
            if (!File.Exists(LogFilePath)) return;

            var eintraege = File.ReadAllLines(LogFilePath)
                .Where(line => line.StartsWith("Login: "))
                .Select(line => DateTime.TryParseExact(line.Substring(7), "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime date) ? date : (DateTime?)null)
                .Where(date => date.HasValue)
                .Select(date => date.Value)
                .OrderBy(date => date)
                .ToList();

            // Berechne die Arbeitszeit basierend auf den Log-Entries
            if (eintraege.Count % 2 != 0)
            {
                // Falls die Anzahl ungerade ist, entferne den letzten (unvollständigen) Eintrag
                eintraege.RemoveAt(eintraege.Count - 1);
            }

            for (int i = 0; i < eintraege.Count; i += 2)
            {
                totalWorkingTime += eintraege[i + 1] - eintraege[i];
            }

            // Wenn der letzte Logeintrag ein Login ist und kein Logoff existiert, berechne die Zeit bis jetzt
            if (eintraege.Count > 0 && eintraege.Count % 2 != 0)
            {
                lastLoginTime = eintraege.Last(); // Das letzte Login
                totalWorkingTime += DateTime.Now - lastLoginTime.Value; // Zeit seit dem letzten Login
            }
        }

        private TimeSpan BerechneArbeitszeit()
        {
            // Zunächst die Arbeitszeit seit dem Start des Programms berechnen
            TimeSpan arbeitszeit = totalWorkingTime;

            // Wenn das Programm geöffnet ist und noch kein Logoff stattgefunden hat, dann zählt die Zeit
            if (lastLoginTime.HasValue)
            {
                arbeitszeit += DateTime.Now - lastLoginTime.Value; // Zeit seit dem letzten Login hinzuzufügen
            }
            else
            {
                // Falls kein Login aktuell aktiv ist, berechne die Zeit, die seit Programmstart vergangen ist
                arbeitszeit += DateTime.Now - programStartTime;
            }

            return arbeitszeit;
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Die Settings müssen im Vordergrund sein. Wird nacher wieder zurück gesetzt
            this.TopMost = false;

            // Neues Einstellungsformular erstellen und anzeigen
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.ShowDialog(); // ShowDialog() öffnet die Form als modales Fenster

            // Dieses Fenster wieder Always On Top setzen falls in den Settings so konfiguriert
            this.TopMost = SettingsData.GetInstance().ShowFormAlwaysOnTop;
        }

        private void überToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Über die Anwendung öffnen");
        }

        // Start der Bewegung (wenn Maus gedrückt wird)
        private void SettingsForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = e.Location;  // Speichert die Position der Maus, wo das Form geklickt wurde
            }
        }

        // Bewegungsereignis, wenn die Maus bewegt wird
        private void SettingsForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Verschiebt die Form, basierend auf der Bewegung des Mauszeigers
                this.Location = new Point(this.Location.X + (e.X - dragStartPoint.X), this.Location.Y + (e.Y - dragStartPoint.Y));
            }
        }

        // Stop der Bewegung (wenn Maus losgelassen wird)
        private void SettingsForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }

}
