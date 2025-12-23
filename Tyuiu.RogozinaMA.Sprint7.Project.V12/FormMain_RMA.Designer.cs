namespace Tyuiu.RogozinaMA.Sprint7.Project.V12
{
    partial class FormMain_RMA
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewComputers_RMA = new DataGridView();
            panelTop = new Panel();
            buttonLoad_RMA = new Button();
            buttonStats_RMA = new Button();
            buttonAbout_RMA = new Button();
            buttonExit_RMA = new Button();
            panelSearch = new Panel();
            labelSearch = new Label();
            textBoxSearch_RMA = new TextBox();
            buttonSearch_RMA = new Button();
            buttonClearSearch_RMA = new Button();
            panelSortFilter = new Panel();
            groupBoxSort = new GroupBox();
            radioButtonDesc_RMA = new RadioButton();
            radioButtonAsc_RMA = new RadioButton();
            comboBoxSortBy_RMA = new ComboBox();
            buttonSort_RMA = new Button();
            groupBoxFilter = new GroupBox();
            labelMinRAM = new Label();
            numericUpDownMinRAM_RMA = new NumericUpDown();
            labelMaxRAM = new Label();
            numericUpDownMaxRAM_RMA = new NumericUpDown();
            labelMinHDD = new Label();
            numericUpDownMinHDD_RMA = new NumericUpDown();
            labelMaxHDD = new Label();
            numericUpDownMaxHDD_RMA = new NumericUpDown();
            buttonFilter_RMA = new Button();
            buttonClearFilter_RMA = new Button();
            statusStrip = new StatusStrip();
            toolStripStatusLabelMessage = new ToolStripStatusLabel();
            panelTop.SuspendLayout();
            panelSearch.SuspendLayout();
            panelSortFilter.SuspendLayout();
            groupBoxSort.SuspendLayout();
            groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinRAM_RMA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxRAM_RMA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinHDD_RMA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxHDD_RMA).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();

            // dataGridViewComputers_RMA
            dataGridViewComputers_RMA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewComputers_RMA.Dock = DockStyle.Fill;
            dataGridViewComputers_RMA.Location = new Point(0, 200);
            dataGridViewComputers_RMA.Name = "dataGridViewComputers_RMA";
            dataGridViewComputers_RMA.Size = new Size(900, 400);
            dataGridViewComputers_RMA.TabIndex = 0;

            // panelTop
            panelTop.Controls.Add(buttonLoad_RMA);
            panelTop.Controls.Add(buttonStats_RMA);
            panelTop.Controls.Add(buttonAbout_RMA);
            panelTop.Controls.Add(buttonExit_RMA);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(900, 50);
            panelTop.TabIndex = 1;

            // buttonLoad_RMA
            buttonLoad_RMA.Location = new Point(10, 10);
            buttonLoad_RMA.Name = "buttonLoad_RMA";
            buttonLoad_RMA.Size = new Size(120, 30);
            buttonLoad_RMA.Text = "📂 Загрузить";
            buttonLoad_RMA.Click += buttonLoad_RMA_Click;

            // buttonStats_RMA
            buttonStats_RMA.Location = new Point(140, 10);
            buttonStats_RMA.Name = "buttonStats_RMA";
            buttonStats_RMA.Size = new Size(120, 30);
            buttonStats_RMA.Text = "📊 Статистика";
            buttonStats_RMA.Click += buttonStats_RMA_Click;

            // buttonAbout_RMA
            buttonAbout_RMA.Location = new Point(270, 10);
            buttonAbout_RMA.Name = "buttonAbout_RMA";
            buttonAbout_RMA.Size = new Size(120, 30);
            buttonAbout_RMA.Text = "🌸 О программе";
            buttonAbout_RMA.Click += buttonAbout_RMA_Click;

            // buttonExit_RMA
            buttonExit_RMA.Location = new Point(400, 10);
            buttonExit_RMA.Name = "buttonExit_RMA";
            buttonExit_RMA.Size = new Size(120, 30);
            buttonExit_RMA.Text = "🚪 Выход";
            buttonExit_RMA.Click += buttonExit_RMA_Click;

            // panelSearch
            panelSearch.Controls.Add(buttonClearSearch_RMA);
            panelSearch.Controls.Add(buttonSearch_RMA);
            panelSearch.Controls.Add(textBoxSearch_RMA);
            panelSearch.Controls.Add(labelSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 50);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(900, 50);
            panelSearch.TabIndex = 2;

            // labelSearch
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(10, 17);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(100, 15);
            labelSearch.Text = "Поиск:";

            // textBoxSearch_RMA
            textBoxSearch_RMA.Location = new Point(60, 14);
            textBoxSearch_RMA.Name = "textBoxSearch_RMA";
            textBoxSearch_RMA.Size = new Size(200, 23);
            textBoxSearch_RMA.TabIndex = 0;

            // buttonSearch_RMA
            buttonSearch_RMA.Location = new Point(270, 13);
            buttonSearch_RMA.Name = "buttonSearch_RMA";
            buttonSearch_RMA.Size = new Size(80, 25);
            buttonSearch_RMA.Text = "🔍 Найти";
            buttonSearch_RMA.Click += buttonSearch_RMA_Click;

            // buttonClearSearch_RMA
            buttonClearSearch_RMA.Location = new Point(360, 13);
            buttonClearSearch_RMA.Name = "buttonClearSearch_RMA";
            buttonClearSearch_RMA.Size = new Size(80, 25);
            buttonClearSearch_RMA.Text = "🧹 Очистить";
            buttonClearSearch_RMA.Click += buttonClearSearch_RMA_Click;

            // panelSortFilter
            panelSortFilter.Controls.Add(groupBoxFilter);
            panelSortFilter.Controls.Add(groupBoxSort);
            panelSortFilter.Dock = DockStyle.Top;
            panelSortFilter.Location = new Point(0, 100);
            panelSortFilter.Name = "panelSortFilter";
            panelSortFilter.Size = new Size(900, 100);
            panelSortFilter.TabIndex = 3;

            // groupBoxSort
            groupBoxSort.Controls.Add(buttonSort_RMA);
            groupBoxSort.Controls.Add(comboBoxSortBy_RMA);
            groupBoxSort.Controls.Add(radioButtonAsc_RMA);
            groupBoxSort.Controls.Add(radioButtonDesc_RMA);
            groupBoxSort.Location = new Point(10, 10);
            groupBoxSort.Name = "groupBoxSort";
            groupBoxSort.Size = new Size(400, 80);
            groupBoxSort.TabIndex = 0;
            groupBoxSort.TabStop = false;
            groupBoxSort.Text = "Сортировка 🔼";

            // radioButtonDesc_RMA
            radioButtonDesc_RMA.AutoSize = true;
            radioButtonDesc_RMA.Location = new Point(200, 25);
            radioButtonDesc_RMA.Name = "radioButtonDesc_RMA";
            radioButtonDesc_RMA.Size = new Size(80, 19);
            radioButtonDesc_RMA.Text = "Убывание";

            // radioButtonAsc_RMA
            radioButtonAsc_RMA.AutoSize = true;
            radioButtonAsc_RMA.Checked = true;
            radioButtonAsc_RMA.Location = new Point(100, 25);
            radioButtonAsc_RMA.Name = "radioButtonAsc_RMA";
            radioButtonAsc_RMA.Size = new Size(94, 19);
            radioButtonAsc_RMA.TabStop = true;
            radioButtonAsc_RMA.Text = "Возрастание";

            // comboBoxSortBy_RMA
            comboBoxSortBy_RMA.FormattingEnabled = true;
            comboBoxSortBy_RMA.Items.AddRange(new object[] { "Производитель", "ОЗУ", "HDD", "Частота" });
            comboBoxSortBy_RMA.Location = new Point(10, 50);
            comboBoxSortBy_RMA.Name = "comboBoxSortBy_RMA";
            comboBoxSortBy_RMA.Size = new Size(150, 23);
            comboBoxSortBy_RMA.TabIndex = 2;

            // buttonSort_RMA
            buttonSort_RMA.Location = new Point(300, 45);
            buttonSort_RMA.Name = "buttonSort_RMA";
            buttonSort_RMA.Size = new Size(90, 25);
            buttonSort_RMA.Text = "Сортировать";
            buttonSort_RMA.Click += buttonSort_RMA_Click;

            // groupBoxFilter
            groupBoxFilter.Controls.Add(buttonClearFilter_RMA);
            groupBoxFilter.Controls.Add(buttonFilter_RMA);
            groupBoxFilter.Controls.Add(numericUpDownMaxHDD_RMA);
            groupBoxFilter.Controls.Add(labelMaxHDD);
            groupBoxFilter.Controls.Add(numericUpDownMinHDD_RMA);
            groupBoxFilter.Controls.Add(labelMinHDD);
            groupBoxFilter.Controls.Add(numericUpDownMaxRAM_RMA);
            groupBoxFilter.Controls.Add(labelMaxRAM);
            groupBoxFilter.Controls.Add(numericUpDownMinRAM_RMA);
            groupBoxFilter.Controls.Add(labelMinRAM);
            groupBoxFilter.Location = new Point(420, 10);
            groupBoxFilter.Name = "groupBoxFilter";
            groupBoxFilter.Size = new Size(470, 80);
            groupBoxFilter.TabIndex = 1;
            groupBoxFilter.TabStop = false;
            groupBoxFilter.Text = "Фильтрация 🎯";

            // labelMinRAM
            labelMinRAM.AutoSize = true;
            labelMinRAM.Location = new Point(10, 25);
            labelMinRAM.Name = "labelMinRAM";
            labelMinRAM.Size = new Size(60, 15);
            labelMinRAM.Text = "ОЗУ от:";

            // numericUpDownMinRAM_RMA
            numericUpDownMinRAM_RMA.Location = new Point(70, 23);
            numericUpDownMinRAM_RMA.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            numericUpDownMinRAM_RMA.Name = "numericUpDownMinRAM_RMA";
            numericUpDownMinRAM_RMA.Size = new Size(60, 23);
            numericUpDownMinRAM_RMA.TabIndex = 1;

            // labelMaxRAM
            labelMaxRAM.AutoSize = true;
            labelMaxRAM.Location = new Point(140, 25);
            labelMaxRAM.Name = "labelMaxRAM";
            labelMaxRAM.Size = new Size(25, 15);
            labelMaxRAM.Text = "до:";

            // numericUpDownMaxRAM_RMA
            numericUpDownMaxRAM_RMA.Location = new Point(170, 23);
            numericUpDownMaxRAM_RMA.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            numericUpDownMaxRAM_RMA.Value = new decimal(new int[] { 64, 0, 0, 0 });
            numericUpDownMaxRAM_RMA.Name = "numericUpDownMaxRAM_RMA";
            numericUpDownMaxRAM_RMA.Size = new Size(60, 23);
            numericUpDownMaxRAM_RMA.TabIndex = 3;

            // labelMinHDD
            labelMinHDD.AutoSize = true;
            labelMinHDD.Location = new Point(240, 25);
            labelMinHDD.Name = "labelMinHDD";
            labelMinHDD.Size = new Size(60, 15);
            labelMinHDD.Text = "HDD от:";

            // numericUpDownMinHDD_RMA
            numericUpDownMinHDD_RMA.Location = new Point(300, 23);
            numericUpDownMinHDD_RMA.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownMinHDD_RMA.Name = "numericUpDownMinHDD_RMA";
            numericUpDownMinHDD_RMA.Size = new Size(70, 23);
            numericUpDownMinHDD_RMA.TabIndex = 5;

            // labelMaxHDD
            labelMaxHDD.AutoSize = true;
            labelMaxHDD.Location = new Point(10, 55);
            labelMaxHDD.Name = "labelMaxHDD";
            labelMaxHDD.Size = new Size(25, 15);
            labelMaxHDD.Text = "до:";

            // numericUpDownMaxHDD_RMA
            numericUpDownMaxHDD_RMA.Location = new Point(170, 53);
            numericUpDownMaxHDD_RMA.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownMaxHDD_RMA.Value = new decimal(new int[] { 4000, 0, 0, 0 });
            numericUpDownMaxHDD_RMA.Name = "numericUpDownMaxHDD_RMA";
            numericUpDownMaxHDD_RMA.Size = new Size(70, 23);
            numericUpDownMaxHDD_RMA.TabIndex = 7;

            // buttonFilter_RMA
            buttonFilter_RMA.Location = new Point(380, 23);
            buttonFilter_RMA.Name = "buttonFilter_RMA";
            buttonFilter_RMA.Size = new Size(80, 25);
            buttonFilter_RMA.Text = "Применить";
            buttonFilter_RMA.Click += buttonFilter_RMA_Click;

            // buttonClearFilter_RMA
            buttonClearFilter_RMA.Location = new Point(380, 53);
            buttonClearFilter_RMA.Name = "buttonClearFilter_RMA";
            buttonClearFilter_RMA.Size = new Size(80, 25);
            buttonClearFilter_RMA.Text = "Сбросить";
            buttonClearFilter_RMA.Click += buttonClearFilter_RMA_Click;

            // statusStrip
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelMessage });
            statusStrip.Location = new Point(0, 600);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(900, 22);
            statusStrip.TabIndex = 4;

            // toolStripStatusLabelMessage
            toolStripStatusLabelMessage.Name = "toolStripStatusLabelMessage";
            toolStripStatusLabelMessage.Size = new Size(885, 17);
            toolStripStatusLabelMessage.Spring = true;
            toolStripStatusLabelMessage.Text = "Готово к работе!";
            toolStripStatusLabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // FormMain_RMA
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 622);
            Controls.Add(dataGridViewComputers_RMA);
            Controls.Add(panelSortFilter);
            Controls.Add(panelSearch);
            Controls.Add(panelTop);
            Controls.Add(statusStrip);
            Name = "FormMain_RMA";
            Text = "💖 Компьютерный каталог";
            panelTop.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelSortFilter.ResumeLayout(false);
            groupBoxSort.ResumeLayout(false);
            groupBoxSort.PerformLayout();
            groupBoxFilter.ResumeLayout(false);
            groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinRAM_RMA).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxRAM_RMA).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinHDD_RMA).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxHDD_RMA).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dataGridViewComputers_RMA;
        private Panel panelTop;
        private Button buttonLoad_RMA;
        private Button buttonStats_RMA;
        private Button buttonAbout_RMA;
        private Button buttonExit_RMA;
        private Panel panelSearch;
        private Button buttonClearSearch_RMA;
        private Button buttonSearch_RMA;
        private TextBox textBoxSearch_RMA;
        private Label labelSearch;
        private Panel panelSortFilter;
        private GroupBox groupBoxSort;
        private Button buttonSort_RMA;
        private ComboBox comboBoxSortBy_RMA;
        private RadioButton radioButtonAsc_RMA;
        private RadioButton radioButtonDesc_RMA;
        private GroupBox groupBoxFilter;
        private Button buttonClearFilter_RMA;
        private Button buttonFilter_RMA;
        private NumericUpDown numericUpDownMaxHDD_RMA;
        private Label labelMaxHDD;
        private NumericUpDown numericUpDownMinHDD_RMA;
        private Label labelMinHDD;
        private NumericUpDown numericUpDownMaxRAM_RMA;
        private Label labelMaxRAM;
        private NumericUpDown numericUpDownMinRAM_RMA;
        private Label labelMinRAM;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabelMessage;
    }
}