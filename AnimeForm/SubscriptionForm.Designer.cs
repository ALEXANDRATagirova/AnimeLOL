using System.Windows.Forms;

namespace AnimeForm
{
    partial class SubscriptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblTitle;
        private Button btnBack;
        private Panel panelMain;
        private Label lblStatus;
        private FlowLayoutPanel flowPlans;
        private Panel planBasic;
        private Button btnBasic;
        private Panel planPremium;
        private Button btnPremium;
        private Panel planUltra;
        private Button btnUltra;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.flowPlans = new System.Windows.Forms.FlowLayoutPanel();
            this.planBasic = new System.Windows.Forms.Panel();
            this.btnBasic = new System.Windows.Forms.Button();
            this.planPremium = new System.Windows.Forms.Panel();
            this.btnPremium = new System.Windows.Forms.Button();
            this.planUltra = new System.Windows.Forms.Panel();
            this.btnUltra = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.flowPlans.SuspendLayout();
            this.planBasic.SuspendLayout();
            this.planPremium.SuspendLayout();
            this.planUltra.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.panelHeader.Controls.Add(this.btnBack);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(600, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(10, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "← Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(100, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Управление подпиской";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Controls.Add(this.lblStatus);
            this.panelMain.Controls.Add(this.flowPlans);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(600, 440);
            this.panelMain.TabIndex = 1;
            // 
            // flowPlans
            // 
            this.flowPlans.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowPlans.Controls.Add(this.planBasic);
            this.flowPlans.Controls.Add(this.planPremium);
            this.flowPlans.Controls.Add(this.planUltra);
            this.flowPlans.Location = new System.Drawing.Point(50, 80);
            this.flowPlans.Name = "flowPlans";
            this.flowPlans.Size = new System.Drawing.Size(500, 200);
            this.flowPlans.TabIndex = 0;
            // 
            // planBasic
            // 
            this.planBasic.BackColor = System.Drawing.Color.White;
            this.planBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.planBasic.Controls.Add(this.btnBasic);
            this.planBasic.Location = new System.Drawing.Point(20, 20);
            this.planBasic.Margin = new System.Windows.Forms.Padding(20);
            this.planBasic.Name = "planBasic";
            this.planBasic.Size = new System.Drawing.Size(120, 160);
            this.planBasic.TabIndex = 0;
            // 
            // btnBasic
            // 
            this.btnBasic.BackColor = System.Drawing.Color.LightGreen;
            this.btnBasic.FlatAppearance.BorderSize = 0;
            this.btnBasic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBasic.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBasic.Location = new System.Drawing.Point(10, 120);
            this.btnBasic.Name = "btnBasic";
            this.btnBasic.Size = new System.Drawing.Size(100, 30);
            this.btnBasic.TabIndex = 0;
            this.btnBasic.Text = "Базовый";
            this.btnBasic.UseVisualStyleBackColor = false;
            // 
            // planPremium
            // 
            this.planPremium.BackColor = System.Drawing.Color.White;
            this.planPremium.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.planPremium.Controls.Add(this.btnPremium);
            this.planPremium.Location = new System.Drawing.Point(180, 20);
            this.planPremium.Margin = new System.Windows.Forms.Padding(20);
            this.planPremium.Name = "planPremium";
            this.planPremium.Size = new System.Drawing.Size(120, 160);
            this.planPremium.TabIndex = 1;
            // 
            // btnPremium
            // 
            this.btnPremium.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPremium.FlatAppearance.BorderSize = 0;
            this.btnPremium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPremium.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPremium.Location = new System.Drawing.Point(10, 120);
            this.btnPremium.Name = "btnPremium";
            this.btnPremium.Size = new System.Drawing.Size(100, 30);
            this.btnPremium.TabIndex = 0;
            this.btnPremium.Text = "Премиум";
            this.btnPremium.UseVisualStyleBackColor = false;
            // 
            // planUltra
            // 
            this.planUltra.BackColor = System.Drawing.Color.White;
            this.planUltra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.planUltra.Controls.Add(this.btnUltra);
            this.planUltra.Location = new System.Drawing.Point(340, 20);
            this.planUltra.Margin = new System.Windows.Forms.Padding(20);
            this.planUltra.Name = "planUltra";
            this.planUltra.Size = new System.Drawing.Size(120, 160);
            this.planUltra.TabIndex = 2;
            // 
            // btnUltra
            // 
            this.btnUltra.BackColor = System.Drawing.Color.Plum;
            this.btnUltra.FlatAppearance.BorderSize = 0;
            this.btnUltra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUltra.Location = new System.Drawing.Point(10, 120);
            this.btnUltra.Name = "btnUltra";
            this.btnUltra.Size = new System.Drawing.Size(100, 30);
            this.btnUltra.TabIndex = 0;
            this.btnUltra.Text = "Ультра";
            this.btnUltra.UseVisualStyleBackColor = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatus.Location = new System.Drawing.Point(50, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(500, 25);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Статус: Нет активной подписки";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SubscriptionForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubscriptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подписка";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.flowPlans.ResumeLayout(false);
            this.planBasic.ResumeLayout(false);
            this.planPremium.ResumeLayout(false);
            this.planUltra.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}