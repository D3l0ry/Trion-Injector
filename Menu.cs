using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.MemoryInteraction;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Trion_Injector.InjectionType;

namespace Trion_Injector
{
    public partial class Menu : Form
    {
        #region Private Variables
        private int m_ProcessId;
        private Process[] m_Processes;
        #endregion

        public Menu()
        {
            InitializeComponent();

            UpdateProcessButton_Click(null, null);

            ProcessList_Click(ProcessList, null);
        }

        #region TopPanel
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            NativeMethods.ReleaseCapture();
            NativeMethods.PostMessage(Handle, 0x0112, (IntPtr)0xF012, (IntPtr)0xF008);
        }
        #endregion

        #region Exit Label
        private void ExitLabel_Click(object sender, EventArgs e) => Environment.Exit(0);

        private void ExitLabel_MouseEnter(object sender, EventArgs e) => ((Label)sender).BackColor = Color.Red;

        private void ExitLabel_MouseLeave(object sender, EventArgs e) => ((Label)sender).BackColor = Color.Transparent;
        #endregion

        #region Minimize Label
        private void MinimizeLable_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void MinimizeLable_MouseEnter(object sender, EventArgs e) => ((Label)sender).BackColor = Color.Gray;

        private void MinimizeLable_MouseLeave(object sender, EventArgs e) => ((Label)sender).BackColor = Color.Transparent;
        #endregion

        private void ProcessList_Click(object sender, EventArgs e) => m_ProcessId = (int)((ListBox)sender).SelectedValue;

        private void UpdateProcessButton_Click(object sender, EventArgs e) => ProcessList.DataSource = m_Processes = Process.GetProcesses();

        private void DllAddButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "dll files (*.dll)|*.dll";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DllGridView.Rows.Add(new object[] { true, openFileDialog.SafeFileName, openFileDialog.FileName });
            }
        }

        private void DllClearButton_Click(object sender, EventArgs e) => DllGridView.Rows.Clear();

        private void InjectButton_Click(object sender, EventArgs e)
        {
            Process process = null;

            try
            {
                process = Process.GetProcessById(m_ProcessId);

                IInjector injector = new LDR();

                using (MemoryManager memoryManager = process.GetMemoryManager())
                {
                    foreach (DataGridViewRow dllRow in DllGridView.Rows)
                    {
                        if (!(bool)dllRow.Cells[0].Value)
                        {
                            continue;
                        }

                        InjectInformationLabel.Text = $"{dllRow.Cells[1].Value} - {injector.Injecting((string)dllRow.Cells[1].Value, (string)dllRow.Cells[2].Value, "DllMain", process, memoryManager)}";
                    }
                }
            }
            catch
            {
                InjectInformationLabel.Text = "Process not found";
            }
        }

        private void ProcessSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string processSearch = (sender as TextBox).Text;

            if (string.IsNullOrWhiteSpace(processSearch))
            {
                UpdateProcessButton_Click(null, null);

                return;
            }

            ProcessList.DataSource = m_Processes.Where(X => X.ProcessName.Contains(processSearch)).ToList();
        }
    }
}