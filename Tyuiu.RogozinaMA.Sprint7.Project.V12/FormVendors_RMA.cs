using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tyuiu.RogozinaMA.Sprint7.Project.V12.Lib;

namespace Tyuiu.RogozinaMA.Sprint7.Project.V12
{
    public class FormVendors_RMA : Form
    {
        private DataGridView dataGridViewVendors;
        private List<DataService.Vendor> vendors;

        public FormVendors_RMA(List<DataService.Vendor> vendorsList)
        {
            dataGridViewVendors = new DataGridView(); 
            vendors = vendorsList;
            InitializeComponent();
            LoadVendors();
        }

        private void InitializeComponent()
        {
            this.Text = "🏪 Фирмы-реализаторы";
            this.ClientSize = new Size(800, 400);
            this.BackColor = Color.LavenderBlush;
            this.StartPosition = FormStartPosition.CenterParent;

            dataGridViewVendors.Dock = DockStyle.Fill;
            dataGridViewVendors.BackgroundColor = Color.White;
            dataGridViewVendors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewVendors.RowHeadersVisible = false;
            dataGridViewVendors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewVendors.DefaultCellStyle.SelectionBackColor = Color.Lavender;

            
            dataGridViewVendors.Columns.Add("Name", "Название 🏪");
            dataGridViewVendors.Columns.Add("Address", "Адрес 📍");
            dataGridViewVendors.Columns.Add("Phone", "Телефон 📞");
            dataGridViewVendors.Columns.Add("Notes", "Примечание 📝");

            dataGridViewVendors.Columns[0].Width = 150;
            dataGridViewVendors.Columns[1].Width = 200;
            dataGridViewVendors.Columns[2].Width = 150;
            dataGridViewVendors.Columns[3].Width = 250;

            this.Controls.Add(dataGridViewVendors);

            // Кнопка закрытия
            Button buttonClose = new Button();
            buttonClose.Text = "Закрыть";
            buttonClose.Location = new Point(350, 350);
            buttonClose.Size = new Size(100, 30);
            buttonClose.BackColor = Color.Lavender;
            buttonClose.Click += (s, e) => this.Close();

            this.Controls.Add(buttonClose);
        }

        private void LoadVendors()
        {
            dataGridViewVendors.Rows.Clear();

            foreach (var vendor in vendors)
            {
                dataGridViewVendors.Rows.Add(
                    vendor.Name,
                    vendor.Address,
                    vendor.Phone,
                    vendor.Notes
                );
            }

            this.Text = $"🏪 Фирмы-реализаторы ({vendors.Count} фирм)";
        }
    }
}