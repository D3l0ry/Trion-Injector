using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.MemoryInteraction;
using System.WinApi;
using System.Windows.Forms;
using System.Xml.Serialization;

using Trion_Injector.InjectionType;

namespace Trion_Injector
{
    public partial class Menu : Form
    {
        #region Private Variables
        private int m_ProcessId;
        private Process[] m_Processes;
        private List<object> Config;
        #endregion

        public Menu()
        {
            InitializeComponent();

            UpdateProcessButton_Click(null, null);

            ProcessList_Click(ProcessList, null);

            Config = new List<object>();

            using (FileStream fileStream = new FileStream("config.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length == 0)
                {
                    return;
                }

                Config.AddRange((object[])new XmlSerializer(typeof(object[])).Deserialize(fileStream));
                DllGridView.Rows.Add(Config.ToArray());

                for (int index = 0; index < DllGridView.Rows.Count; index++)
                {
                    if (!File.Exists((string)DllGridView.Rows[index].Cells["DllPath"].Value))
                    {
                        DllGridView.Rows.RemoveAt(index);

                        continue;
                    }

                    IntPtr hModule = Kernel32.LoadLibrary((string)DllGridView.Rows[index].Cells["DllPath"].Value);

                    DllGridView.Rows[index].Cells["DllFunctions"] = new DataGridViewComboBoxCell
                    {
                        DataSource = InjectHelper.GetExportFunctions(hModule)
                    };

                    Kernel32.FreeLibrary(hModule);
                }
            }
        }

        #region TopPanel
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            NativeMethods.ReleaseCapture();
            NativeMethods.PostMessage(Handle, 0x0112, (IntPtr)0xF012, (IntPtr)0xF008);
        }
        #endregion

        #region Exit Label
        private void ExitLabel_Click(object sender, EventArgs e)
        {
            if (DllGridView.Rows.Count != 0)
            {
                using (FileStream fileStream = new FileStream("config.xml", FileMode.Create, FileAccess.Write))
                {
                    new XmlSerializer(typeof(object[])).Serialize(fileStream, Config.ToArray());
                }
            }

            Environment.Exit(0);
        }

        private void ExitLabel_MouseEnter(object sender, EventArgs e) => ((Label)sender).BackColor = Color.Red;

        private void ExitLabel_MouseLeave(object sender, EventArgs e) => ((Label)sender).BackColor = Color.Transparent;
        #endregion

        #region Minimize Label
        private void MinimizeLable_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void MinimizeLable_MouseEnter(object sender, EventArgs e) => ((Label)sender).BackColor = Color.Gray;

        private void MinimizeLable_MouseLeave(object sender, EventArgs e) => ((Label)sender).BackColor = Color.Transparent;
        #endregion

        #region Process List
        private void ProcessList_Click(object sender, EventArgs e) => m_ProcessId = (int)((ListBox)sender).SelectedValue;

        private void ProcessList_SelectedIndexChanged(object sender, EventArgs e) => m_ProcessId = (int)((ListBox)sender).SelectedValue;

        private void UpdateProcessButton_Click(object sender, EventArgs e) => ProcessList.DataSource = m_Processes = Process.GetProcesses();

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
        #endregion

        #region Dll List
        private void DllAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    IntPtr hModule = Kernel32.LoadLibrary(openFileDialog.FileName);

                    object[] newDll = { true, openFileDialog.SafeFileName, openFileDialog.FileName };

                    Config.AddRange(newDll);
                    DllGridView.Rows.Add(newDll);
                    DllGridView.Rows[DllGridView.Rows.Count - 1].Cells["DllFunctions"] = new DataGridViewComboBoxCell
                    {
                        DataSource = InjectHelper.GetExportFunctions(hModule)
                    };

                    Kernel32.FreeLibrary(hModule);
                }
            }
            catch (Exception Ex)
            {
                if (MessageBox.Show(Ex.Message + "\nПерезапустить приложение?", "Trion Injector - Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        private void DllClearButton_Click(object sender, EventArgs e)
        {
            Config.Clear();
            DllGridView.Rows.Clear();

            File.Delete("config.xml");
        }
        #endregion

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

                        InjectInformationLabel.Text = $"{(string)dllRow.Cells[1].Value} - {injector.Injecting((string)dllRow.Cells[1].Value, (string)dllRow.Cells[2].Value, (string)dllRow.Cells[3].Value, process, memoryManager)}";
                    }
                }
            }
            catch (Exception EX)
            {
                InjectInformationLabel.Text = EX.Message;
            }
        }
    }
}