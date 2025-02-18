using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorkTimeTracker
{
    public partial class SettingsForm : Form
    {
        private MainForm _mainForm;

        public SettingsForm(MainForm mainForm)
        {
            _mainForm = mainForm;

            InitializeComponent();

            LoadSettingsOnFormLoad();

            trackBarFormTransparency.Scroll += trackBarFormTransparency_Scroll;
            trackBarFormTransparency.Minimum = 50;
            trackBarFormTransparency.Maximum = 100;
            _mainForm.Opacity = trackBarFormTransparency.Value / 100.0;
            
            labelTransparency.Text = trackBarFormTransparency.Value.ToString() + "%";   
        }

        // Empty constructor for beauty reasons
        public SettingsForm()
        {
            MessageBox.Show("Perfect! You found an unexpected way in my code. But that's a dead end this time!");
        }

        private void LoadSettingsOnFormLoad()
        {
            checkBoxShowTimestampsWithoutSeconds.Checked = SettingsData.GetInstance().ShowTimestampsWithoutSeconds;
            checkBoxShowTimestamps12hFormat.Checked = SettingsData.GetInstance().ShowTimestamps12hFormat;
            checkBoxShowExportExcelFeature.Checked = SettingsData.GetInstance().ShowExportExcelFeature;
            checkBoxShowExportPdfFeature.Checked = SettingsData.GetInstance().ShowExportPdfFeature;
            checkBoxShowFormAlwaysOnTop.Checked = SettingsData.GetInstance().ShowFormAlwaysOnTop;
            checkBoxShowFormMinimalistic.Checked = SettingsData.GetInstance().ShowFormMinimalistic;
            trackBarFormTransparency.Value = SettingsData.GetInstance().FormTransparency;
        }

        public void saveSettings()
        {
            SettingsData.GetInstance().ShowTimestampsWithoutSeconds = checkBoxShowTimestampsWithoutSeconds.Checked;
            SettingsData.GetInstance().ShowTimestamps12hFormat = checkBoxShowTimestamps12hFormat.Checked;
            SettingsData.GetInstance().ShowExportExcelFeature = checkBoxShowExportExcelFeature.Checked;
            SettingsData.GetInstance().ShowExportPdfFeature = checkBoxShowExportPdfFeature.Checked;
            SettingsData.GetInstance().ShowFormAlwaysOnTop = checkBoxShowFormAlwaysOnTop.Checked;
            SettingsData.GetInstance().ShowFormMinimalistic = checkBoxShowFormMinimalistic.Checked;
            SettingsData.GetInstance().FormTransparency = trackBarFormTransparency.Value;

            // Schreibe File mit den Einstellungen
            SettingsData.GetInstance().SaveSettings();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            SettingsData.LoadSettings();

            trackBarFormTransparency.Value = SettingsData.GetInstance().FormTransparency;

            // Label über der Trackbar positionieren
            int thumbX = (int)((trackBarFormTransparency.Width - 30) *
                        (trackBarFormTransparency.Value - trackBarFormTransparency.Minimum) /
                        (float)(trackBarFormTransparency.Maximum - trackBarFormTransparency.Minimum)) + 15;

            labelTransparency.Location = new Point(trackBarFormTransparency.Left + thumbX - labelTransparency.Width / 2,
                                                   trackBarFormTransparency.Top - 20);
        }


        private void trackBarFormTransparency_Scroll(object sender, EventArgs e)
        {
            labelTransparency.Text = trackBarFormTransparency.Value.ToString() + "%";

            // Label über der Trackbar positionieren
            int thumbX = (int)((trackBarFormTransparency.Width - 30) *
                        (trackBarFormTransparency.Value - trackBarFormTransparency.Minimum) /
                        (float)(trackBarFormTransparency.Maximum - trackBarFormTransparency.Minimum)) + 15;

            labelTransparency.Location = new Point(trackBarFormTransparency.Left + thumbX - labelTransparency.Width / 2,
                                                   trackBarFormTransparency.Top - 20);

            // FOR TESTING
            //this.Opacity = trackBarFormTransparency.Value / 100.0;
            _mainForm.Opacity = trackBarFormTransparency.Value / 100.0;
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            saveSettings();
        }
    }
}
