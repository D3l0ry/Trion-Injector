namespace Trion_Injector
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.MinimizeLable = new System.Windows.Forms.Label();
            this.ExitLabel = new System.Windows.Forms.Label();
            this.LogoLabel = new System.Windows.Forms.Label();
            this.ProcessList = new System.Windows.Forms.ListBox();
            this.processBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProcessBox = new System.Windows.Forms.GroupBox();
            this.InjectionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.LoadLibraryInectionRadioButton = new System.Windows.Forms.RadioButton();
            this.InjectButton = new System.Windows.Forms.Button();
            this.DllListGroupBox = new System.Windows.Forms.GroupBox();
            this.DllGridView = new System.Windows.Forms.DataGridView();
            this.DllEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DllName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DllPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DllClearButton = new System.Windows.Forms.Button();
            this.DllAddButton = new System.Windows.Forms.Button();
            this.UpdateProcessButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.InjectInformationLabel = new System.Windows.Forms.Label();
            this.ProcessSearchTextBox = new System.Windows.Forms.TextBox();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processBindingSource)).BeginInit();
            this.ProcessBox.SuspendLayout();
            this.InjectionSettingsGroupBox.SuspendLayout();
            this.DllListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DllGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopPanel.Controls.Add(this.MinimizeLable);
            this.TopPanel.Controls.Add(this.ExitLabel);
            this.TopPanel.Controls.Add(this.LogoLabel);
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 35);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            // 
            // MinimizeLable
            // 
            this.MinimizeLable.AutoSize = true;
            this.MinimizeLable.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeLable.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimizeLable.ForeColor = System.Drawing.Color.White;
            this.MinimizeLable.Location = new System.Drawing.Point(750, 6);
            this.MinimizeLable.Name = "MinimizeLable";
            this.MinimizeLable.Size = new System.Drawing.Size(17, 23);
            this.MinimizeLable.TabIndex = 2;
            this.MinimizeLable.Text = "-";
            this.MinimizeLable.Click += new System.EventHandler(this.MinimizeLable_Click);
            this.MinimizeLable.MouseEnter += new System.EventHandler(this.MinimizeLable_MouseEnter);
            this.MinimizeLable.MouseLeave += new System.EventHandler(this.MinimizeLable_MouseLeave);
            // 
            // ExitLabel
            // 
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.BackColor = System.Drawing.Color.Transparent;
            this.ExitLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitLabel.ForeColor = System.Drawing.Color.White;
            this.ExitLabel.Location = new System.Drawing.Point(776, 6);
            this.ExitLabel.Name = "ExitLabel";
            this.ExitLabel.Size = new System.Drawing.Size(21, 23);
            this.ExitLabel.TabIndex = 1;
            this.ExitLabel.Text = "X";
            this.ExitLabel.Click += new System.EventHandler(this.ExitLabel_Click);
            this.ExitLabel.MouseEnter += new System.EventHandler(this.ExitLabel_MouseEnter);
            this.ExitLabel.MouseLeave += new System.EventHandler(this.ExitLabel_MouseLeave);
            // 
            // LogoLabel
            // 
            this.LogoLabel.AutoSize = true;
            this.LogoLabel.BackColor = System.Drawing.Color.Transparent;
            this.LogoLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogoLabel.ForeColor = System.Drawing.Color.White;
            this.LogoLabel.Location = new System.Drawing.Point(338, 6);
            this.LogoLabel.Name = "LogoLabel";
            this.LogoLabel.Size = new System.Drawing.Size(124, 23);
            this.LogoLabel.TabIndex = 0;
            this.LogoLabel.Text = "Trion Injector";
            // 
            // ProcessList
            // 
            this.ProcessList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.ProcessList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProcessList.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.processBindingSource, "Id", true));
            this.ProcessList.DataSource = this.processBindingSource;
            this.ProcessList.DisplayMember = "ProcessName";
            this.ProcessList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessList.ForeColor = System.Drawing.Color.White;
            this.ProcessList.FormattingEnabled = true;
            this.ProcessList.Location = new System.Drawing.Point(3, 17);
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(234, 248);
            this.ProcessList.TabIndex = 1;
            this.ProcessList.ValueMember = "Id";
            this.ProcessList.Click += new System.EventHandler(this.ProcessList_Click);
            // 
            // processBindingSource
            // 
            this.processBindingSource.DataSource = typeof(System.Diagnostics.Process);
            // 
            // ProcessBox
            // 
            this.ProcessBox.Controls.Add(this.ProcessList);
            this.ProcessBox.ForeColor = System.Drawing.Color.White;
            this.ProcessBox.Location = new System.Drawing.Point(12, 41);
            this.ProcessBox.Name = "ProcessBox";
            this.ProcessBox.Size = new System.Drawing.Size(240, 268);
            this.ProcessBox.TabIndex = 2;
            this.ProcessBox.TabStop = false;
            this.ProcessBox.Text = "Process List";
            // 
            // InjectionSettingsGroupBox
            // 
            this.InjectionSettingsGroupBox.Controls.Add(this.LoadLibraryInectionRadioButton);
            this.InjectionSettingsGroupBox.ForeColor = System.Drawing.Color.White;
            this.InjectionSettingsGroupBox.Location = new System.Drawing.Point(258, 209);
            this.InjectionSettingsGroupBox.Name = "InjectionSettingsGroupBox";
            this.InjectionSettingsGroupBox.Size = new System.Drawing.Size(530, 100);
            this.InjectionSettingsGroupBox.TabIndex = 3;
            this.InjectionSettingsGroupBox.TabStop = false;
            this.InjectionSettingsGroupBox.Text = "Injection Settings";
            // 
            // LoadLibraryInectionRadioButton
            // 
            this.LoadLibraryInectionRadioButton.AutoSize = true;
            this.LoadLibraryInectionRadioButton.Checked = true;
            this.LoadLibraryInectionRadioButton.Location = new System.Drawing.Point(6, 20);
            this.LoadLibraryInectionRadioButton.Name = "LoadLibraryInectionRadioButton";
            this.LoadLibraryInectionRadioButton.Size = new System.Drawing.Size(81, 17);
            this.LoadLibraryInectionRadioButton.TabIndex = 0;
            this.LoadLibraryInectionRadioButton.TabStop = true;
            this.LoadLibraryInectionRadioButton.Text = "LoadLibrary";
            this.LoadLibraryInectionRadioButton.UseVisualStyleBackColor = true;
            // 
            // InjectButton
            // 
            this.InjectButton.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.InjectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.InjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InjectButton.ForeColor = System.Drawing.Color.White;
            this.InjectButton.Location = new System.Drawing.Point(713, 315);
            this.InjectButton.Name = "InjectButton";
            this.InjectButton.Size = new System.Drawing.Size(75, 23);
            this.InjectButton.TabIndex = 4;
            this.InjectButton.Text = "Inject";
            this.InjectButton.UseVisualStyleBackColor = true;
            this.InjectButton.Click += new System.EventHandler(this.InjectButton_Click);
            // 
            // DllListGroupBox
            // 
            this.DllListGroupBox.Controls.Add(this.DllGridView);
            this.DllListGroupBox.Controls.Add(this.DllClearButton);
            this.DllListGroupBox.Controls.Add(this.DllAddButton);
            this.DllListGroupBox.ForeColor = System.Drawing.Color.White;
            this.DllListGroupBox.Location = new System.Drawing.Point(258, 41);
            this.DllListGroupBox.Name = "DllListGroupBox";
            this.DllListGroupBox.Size = new System.Drawing.Size(530, 162);
            this.DllListGroupBox.TabIndex = 5;
            this.DllListGroupBox.TabStop = false;
            this.DllListGroupBox.Text = "DLL List";
            // 
            // DllGridView
            // 
            this.DllGridView.AllowUserToAddRows = false;
            this.DllGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DllGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.DllGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DllGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DllGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DllEnable,
            this.DllName,
            this.DllPath});
            this.DllGridView.GridColor = System.Drawing.Color.White;
            this.DllGridView.Location = new System.Drawing.Point(87, 17);
            this.DllGridView.Name = "DllGridView";
            this.DllGridView.Size = new System.Drawing.Size(437, 139);
            this.DllGridView.TabIndex = 8;
            // 
            // DllEnable
            // 
            this.DllEnable.HeaderText = "Enable";
            this.DllEnable.Name = "DllEnable";
            this.DllEnable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DllName
            // 
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.DllName.DefaultCellStyle = dataGridViewCellStyle13;
            this.DllName.HeaderText = "DLL Name";
            this.DllName.Name = "DllName";
            this.DllName.ReadOnly = true;
            this.DllName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DllPath
            // 
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            this.DllPath.DefaultCellStyle = dataGridViewCellStyle14;
            this.DllPath.HeaderText = "DLL Path";
            this.DllPath.Name = "DllPath";
            this.DllPath.ReadOnly = true;
            this.DllPath.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DllPath.Width = 196;
            // 
            // DllClearButton
            // 
            this.DllClearButton.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.DllClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DllClearButton.ForeColor = System.Drawing.Color.White;
            this.DllClearButton.Location = new System.Drawing.Point(6, 49);
            this.DllClearButton.Name = "DllClearButton";
            this.DllClearButton.Size = new System.Drawing.Size(75, 23);
            this.DllClearButton.TabIndex = 7;
            this.DllClearButton.Text = "Clear";
            this.DllClearButton.UseVisualStyleBackColor = true;
            this.DllClearButton.Click += new System.EventHandler(this.DllClearButton_Click);
            // 
            // DllAddButton
            // 
            this.DllAddButton.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.DllAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DllAddButton.ForeColor = System.Drawing.Color.White;
            this.DllAddButton.Location = new System.Drawing.Point(6, 20);
            this.DllAddButton.Name = "DllAddButton";
            this.DllAddButton.Size = new System.Drawing.Size(75, 23);
            this.DllAddButton.TabIndex = 5;
            this.DllAddButton.Text = "Add";
            this.DllAddButton.UseVisualStyleBackColor = true;
            this.DllAddButton.Click += new System.EventHandler(this.DllAddButton_Click);
            // 
            // UpdateProcessButton
            // 
            this.UpdateProcessButton.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.UpdateProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateProcessButton.ForeColor = System.Drawing.Color.White;
            this.UpdateProcessButton.Location = new System.Drawing.Point(12, 315);
            this.UpdateProcessButton.Name = "UpdateProcessButton";
            this.UpdateProcessButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateProcessButton.TabIndex = 6;
            this.UpdateProcessButton.Text = "Update";
            this.UpdateProcessButton.UseVisualStyleBackColor = true;
            this.UpdateProcessButton.Click += new System.EventHandler(this.UpdateProcessButton_Click);
            // 
            // InjectInformationLabel
            // 
            this.InjectInformationLabel.AutoSize = true;
            this.InjectInformationLabel.BackColor = System.Drawing.Color.Transparent;
            this.InjectInformationLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InjectInformationLabel.ForeColor = System.Drawing.Color.White;
            this.InjectInformationLabel.Location = new System.Drawing.Point(338, 315);
            this.InjectInformationLabel.Name = "InjectInformationLabel";
            this.InjectInformationLabel.Size = new System.Drawing.Size(162, 23);
            this.InjectInformationLabel.TabIndex = 7;
            this.InjectInformationLabel.Text = "Inject Information";
            // 
            // ProcessSearchTextBox
            // 
            this.ProcessSearchTextBox.Location = new System.Drawing.Point(93, 316);
            this.ProcessSearchTextBox.Name = "ProcessSearchTextBox";
            this.ProcessSearchTextBox.Size = new System.Drawing.Size(159, 21);
            this.ProcessSearchTextBox.TabIndex = 1;
            this.ProcessSearchTextBox.TextChanged += new System.EventHandler(this.ProcessSearchTextBox_TextChanged);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.ProcessSearchTextBox);
            this.Controls.Add(this.InjectInformationLabel);
            this.Controls.Add(this.UpdateProcessButton);
            this.Controls.Add(this.DllListGroupBox);
            this.Controls.Add(this.InjectButton);
            this.Controls.Add(this.InjectionSettingsGroupBox);
            this.Controls.Add(this.ProcessBox);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.Text = "Trion Injector";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processBindingSource)).EndInit();
            this.ProcessBox.ResumeLayout(false);
            this.InjectionSettingsGroupBox.ResumeLayout(false);
            this.InjectionSettingsGroupBox.PerformLayout();
            this.DllListGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DllGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label LogoLabel;
        private System.Windows.Forms.Label MinimizeLable;
        private System.Windows.Forms.Label ExitLabel;
        private System.Windows.Forms.ListBox ProcessList;
        private System.Windows.Forms.GroupBox ProcessBox;
        private System.Windows.Forms.BindingSource processBindingSource;
        private System.Windows.Forms.GroupBox InjectionSettingsGroupBox;
        private System.Windows.Forms.Button InjectButton;
        private System.Windows.Forms.GroupBox DllListGroupBox;
        private System.Windows.Forms.DataGridView DllGridView;
        private System.Windows.Forms.Button DllClearButton;
        private System.Windows.Forms.Button DllAddButton;
        private System.Windows.Forms.Button UpdateProcessButton;
        private System.Windows.Forms.RadioButton LoadLibraryInectionRadioButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DllEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn DllName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DllPath;
        private System.Windows.Forms.Label InjectInformationLabel;
        private System.Windows.Forms.TextBox ProcessSearchTextBox;
    }
}

