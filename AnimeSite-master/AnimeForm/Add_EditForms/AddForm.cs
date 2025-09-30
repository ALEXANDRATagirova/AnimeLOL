using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace AnimeForm
{
    public partial class AddForm : Form
    {
        private Logic logic;

        public AddForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                logic.AddAnime(txtTitle.Text, txtGenre.Text, double.Parse(txtRating.Text));
                DialogResult = DialogResult.OK;
                Close();
            }

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название аниме!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Введите жанр!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(txtRating.Text, out double rating) || rating < 0 || rating > 10)
            {
                MessageBox.Show("Введите корректный рейтинг (0-10)!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        

        
    }
}

