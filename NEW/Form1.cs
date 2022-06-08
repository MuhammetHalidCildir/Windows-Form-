using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace NEW
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListCategories();

            ListProducts();

        }

        private void ListProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                DGVProduct.DataSource = context.Products.ToList();
                //burası veri tabanına select*from işlemini götürücek. Bu döngüyü sağlaması için product taki elemanları select edicektir.
            }
        }
        private void ListProductsByCategory(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                DGVProduct.DataSource = context.Products.Where(p=>p.CategoryId==categoryId).ToList();
            }
        }
        private void ListCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                cbxCategory.DataSource = context.Categories.ToList();
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryId";
            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));

            }
            catch 
            {

                
            }
        
        }
        private void ListProductsByProduct(string key)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                DGVProduct.DataSource = context.Products.Where(p => p.ProductName.Contains(tbxSearch.Text)).ToList();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ListProductsByProduct(tbxSearch.Text);
        }
    }
}
