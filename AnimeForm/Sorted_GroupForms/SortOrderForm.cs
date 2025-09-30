using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeForm
{
    public partial class SortOrderForm : Form
    {
        public bool AscendingOrder { get; private set; }

        public SortOrderForm(string sortType)
        {
            InitializeComponent();
            this.Text = $"Сортировка {sortType}";
            labelQuestion.Text = $"Как отсортировать {sortType}?";
        }

        private void btnAscending_Click(object sender, EventArgs e)
        {
            AscendingOrder = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnDescending_Click_1(object sender, EventArgs e)
        {
            AscendingOrder = false;
            DialogResult = DialogResult.OK;
            Close();

        }

        
    }
}

