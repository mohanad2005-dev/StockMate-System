using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nudMinStock.Value = 5;
            nudQuantity.Value = 1;

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Columns.Add("ID", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", 130, HorizontalAlignment.Left);
            listView1.Columns.Add("Category", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Quantity", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("Unit Price", 70, HorizontalAlignment.Right);
            listView1.Columns.Add("Min Stock", 75, HorizontalAlignment.Center);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\hp\OneDrive\الصور";
            openFileDialog1.Title = "Choose Photo";
            openFileDialog1.Filter = "Image Files|*.png;*.jpg;*.jpeg";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbProductImage.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text) || string.IsNullOrEmpty(txtProductName.Text) ||
                string.IsNullOrEmpty(txtUnitPrice.Text))
                return;

            ListViewItem item = new ListViewItem(txtProductID.Text.Trim());
            item.SubItems.Add(txtProductName.Text.Trim());
            item.SubItems.Add(cbCategory.SelectedValue?.ToString() ?? cbCategory.Text ?? "");
            item.SubItems.Add(nudQuantity.Value.ToString());
            item.SubItems.Add(txtUnitPrice.Text.Trim());
            item.SubItems.Add(nudMinStock.Value.ToString());
            item.Tag = openFileDialog1.FileName;

            listView1.Items.Add(item);

            txtProductID.Clear();
            txtProductName.Clear();
            cbCategory.SelectedIndex = -1;
            nudQuantity.Value = 1;
            txtUnitPrice.Clear();
            nudMinStock.Value = 5;
            pbProductImage = null;
            openFileDialog1.FileName = "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save is Successfully", "Save");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClear.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((TabControl)tcProducts.Parent).SelectedTab = tcProducts;
        }

        private void updateProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate.PerformClick();
        }

        private void deleteProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete.PerformClick();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        "Welcome to StockMate Inventory Management System.\n\n" +
        "• To add a new product: Fill in the required fields (Product ID, Name, and Unit Price), then click 'Add Product'.\n" +
        "• To update or delete a product: Select the desired product from the list on the right and choose the appropriate action.\n" +
        "• Image management: You can click the 'Add' button next to the product image to select an image from your device.",
        "User Guide - StockMate",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
    );
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((TabControl)tcAbout.Parent).SelectedTab = tcAbout;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductID.Clear();
            txtProductName.Clear();
            cbCategory.SelectedIndex = -1;
            nudQuantity.Value = 1;
            txtUnitPrice.Clear();
            nudMinStock.Value = 5;
            pbProductImage = null;
            openFileDialog1.FileName = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int index = listView1.SelectedIndices[0];
                listView1.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Error, choose an item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Section is not availabel now, return soon.", "Update Section");
        }
    }
}