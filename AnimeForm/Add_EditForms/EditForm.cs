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
using Model;

namespace AnimeForm
{
    public partial class EditForm : Form
    {
        private Logic logic;
        private Anime anime;

        public EditForm(Logic logic, Anime anime)
        {
            InitializeComponent();
            this.logic = logic;
            this.anime = anime;
            LoadAnimeData();
        }
        private void LoadAnimeData()
        {
            TxtId.Text = anime.Id.ToString();
            TxtTitle.Text = anime.Title;
            TxtGenre.Text = anime.Genre;
            TxtRating.Text = anime.Rating.ToString("0.0#");
            checkBoxWatched.Checked = anime.IsWatched;
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(TxtTitle.Text))
            {
                MessageBox.Show("Введите название аниме!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtGenre.Text))
            {
                MessageBox.Show("Введите жанр!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(TxtRating.Text, out double rating) || rating < 0 || rating > 10)
            {
                MessageBox.Show("Введите корректный рейтинг (0-10)!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                logic.ChangeInfo(anime.Id, anime.Title, anime.Genre, anime.Rating, anime.IsWatched,
                               TxtTitle.Text, TxtGenre.Text, double.Parse(TxtRating.Text), checkBoxWatched.Checked);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private void checkBoxWatched_CheckedChanged(object sender, EventArgs e)
        {
            bool newValue = checkBoxWatched.Checked;
            logic.MarkAsWatched(anime.Id, newValue);
            anime.IsWatched = newValue;
        }



        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (ValidateInput())
        //    {
        //        logic.ChangeInfo(anime.Id, anime.Title, anime.Genre, anime.Rating,
        //                       txtTitle.Text, txtGenre.Text, double.Parse(txtRating.Text), checkBoxWatched.Checked);
        //        DialogResult = DialogResult.OK;
        //        Close();
        //    }
        //}


    }
}
