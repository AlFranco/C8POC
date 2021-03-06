﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoreSettingsForm.cs" company="AlFranco">
//   Albert Rodriguez Franco 2013
// </copyright>
// <summary>
//   The core settings form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace C8POC.WinFormsUI.Forms
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The core settings form.
    /// </summary>
    public partial class CoreSettingsForm : Form
    {
        /// <summary>
        /// Gets a value indicating whether is disassembler enabled.
        /// </summary>
        public bool IsDisassemblerEnabled
        {
            get
            {
                return this.checkBoxDisassembler.Checked;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreSettingsForm"/> class. 
        /// </summary>
        public CoreSettingsForm()
        {
            this.InitializeComponent();

            this.numericUpDownCyclesPerFrame.Value = C8POC.Core.Properties.Settings.Default.CyclesPerFrame;
            this.numericUpDownFramesPerSecond.Value = C8POC.Core.Properties.Settings.Default.FramesPerSecond;
            this.checkBoxDisassembler.Checked = C8POC.Core.Properties.Settings.Default.DisassemblerEnabled;
        }

        /// <summary>
        /// Confirms the changes
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonOkClick(object sender, EventArgs e)
        {
            C8POC.Core.Properties.Settings.Default.CyclesPerFrame = long.Parse(this.numericUpDownCyclesPerFrame.Text);
            C8POC.Core.Properties.Settings.Default.FramesPerSecond = long.Parse(this.numericUpDownFramesPerSecond.Text);
            C8POC.Core.Properties.Settings.Default.DisassemblerEnabled = this.checkBoxDisassembler.Checked;

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
