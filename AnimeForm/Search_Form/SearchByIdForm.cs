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
    public partial class SearchByIdForm : Form
    {
        private Logic logic;
        public Anime FoundAnime { get; private set; }

        public SearchByIdForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchAnime();
        }

        private void SearchAnime()
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                FoundAnime = logic.GetAnimeById(id);

                if (FoundAnime != null)
                {
                    DisplayAnimeInfo(FoundAnime);
                    btnSelect.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Аниме с таким ID не найдено!", "Результат поиска",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAnimeInfo();
                    btnSelect.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Введите корректный ID!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayAnimeInfo(Anime anime)
        {
            lblTitle.Text = anime.Title;
            lblGenre.Text = anime.Genre;
            lblRating.Text = anime.Rating.ToString("0.0#");
            lblId.Text = anime.Id.ToString();

            groupBoxResults.Visible = true;
        }

        private void ClearAnimeInfo()
        {
            lblTitle.Text = "-";
            lblGenre.Text = "-";
            lblRating.Text = "-";
            lblId.Text = "-";

            groupBoxResults.Visible = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (FoundAnime != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и управляющие клавиши
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Поиск при нажатии Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SearchAnime();
            }
        }

        private void SearchByIdForm_Load(object sender, EventArgs e)
        {
            ClearAnimeInfo();
            btnSelect.Enabled = false;
        }
    }
}
