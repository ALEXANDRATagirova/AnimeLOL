namespace AnimeForm
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewAnime = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnGroupByGenre = new System.Windows.Forms.Button();
            this.btnSortByRating = new System.Windows.Forms.Button();
            this.btnSortByGenreRating = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnime)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAnime
            // 
            this.dataGridViewAnime.AllowUserToAddRows = false;
            this.dataGridViewAnime.AllowUserToDeleteRows = false;
            this.dataGridViewAnime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAnime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnime.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewAnime.Name = "dataGridViewAnime";
            this.dataGridViewAnime.ReadOnly = true;
            this.dataGridViewAnime.Size = new System.Drawing.Size(1027, 400);
            this.dataGridViewAnime.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(30, 425);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 55);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(916, 425);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 55);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(162, 486);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(203, 53);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Изменить информацию";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnGroupByGenre
            // 
            this.btnGroupByGenre.Location = new System.Drawing.Point(382, 425);
            this.btnGroupByGenre.Name = "btnGroupByGenre";
            this.btnGroupByGenre.Size = new System.Drawing.Size(133, 110);
            this.btnGroupByGenre.TabIndex = 4;
            this.btnGroupByGenre.Text = "Группировать по жанру";
            this.btnGroupByGenre.UseVisualStyleBackColor = true;
            this.btnGroupByGenre.Click += new System.EventHandler(this.btnGroupByGenre_Click);
            // 
            // btnSortByRating
            // 
            this.btnSortByRating.Location = new System.Drawing.Point(700, 425);
            this.btnSortByRating.Name = "btnSortByRating";
            this.btnSortByRating.Size = new System.Drawing.Size(200, 110);
            this.btnSortByRating.TabIndex = 5;
            this.btnSortByRating.Text = "Сортировать по рейтингу";
            this.btnSortByRating.UseVisualStyleBackColor = true;
            this.btnSortByRating.Click += new System.EventHandler(this.btnSortByRating_Click);
            // 
            // btnSortByGenreRating
            // 
            this.btnSortByGenreRating.Location = new System.Drawing.Point(531, 425);
            this.btnSortByGenreRating.Name = "btnSortByGenreRating";
            this.btnSortByGenreRating.Size = new System.Drawing.Size(163, 110);
            this.btnSortByGenreRating.TabIndex = 6;
            this.btnSortByGenreRating.Text = "Группировка по просмотру";
            this.btnSortByGenreRating.UseVisualStyleBackColor = true;
            this.btnSortByGenreRating.Click += new System.EventHandler(this.btnSortByGenreRating_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(162, 425);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(203, 55);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Найти аниме по Id";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(30, 486);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(114, 53);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Вернуться на главную";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Location = new System.Drawing.Point(27, 597);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(35, 13);
            this.labelTotalCount.TabIndex = 9;
            this.labelTotalCount.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(916, 486);
            this.button1.Name = "BtnSubscription";
            this.button1.Size = new System.Drawing.Size(114, 49);
            this.button1.TabIndex = 10;
            this.button1.Text = "Подписка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnSubscription_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 619);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTotalCount);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSortByGenreRating);
            this.Controls.Add(this.btnSortByRating);
            this.Controls.Add(this.btnGroupByGenre);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewAnime);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAnime;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnGroupByGenre;
        private System.Windows.Forms.Button btnSortByRating;
        private System.Windows.Forms.Button btnSortByGenreRating;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label labelTotalCount;
        private System.Windows.Forms.Button button1;
    }
}

