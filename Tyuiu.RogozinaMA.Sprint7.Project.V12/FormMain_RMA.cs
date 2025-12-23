using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tyuiu.RogozinaMA.Sprint7.Project.V12.Lib;

namespace Tyuiu.RogozinaMA.Sprint7.Project.V12
{
    public partial class FormMain_RMA : Form
    {
        private DataService dataService = new DataService();
        private List<DataService.Computer> computers = new List<DataService.Computer>();
        private List<DataService.Computer> originalComputers = new List<DataService.Computer>();

        public FormMain_RMA()
        {
            InitializeComponent();
            CreateDataGridViewColumns(); // СОЗДАЕМ КОЛОНКИ СРАЗУ!
            InitForm();
        }

        // ГАРАНТИРОВАННО СОЗДАЕМ КОЛОНКИ ПРИ ЗАПУСКЕ
        private void CreateDataGridViewColumns()
        {
            // Очищаем, если что-то было
            dataGridViewComputers_RMA.Columns.Clear();
            
            // Создаем колонки
            dataGridViewComputers_RMA.Columns.Add("Manufacturer", "Производитель 🏢");
            dataGridViewComputers_RMA.Columns.Add("Processor", "Процессор ⚡");
            dataGridViewComputers_RMA.Columns.Add("Frequency", "Частота 🌟");
            dataGridViewComputers_RMA.Columns.Add("RAM", "ОЗУ 💾");
            dataGridViewComputers_RMA.Columns.Add("HDD", "HDD 💿");
            dataGridViewComputers_RMA.Columns.Add("Date", "Дата 📅");
            
            // Настройка ширины
            dataGridViewComputers_RMA.Columns[0].Width = 120;
            dataGridViewComputers_RMA.Columns[1].Width = 140;
            dataGridViewComputers_RMA.Columns[2].Width = 90;
            dataGridViewComputers_RMA.Columns[3].Width = 70;
            dataGridViewComputers_RMA.Columns[4].Width = 80;
            dataGridViewComputers_RMA.Columns[5].Width = 100;
            
            // Стиль
            dataGridViewComputers_RMA.RowHeadersVisible = false;
            dataGridViewComputers_RMA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewComputers_RMA.DefaultCellStyle.SelectionBackColor = Color.Lavender;
        }

        private void InitForm()
        {
            this.Text = "💻 Каталог компьютеров";
            this.BackColor = Color.FromArgb(255, 240, 245);
            
            SetupMenu();
            
            comboBoxSortBy_RMA.Items.AddRange(new string[] { "Производитель", "ОЗУ", "HDD", "Частота" });
            comboBoxSortBy_RMA.SelectedIndex = 0;
            
            toolStripStatusLabelMessage.Text = "Готово! Нажмите 'Загрузить'";
        }

        private void SetupMenu()
        {
            MenuStrip menu = new MenuStrip();
            menu.BackColor = Color.LavenderBlush;
            menu.Font = new Font("Segoe UI", 10F);
            
            var fileMenu = new ToolStripMenuItem("📁 Файл");
            fileMenu.DropDownItems.Add(new ToolStripMenuItem("📊 График", null, ShowChart));
            fileMenu.DropDownItems.Add(new ToolStripMenuItem("💾 Экспорт", null, ExportClick));
            fileMenu.DropDownItems.Add(new ToolStripMenuItem("🗑️ Очистить", null, ClearClick));
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(new ToolStripMenuItem("🚪 Выход", null, buttonExit_RMA_Click));
            
            var editMenu = new ToolStripMenuItem("✏️ Редактирование");
            editMenu.DropDownItems.Add(new ToolStripMenuItem("➕ Добавить", null, AddClick));
            editMenu.DropDownItems.Add(new ToolStripMenuItem("✏️ Редактировать", null, EditClick));
            editMenu.DropDownItems.Add(new ToolStripMenuItem("🗑️ Удалить", null, DeleteClick));
            
            var helpMenu = new ToolStripMenuItem("❓ Справка");
            helpMenu.DropDownItems.Add(new ToolStripMenuItem("📚 Руководство", null, ManualClick));
            helpMenu.DropDownItems.Add(new ToolStripMenuItem("🌸 О программе", null, buttonAbout_RMA_Click));
            
            menu.Items.Add(fileMenu);
            menu.Items.Add(editMenu);
            menu.Items.Add(helpMenu);
            
            this.Controls.Add(menu);
            this.MainMenuStrip = menu;
        }

        // =========== ОСНОВНЫЕ КНОПКИ ===========
        private void buttonLoad_RMA_Click(object sender, EventArgs e)
        {
            computers = dataService.GetTestComputers();
            originalComputers = new List<DataService.Computer>(computers);
            ShowData(computers);
            MessageBox.Show($"Загружено {computers.Count} компьютеров! 💖", "Успех");
        }

        // ГЛАВНЫЙ МЕТОД - ПОКАЗАТЬ ДАННЫЕ В ТАБЛИЦЕ
        private void ShowData(List<DataService.Computer> list)
        {
            // ПРОВЕРЯЕМ, ЕСТЬ ЛИ КОЛОНКИ
            if (dataGridViewComputers_RMA.Columns.Count == 0)
            {
                MessageBox.Show("Колонки не созданы! Создаем...", "Внимание");
                CreateDataGridViewColumns(); // СОЗДАЕМ КОЛОНКИ, ЕСЛИ ИХ НЕТ
            }
            
            dataGridViewComputers_RMA.Rows.Clear(); // Очищаем старые строки
            
            foreach (var comp in list)
            {
                // ТЕПЕРЬ МОЖНО ДОБАВЛЯТЬ - КОЛОНКИ ЕСТЬ!
                dataGridViewComputers_RMA.Rows.Add(
                    comp.Manufacturer,
                    comp.ProcessorType,
                    $"{comp.ClockSpeed:F1} GHz",
                    $"{comp.RAM} GB",
                    $"{comp.HDD} GB",
                    comp.ReleaseDate.ToString("dd.MM.yyyy")
                );
            }
        }

        // =========== ОСТАЛЬНЫЕ МЕТОДЫ (не меняем) ===========
        private void buttonStats_RMA_Click(object sender, EventArgs e)
        {
            if (computers.Count == 0)
            {
                MessageBox.Show("Сначала загрузите данные!", "Внимание");
                return;
            }

            int totalRAM = 0, totalHDD = 0;
            int minRAM = int.MaxValue, maxRAM = 0;

            foreach (var comp in computers)
            {
                totalRAM += comp.RAM;
                totalHDD += comp.HDD;
                if (comp.RAM < minRAM) minRAM = comp.RAM;
                if (comp.RAM > maxRAM) maxRAM = comp.RAM;
            }

            string stats = $"📊 СТАТИСТИКА:\n\n" +
                          $"💻 Всего: {computers.Count} компьютеров\n" +
                          $"💾 Среднее ОЗУ: {(double)totalRAM / computers.Count:F1} GB\n" +
                          $"📈 Минимальное ОЗУ: {minRAM} GB\n" +
                          $"📉 Максимальное ОЗУ: {maxRAM} GB\n" +
                          $"✨ Всего ОЗУ: {totalRAM} GB\n" +
                          $"💕 Сделано с любовью для учебы!";

            MessageBox.Show(stats, "Статистика");
        }

        private void buttonSearch_RMA_Click(object? sender, EventArgs e)
        {
            string text = textBoxSearch_RMA?.Text?.ToLower() ?? "";
            
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Введите текст для поиска!", "Внимание");
                return;
            }

            if (originalComputers.Count == 0)
            {
                MessageBox.Show("Сначала загрузите данные!", "Внимание");
                return;
            }

            var results = new List<DataService.Computer>();
            foreach (var comp in originalComputers)
            {
                if (comp.Manufacturer.ToLower().Contains(text) || 
                    comp.ProcessorType.ToLower().Contains(text))
                {
                    results.Add(comp);
                }
            }

            ShowData(results);
            toolStripStatusLabelMessage.Text = results.Count > 0 
                ? $"Найдено {results.Count}" 
                : "Ничего не найдено";
        }

        private void buttonClearSearch_RMA_Click(object sender, EventArgs e)
        {
            textBoxSearch_RMA.Clear();
            if (originalComputers.Count > 0) ShowData(originalComputers);
        }

        private void buttonSort_RMA_Click(object sender, EventArgs e)
        {
            if (computers.Count == 0) return;
            
            string sortBy = comboBoxSortBy_RMA.SelectedItem?.ToString() ?? "Производитель";
            bool asc = radioButtonAsc_RMA.Checked;

            switch (sortBy)
            {
                case "Производитель":
                    computers.Sort((a, b) => asc ? a.Manufacturer.CompareTo(b.Manufacturer) : b.Manufacturer.CompareTo(a.Manufacturer));
                    break;
                case "ОЗУ":
                    computers.Sort((a, b) => asc ? a.RAM.CompareTo(b.RAM) : b.RAM.CompareTo(a.RAM));
                    break;
                case "HDD":
                    computers.Sort((a, b) => asc ? a.HDD.CompareTo(b.HDD) : b.HDD.CompareTo(a.HDD));
                    break;
                case "Частота":
                    computers.Sort((a, b) => asc ? a.ClockSpeed.CompareTo(b.ClockSpeed) : b.ClockSpeed.CompareTo(a.ClockSpeed));
                    break;
            }

            ShowData(computers);
        }

        private void buttonFilter_RMA_Click(object sender, EventArgs e)
        {
            if (originalComputers.Count == 0) return;
            
            int minRAM = (int)numericUpDownMinRAM_RMA.Value;
            int maxRAM = (int)numericUpDownMaxRAM_RMA.Value;
            int minHDD = (int)numericUpDownMinHDD_RMA.Value;
            int maxHDD = (int)numericUpDownMaxHDD_RMA.Value;

            var filtered = new List<DataService.Computer>();
            foreach (var comp in originalComputers)
            {
                if (comp.RAM >= minRAM && comp.RAM <= maxRAM &&
                    comp.HDD >= minHDD && comp.HDD <= maxHDD)
                {
                    filtered.Add(comp);
                }
            }

            ShowData(filtered);
        }

        private void buttonClearFilter_RMA_Click(object sender, EventArgs e)
        {
            numericUpDownMinRAM_RMA.Value = 0;
            numericUpDownMaxRAM_RMA.Value = 64;
            numericUpDownMinHDD_RMA.Value = 0;
            numericUpDownMaxHDD_RMA.Value = 4000;
            
            if (originalComputers.Count > 0) ShowData(originalComputers);
        }

        private void buttonAbout_RMA_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "💖 КОМПЬЮТЕРНЫЙ КАТАЛОГ 💖\n\n" +
                "Версия: 1.0.0 🌸\n" +
                "Автор: Милана Рогозина 👩‍💻\n" +
                "Группа: ИСПб-25-1 🎓\n" +
                $"Дата: {DateTime.Now:dd.MM.yyyy} 📅\n\n" +
                "Программа для учета компьютеров\n" +
                "💕 Сделано с любовью для учебы!",
                "О программе");
        }

        private void buttonExit_RMA_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Точно хотите выйти? 💕", "Выход", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // =========== ФУНКЦИИ МЕНЮ ===========
        private void AddClick(object? sender, EventArgs e)
        {
            var form = new FormEditComputer_RMA();
            if (form.ShowDialog() == DialogResult.OK && form.Computer != null)
            {
                computers.Add(form.Computer);
                originalComputers.Add(form.Computer);
                ShowData(computers);
                toolStripStatusLabelMessage.Text = "✅ Компьютер добавлен!";
            }
        }

        private void EditClick(object? sender, EventArgs e)
        {
            if (dataGridViewComputers_RMA.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите компьютер для редактирования!", "Внимание");
                return;
            }
            
            int idx = dataGridViewComputers_RMA.SelectedRows[0].Index;
            if (idx >= 0 && idx < computers.Count)
            {
                var form = new FormEditComputer_RMA(computers[idx]);
                if (form.ShowDialog() == DialogResult.OK && form.Computer != null)
                {
                    computers[idx] = form.Computer;
                    ShowData(computers);
                    toolStripStatusLabelMessage.Text = "✅ Компьютер отредактирован!";
                }
            }
        }

        private void DeleteClick(object? sender, EventArgs e)
        {
            if (dataGridViewComputers_RMA.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите компьютер для удаления!", "Внимание");
                return;
            }
            
            int idx = dataGridViewComputers_RMA.SelectedRows[0].Index;
            if (idx >= 0 && idx < computers.Count)
            {
                if (MessageBox.Show("Удалить компьютер? 💕", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    computers.RemoveAt(idx);
                    originalComputers.RemoveAt(idx);
                    ShowData(computers);
                    toolStripStatusLabelMessage.Text = "🗑️ Компьютер удален!";
                }
            }
        }

        private void ShowChart(object? sender, EventArgs e)
        {
            if (computers.Count == 0)
            {
                MessageBox.Show("Сначала загрузите данные! 📂", "Внимание");
                return;
            }
            new FormChart_RMA(computers).ShowDialog();
        }

        private void ExportClick(object? sender, EventArgs e)
        {
            if (computers.Count == 0) return;
            
            var dialog = new SaveFileDialog();
            dialog.Filter = "Текстовые файлы|*.txt";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var writer = new System.IO.StreamWriter(dialog.FileName))
                    {
                        writer.WriteLine("Производитель;Процессор;Частота;ОЗУ;HDD;Дата");
                        foreach (var comp in computers)
                        {
                            writer.WriteLine($"{comp.Manufacturer};{comp.ProcessorType};{comp.ClockSpeed:F1};{comp.RAM};{comp.HDD};{comp.ReleaseDate:dd.MM.yyyy}");
                        }
                    }
                    MessageBox.Show("Данные экспортированы! 💕", "Успех");
                }
                catch { MessageBox.Show("Ошибка экспорта!", "Ошибка"); }
            }
        }

        private void ClearClick(object? sender, EventArgs e)
        {
            if (computers.Count == 0) return;
            
            if (MessageBox.Show("Очистить все данные? 💕", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                computers.Clear();
                originalComputers.Clear();
                dataGridViewComputers_RMA.Rows.Clear();
                toolStripStatusLabelMessage.Text = "Данные очищены! 🧹";
            }
        }

        private void ManualClick(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "📚 РУКОВОДСТВО ПОЛЬЗОВАТЕЛЯ\n\n" +
                "1. 📂 Загрузите данные (кнопка Загрузить)\n" +
                "2. ✏️ Меню Редактирование для работы с данными\n" +
                "3. 🔍 Используйте поиск по названию\n" +
                "4. 🎯 Применяйте фильтры по ОЗУ и HDD\n" +
                "5. 🔄 Сортируйте данные\n" +
                "6. 📊 Файл → График для визуализации\n" +
                "7. 💾 Файл → Экспорт для сохранения\n\n" +
                "💕 Сделано с любовью для учебы!",
                "Руководство");
        }
    } // <-- это закрывающая скобка класса FormMain_RMA

    // =========== ФОРМА РЕДАКТИРОВАНИЯ КОМПЬЮТЕРА ===========
    public class FormEditComputer_RMA : Form
    {
        private TextBox? textBoxManufacturer;
        private TextBox? textBoxProcessor;
        private TextBox? textBoxFrequency;
        private TextBox? textBoxRAM;
        private TextBox? textBoxHDD;
        private DateTimePicker? dateTimePickerDate;
        private Button? buttonOk;
        private Button? buttonCancel;

        public DataService.Computer? Computer { get; private set; }

        public FormEditComputer_RMA(DataService.Computer? existingComputer = null)
        {
            InitializeComponent();

            if (existingComputer != null &&
                textBoxManufacturer != null &&
                textBoxProcessor != null &&
                textBoxFrequency != null &&
                textBoxRAM != null &&
                textBoxHDD != null &&
                dateTimePickerDate != null)
            {
                textBoxManufacturer.Text = existingComputer.Manufacturer;
                textBoxProcessor.Text = existingComputer.ProcessorType;
                textBoxFrequency.Text = existingComputer.ClockSpeed.ToString("F1");
                textBoxRAM.Text = existingComputer.RAM.ToString();
                textBoxHDD.Text = existingComputer.HDD.ToString();
                dateTimePickerDate.Value = existingComputer.ReleaseDate;
                this.Text = "✏️ Редактировать компьютер";
            }
            else
            {
                this.Text = "➕ Добавить компьютер";
            }
        }

        private void InitializeComponent()
        {
            this.textBoxManufacturer = new TextBox();
            this.textBoxProcessor = new TextBox();
            this.textBoxFrequency = new TextBox();
            this.textBoxRAM = new TextBox();
            this.textBoxHDD = new TextBox();
            this.dateTimePickerDate = new DateTimePicker();
            this.buttonOk = new Button();
            this.buttonCancel = new Button();

            // Настройка формы
            this.ClientSize = new Size(350, 280);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.LavenderBlush;

            // Создание элементов
            var labelManufacturer = new Label { Text = "Производитель:", Location = new Point(20, 20), Size = new Size(120, 20) };
            if (textBoxManufacturer != null)
            {
                textBoxManufacturer.Location = new Point(150, 20);
                textBoxManufacturer.Size = new Size(180, 20);
            }

            var labelProcessor = new Label { Text = "Процессор:", Location = new Point(20, 50), Size = new Size(120, 20) };
            if (textBoxProcessor != null)
            {
                textBoxProcessor.Location = new Point(150, 50);
                textBoxProcessor.Size = new Size(180, 20);
            }

            var labelFrequency = new Label { Text = "Частота (GHz):", Location = new Point(20, 80), Size = new Size(120, 20) };
            if (textBoxFrequency != null)
            {
                textBoxFrequency.Location = new Point(150, 80);
                textBoxFrequency.Size = new Size(180, 20);
            }

            var labelRAM = new Label { Text = "ОЗУ (GB):", Location = new Point(20, 110), Size = new Size(120, 20) };
            if (textBoxRAM != null)
            {
                textBoxRAM.Location = new Point(150, 110);
                textBoxRAM.Size = new Size(180, 20);
            }

            var labelHDD = new Label { Text = "HDD (GB):", Location = new Point(20, 140), Size = new Size(120, 20) };
            if (textBoxHDD != null)
            {
                textBoxHDD.Location = new Point(150, 140);
                textBoxHDD.Size = new Size(180, 20);
            }

            var labelDate = new Label { Text = "Дата выпуска:", Location = new Point(20, 170), Size = new Size(120, 20) };
            if (dateTimePickerDate != null)
            {
                dateTimePickerDate.Location = new Point(150, 170);
                dateTimePickerDate.Size = new Size(180, 20);
                dateTimePickerDate.Format = DateTimePickerFormat.Short;
            }

            if (buttonOk != null)
            {
                buttonOk.Text = "OK 💕";
                buttonOk.Location = new Point(80, 210);
                buttonOk.Size = new Size(80, 30);
                buttonOk.BackColor = Color.Lavender;
                buttonOk.Click += ButtonOk_Click;
            }

            if (buttonCancel != null)
            {
                buttonCancel.Text = "Отмена";
                buttonCancel.Location = new Point(180, 210);
                buttonCancel.Size = new Size(80, 30);
                buttonCancel.BackColor = Color.Lavender;
                buttonCancel.Click += ButtonCancel_Click;
            }

            // Добавление элементов на форму
            List<Control> controls = new List<Control>
            {
                labelManufacturer, labelProcessor, labelFrequency, labelRAM, labelHDD, labelDate
            };

            if (textBoxManufacturer != null) controls.Add(textBoxManufacturer);
            if (textBoxProcessor != null) controls.Add(textBoxProcessor);
            if (textBoxFrequency != null) controls.Add(textBoxFrequency);
            if (textBoxRAM != null) controls.Add(textBoxRAM);
            if (textBoxHDD != null) controls.Add(textBoxHDD);
            if (dateTimePickerDate != null) controls.Add(dateTimePickerDate);
            if (buttonOk != null) controls.Add(buttonOk);
            if (buttonCancel != null) controls.Add(buttonCancel);

            this.Controls.AddRange(controls.ToArray());
        }

        private void ButtonOk_Click(object? sender, EventArgs e)
        {
            if (ValidateInput() &&
                textBoxManufacturer != null &&
                textBoxProcessor != null &&
                textBoxFrequency != null &&
                textBoxRAM != null &&
                textBoxHDD != null &&
                dateTimePickerDate != null)
            {
                Computer = new DataService.Computer
                {
                    Manufacturer = textBoxManufacturer.Text,
                    ProcessorType = textBoxProcessor.Text,
                    ClockSpeed = double.Parse(textBoxFrequency.Text),
                    RAM = int.Parse(textBoxRAM.Text),
                    HDD = int.Parse(textBoxHDD.Text),
                    ReleaseDate = dateTimePickerDate.Value
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ButtonCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            if (textBoxManufacturer == null ||
                textBoxProcessor == null ||
                textBoxFrequency == null ||
                textBoxRAM == null ||
                textBoxHDD == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxManufacturer.Text) ||
                string.IsNullOrWhiteSpace(textBoxProcessor.Text))
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!double.TryParse(textBoxFrequency.Text, out double freq) || freq <= 0)
            {
                MessageBox.Show("Введите корректную частоту процессора!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(textBoxRAM.Text, out int ram) || ram <= 0)
            {
                MessageBox.Show("Введите корректный объем ОЗУ!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(textBoxHDD.Text, out int hdd) || hdd <= 0)
            {
                MessageBox.Show("Введите корректный объем HDD!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }

    // =========== ФОРМА ГРАФИКА ===========
    public class FormChart_RMA : Form
    {
        private PictureBox? pictureBoxChart;
        private List<DataService.Computer> computers;

        public FormChart_RMA(List<DataService.Computer> computers)
        {
            this.computers = computers;
            InitializeComponent();
            DrawChart();
        }

        private void InitializeComponent()
        {
            this.Text = "📊 График - Распределение ОЗУ";
            this.ClientSize = new Size(700, 500);
            this.BackColor = Color.LavenderBlush;
            this.StartPosition = FormStartPosition.CenterParent;

            pictureBoxChart = new PictureBox();
            if (pictureBoxChart != null)
            {
                pictureBoxChart.Location = new Point(20, 20);
                pictureBoxChart.Size = new Size(660, 460);
                pictureBoxChart.BackColor = Color.White;
                pictureBoxChart.BorderStyle = BorderStyle.FixedSingle;

                this.Controls.Add(pictureBoxChart);
            }
        }

        private void DrawChart()
        {
            if (pictureBoxChart == null || computers.Count == 0) return;

            if (pictureBoxChart.Image != null)
                pictureBoxChart.Image.Dispose();

            Bitmap bmp = new Bitmap(pictureBoxChart.Width, pictureBoxChart.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                // Найти максимальное значение ОЗУ
                int maxRAM = 0;
                foreach (var comp in computers)
                {
                    if (comp.RAM > maxRAM) maxRAM = comp.RAM;
                }

                int barWidth = 40;
                int spacing = 20;
                int startX = 60;
                int startY = bmp.Height - 80;
                int chartHeight = bmp.Height - 120;

                // Нарисовать оси
                g.DrawLine(Pens.Black, startX - 10, startY, bmp.Width - 20, startY); // X ось
                g.DrawLine(Pens.Black, startX, 40, startX, startY + 10); // Y ось

                // Нарисовать столбцы
                Random rand = new Random();
                for (int i = 0; i < computers.Count; i++)
                {
                    int barHeight = (int)((computers[i].RAM / (double)maxRAM) * chartHeight);
                    int x = startX + i * (barWidth + spacing);
                    int y = startY - barHeight;

                    Color barColor = Color.FromArgb(rand.Next(150, 255), rand.Next(150, 255), rand.Next(150, 255));
                    g.FillRectangle(new SolidBrush(barColor), x, y, barWidth, barHeight);
                    g.DrawRectangle(Pens.Black, x, y, barWidth, barHeight);

                    // Подписи
                    g.DrawString(computers[i].Manufacturer, new Font("Arial", 8), Brushes.Black,
                        x, startY + 5);
                    g.DrawString(computers[i].RAM.ToString(), new Font("Arial", 9, FontStyle.Bold), Brushes.Black,
                        x + barWidth / 2 - 10, y - 20);
                }

                // Заголовок
                g.DrawString($"📊 Распределение ОЗУ ({computers.Count} компьютеров)",
                    new Font("Arial", 12, FontStyle.Bold), Brushes.DarkViolet, 200, 10);
            }

            pictureBoxChart.Image = bmp;
        }
    }

} 