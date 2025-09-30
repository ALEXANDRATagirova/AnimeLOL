using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace AnimeForm
{
    public partial class GenreSelectionForm : Form
    {
        private Logic logic;
        public string SelectedGenre { get; private set; }

        public GenreSelectionForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
            LoadGenres();
        }

        private void LoadGenres()
        {
            var genres = logic.GetAllAnime()
                .Select(a => a.Genre)
                .Distinct()
                .OrderBy(g => g)
                .ToList();

            listBoxGenres.DataSource = genres;

            if (listBoxGenres.Items.Count > 0)
                listBoxGenres.SelectedIndex = 0;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (listBoxGenres.SelectedItem != null)
            {
                SelectedGenre = listBoxGenres.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите жанр!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
    }
}
