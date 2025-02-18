namespace WorkTimeTracker
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxSettingsView = new System.Windows.Forms.GroupBox();
            this.checkBoxShowFormAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.checkBoxShowExportPdfFeature = new System.Windows.Forms.CheckBox();
            this.checkBoxShowExportExcelFeature = new System.Windows.Forms.CheckBox();
            this.checkBoxShowTimestamps12hFormat = new System.Windows.Forms.CheckBox();
            this.checkBoxShowTimestampsWithoutSeconds = new System.Windows.Forms.CheckBox();
            this.groupBoxSettingsSaveLocation = new System.Windows.Forms.GroupBox();
            this.buttonChangeSaveLocation = new System.Windows.Forms.Button();
            this.textBoxSaveLocationLogFile = new System.Windows.Forms.TextBox();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.checkBoxShowFormMinimalistic = new System.Windows.Forms.CheckBox();
            this.trackBarFormTransparency = new System.Windows.Forms.TrackBar();
            this.labelTransparency = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSettingsView.SuspendLayout();
            this.groupBoxSettingsSaveLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFormTransparency)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSettingsView
            // 
            this.groupBoxSettingsView.Controls.Add(this.label1);
            this.groupBoxSettingsView.Controls.Add(this.labelTransparency);
            this.groupBoxSettingsView.Controls.Add(this.trackBarFormTransparency);
            this.groupBoxSettingsView.Controls.Add(this.checkBoxShowFormMinimalistic);
            this.groupBoxSettingsView.Controls.Add(this.checkBoxShowFormAlwaysOnTop);
            this.groupBoxSettingsView.Controls.Add(this.checkBoxShowExportPdfFeature);
            this.groupBoxSettingsView.Controls.Add(this.checkBoxShowExportExcelFeature);
            this.groupBoxSettingsView.Controls.Add(this.checkBoxShowTimestamps12hFormat);
            this.groupBoxSettingsView.Controls.Add(this.checkBoxShowTimestampsWithoutSeconds);
            this.groupBoxSettingsView.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSettingsView.Name = "groupBoxSettingsView";
            this.groupBoxSettingsView.Size = new System.Drawing.Size(309, 343);
            this.groupBoxSettingsView.TabIndex = 0;
            this.groupBoxSettingsView.TabStop = false;
            this.groupBoxSettingsView.Text = "Darstellung";
            // 
            // checkBoxShowFormAlwaysOnTop
            // 
            this.checkBoxShowFormAlwaysOnTop.AutoSize = true;
            this.checkBoxShowFormAlwaysOnTop.Location = new System.Drawing.Point(7, 116);
            this.checkBoxShowFormAlwaysOnTop.Name = "checkBoxShowFormAlwaysOnTop";
            this.checkBoxShowFormAlwaysOnTop.Size = new System.Drawing.Size(128, 17);
            this.checkBoxShowFormAlwaysOnTop.TabIndex = 4;
            this.checkBoxShowFormAlwaysOnTop.Text = "Immer im Vordergrund";
            this.checkBoxShowFormAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowExportPdfFeature
            // 
            this.checkBoxShowExportPdfFeature.AutoSize = true;
            this.checkBoxShowExportPdfFeature.Location = new System.Drawing.Point(7, 92);
            this.checkBoxShowExportPdfFeature.Name = "checkBoxShowExportPdfFeature";
            this.checkBoxShowExportPdfFeature.Size = new System.Drawing.Size(134, 17);
            this.checkBoxShowExportPdfFeature.TabIndex = 3;
            this.checkBoxShowExportPdfFeature.Text = "Zeige \"Export zu PDF\"";
            this.checkBoxShowExportPdfFeature.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowExportExcelFeature
            // 
            this.checkBoxShowExportExcelFeature.AutoSize = true;
            this.checkBoxShowExportExcelFeature.Location = new System.Drawing.Point(7, 68);
            this.checkBoxShowExportExcelFeature.Name = "checkBoxShowExportExcelFeature";
            this.checkBoxShowExportExcelFeature.Size = new System.Drawing.Size(139, 17);
            this.checkBoxShowExportExcelFeature.TabIndex = 2;
            this.checkBoxShowExportExcelFeature.Text = "Zeige \"Export zu Excel\"";
            this.checkBoxShowExportExcelFeature.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowTimestamps12hFormat
            // 
            this.checkBoxShowTimestamps12hFormat.AutoSize = true;
            this.checkBoxShowTimestamps12hFormat.Location = new System.Drawing.Point(7, 44);
            this.checkBoxShowTimestamps12hFormat.Name = "checkBoxShowTimestamps12hFormat";
            this.checkBoxShowTimestamps12hFormat.Size = new System.Drawing.Size(162, 17);
            this.checkBoxShowTimestamps12hFormat.TabIndex = 1;
            this.checkBoxShowTimestamps12hFormat.Text = "12 Stunden Format (AM/PM)";
            this.checkBoxShowTimestamps12hFormat.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowTimestampsWithoutSeconds
            // 
            this.checkBoxShowTimestampsWithoutSeconds.AutoSize = true;
            this.checkBoxShowTimestampsWithoutSeconds.Location = new System.Drawing.Point(7, 20);
            this.checkBoxShowTimestampsWithoutSeconds.Name = "checkBoxShowTimestampsWithoutSeconds";
            this.checkBoxShowTimestampsWithoutSeconds.Size = new System.Drawing.Size(123, 17);
            this.checkBoxShowTimestampsWithoutSeconds.TabIndex = 0;
            this.checkBoxShowTimestampsWithoutSeconds.Text = "Zeit ohne Sekunden";
            this.checkBoxShowTimestampsWithoutSeconds.UseVisualStyleBackColor = true;
            // 
            // groupBoxSettingsSaveLocation
            // 
            this.groupBoxSettingsSaveLocation.Controls.Add(this.buttonChangeSaveLocation);
            this.groupBoxSettingsSaveLocation.Controls.Add(this.textBoxSaveLocationLogFile);
            this.groupBoxSettingsSaveLocation.Location = new System.Drawing.Point(410, 12);
            this.groupBoxSettingsSaveLocation.Name = "groupBoxSettingsSaveLocation";
            this.groupBoxSettingsSaveLocation.Size = new System.Drawing.Size(294, 100);
            this.groupBoxSettingsSaveLocation.TabIndex = 1;
            this.groupBoxSettingsSaveLocation.TabStop = false;
            this.groupBoxSettingsSaveLocation.Text = "Speicherort";
            // 
            // buttonChangeSaveLocation
            // 
            this.buttonChangeSaveLocation.Location = new System.Drawing.Point(7, 47);
            this.buttonChangeSaveLocation.Name = "buttonChangeSaveLocation";
            this.buttonChangeSaveLocation.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeSaveLocation.TabIndex = 1;
            this.buttonChangeSaveLocation.Text = "Ändern";
            this.buttonChangeSaveLocation.UseVisualStyleBackColor = true;
            // 
            // textBoxSaveLocationLogFile
            // 
            this.textBoxSaveLocationLogFile.Location = new System.Drawing.Point(7, 20);
            this.textBoxSaveLocationLogFile.Name = "textBoxSaveLocationLogFile";
            this.textBoxSaveLocationLogFile.Size = new System.Drawing.Size(472, 20);
            this.textBoxSaveLocationLogFile.TabIndex = 0;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(713, 415);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveSettings.TabIndex = 2;
            this.buttonSaveSettings.Text = "Speichern";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // checkBoxShowFormMinimalistic
            // 
            this.checkBoxShowFormMinimalistic.AutoSize = true;
            this.checkBoxShowFormMinimalistic.Location = new System.Drawing.Point(7, 140);
            this.checkBoxShowFormMinimalistic.Name = "checkBoxShowFormMinimalistic";
            this.checkBoxShowFormMinimalistic.Size = new System.Drawing.Size(123, 17);
            this.checkBoxShowFormMinimalistic.TabIndex = 5;
            this.checkBoxShowFormMinimalistic.Text = "Minimale Darstellung";
            this.checkBoxShowFormMinimalistic.UseVisualStyleBackColor = true;
            // 
            // trackBarFormTransparency
            // 
            this.trackBarFormTransparency.Location = new System.Drawing.Point(78, 245);
            this.trackBarFormTransparency.Maximum = 100;
            this.trackBarFormTransparency.Minimum = 10;
            this.trackBarFormTransparency.Name = "trackBarFormTransparency";
            this.trackBarFormTransparency.Size = new System.Drawing.Size(174, 45);
            this.trackBarFormTransparency.TabIndex = 6;
            this.trackBarFormTransparency.Value = 10;
            this.trackBarFormTransparency.Scroll += new System.EventHandler(this.trackBarFormTransparency_Scroll);
            // 
            // labelTransparency
            // 
            this.labelTransparency.AutoSize = true;
            this.labelTransparency.Location = new System.Drawing.Point(75, 229);
            this.labelTransparency.Name = "labelTransparency";
            this.labelTransparency.Size = new System.Drawing.Size(74, 13);
            this.labelTransparency.TabIndex = 7;
            this.labelTransparency.Text = "Loading value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Transparenz";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.groupBoxSettingsSaveLocation);
            this.Controls.Add(this.groupBoxSettingsView);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBoxSettingsView.ResumeLayout(false);
            this.groupBoxSettingsView.PerformLayout();
            this.groupBoxSettingsSaveLocation.ResumeLayout(false);
            this.groupBoxSettingsSaveLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFormTransparency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettingsView;
        private System.Windows.Forms.CheckBox checkBoxShowExportExcelFeature;
        private System.Windows.Forms.CheckBox checkBoxShowTimestamps12hFormat;
        private System.Windows.Forms.CheckBox checkBoxShowTimestampsWithoutSeconds;
        private System.Windows.Forms.GroupBox groupBoxSettingsSaveLocation;
        private System.Windows.Forms.Button buttonChangeSaveLocation;
        private System.Windows.Forms.TextBox textBoxSaveLocationLogFile;
        private System.Windows.Forms.CheckBox checkBoxShowFormAlwaysOnTop;
        private System.Windows.Forms.CheckBox checkBoxShowExportPdfFeature;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.CheckBox checkBoxShowFormMinimalistic;
        private System.Windows.Forms.TrackBar trackBarFormTransparency;
        private System.Windows.Forms.Label labelTransparency;
        private System.Windows.Forms.Label label1;
    }
}