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

namespace AnimeForm.Sorted_GroupForms
{
    public partial class GroupByWatchedForm : Form
    {
        private Logic logic;

        public GroupByWatchedForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
            LoadGroupedData();
        }

        private void LoadGroupedData()
        {
            var grouped = logic.GroupByWatchedStatus();

            foreach (var group in grouped)
            {
                string groupName = group.Key ? "Просмотренные" : "Не просмотренные";
                TreeNode statusNode = new TreeNode($"{groupName} ({group.Value.Count})");

                foreach (var anime in group.Value)
                {
                    TreeNode animeNode = new TreeNode($"{anime.Title} - {anime.Rating:0.0#} - {anime.Genre}");
                    animeNode.Tag = anime;
                    statusNode.Nodes.Add(animeNode);
                }

                treeViewGroups.Nodes.Add(statusNode);
            }

            treeViewGroups.ExpandAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
