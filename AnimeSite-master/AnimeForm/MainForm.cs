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
    public partial class MainForm : Form
    {
        private Logic logic = new Logic();
        private List<Anime> originalAnimeList = new List<Anime>();

        public MainForm()
        {
            InitializeComponent();
            LoadSampleData();
            RefreshAnimeList();
        }

        private void LoadSampleData()
        {
            logic.AddAnime("Attack on Titan", "Action", 9.2);
            logic.AddAnime("Naruto", "Adventure", 8.5);
            logic.AddAnime("One Piece", "Adventure", 9.0);
            logic.AddAnime("Death Note", "Mystery", 8.8);
            logic.AddAnime("My Hero Academia", "Action", 8.3);
        }

        private void RefreshAnimeList()
        {
            dataGridViewAnime.DataSource = null;
            dataGridViewAnime.DataSource = logic.GetAllAnime();
            dataGridViewAnime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            labelTotalCount.Text = $"Всего: {originalAnimeList.Count} аниме";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddForm(logic);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                RefreshAnimeList();
            }
        }
        

        private void btnSortByGenreRating_Click(object sender, EventArgs e)
        {
            var genreForm = new GenreSelectionForm(logic);
            if (genreForm.ShowDialog() == DialogResult.OK)
            {
                // Затем выбираем порядок сортировки
                var sortForm = new SortOrderForm("по рейтингу");
                if (sortForm.ShowDialog() == DialogResult.OK)
                {
                    var sorted = logic.GetAnimeSortedByRatingWithGenre(genreForm.SelectedGenre, sortForm.AscendingOrder);
                    dataGridViewAnime.DataSource = null;
                    dataGridViewAnime.DataSource = sorted;
                    dataGridViewAnime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    string order = sortForm.AscendingOrder ? "по возрастанию" : "по убыванию";
                    labelTotalCount.Text = $"Аниме жанра '{genreForm.SelectedGenre}' сортировка {order}: {sorted.Count}";
                }

            }
        }

        private void btnGroupByGenre_Click(object sender, EventArgs e)
        {
            var genreForm = new GenreSelectionForm(logic);
            if (genreForm.ShowDialog() == DialogResult.OK)
            {
                // Получаем аниме выбранного жанра
                var animeByGenre = logic.GetAllAnime()
                    .Where(a => a.Genre == genreForm.SelectedGenre)
                    .OrderByDescending(a => a.Rating)
                    .ToList();

                // Отображаем результат
                dataGridViewAnime.DataSource = null;
                dataGridViewAnime.DataSource = animeByGenre;
                dataGridViewAnime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                labelTotalCount.Text = $"Аниме жанра '{genreForm.SelectedGenre}': {animeByGenre.Count}";
            }

        }

        private void btnSortByRating_Click(object sender, EventArgs e)
        {
            var sortForm = new SortOrderForm("по рейтингу");
            if (sortForm.ShowDialog() == DialogResult.OK)
            {
                var sorted = logic.GetAnimeSortedByRating(sortForm.AscendingOrder);
                dataGridViewAnime.DataSource = null;
                dataGridViewAnime.DataSource = sorted;
                dataGridViewAnime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                string order = sortForm.AscendingOrder ? "по возрастанию" : "по убыванию";
                labelTotalCount.Text = $"Сортировка по рейтингу ({order}): {sorted.Count} аниме";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAnimeList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnime.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите аниме для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedAnime = (Anime)dataGridViewAnime.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Удалить аниме '{selectedAnime.Title}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                logic.DeleteAnime(selectedAnime.Id);
                RefreshAnimeList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnime.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите аниме для редактирования!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedAnime = (Anime)dataGridViewAnime.SelectedRows[0].DataBoundItem;
            var editForm = new EditForm(logic, selectedAnime);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshAnimeList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchByIdForm(logic);
            if (searchForm.ShowDialog() == DialogResult.OK)
            {
                Anime foundAnime = searchForm.FoundAnime;
                if (foundAnime != null)
                {
                    // Выделяем найденное аниме в DataGridView
                    SelectAnimeInGrid(foundAnime);

                    MessageBox.Show($"Найдено аниме: {foundAnime.Title}", "Результат поиска",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void SelectAnimeInGrid(Anime anime)
        {
            // Ищем строку с нужным аниме
            foreach (DataGridViewRow row in dataGridViewAnime.Rows)
            {
                if (row.DataBoundItem is Anime rowAnime && rowAnime.Id == anime.Id)
                {
                    // Выделяем строку и прокручиваем к ней
                    row.Selected = true;
                    dataGridViewAnime.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }
    }
}
