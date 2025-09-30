using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLogic.Logic;

namespace AnimeForm
{
    public partial class SubscriptionForm : Form
    {
        private SubscriptionService subscriptionService;
        private int currentUserId = 1;
        private MainForm mainForm;

        public SubscriptionForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            subscriptionService = new SubscriptionService();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Обработчики кнопок
            btnBack.Click += (s, e) => this.Close();
            btnBasic.Click += (s, e) => SubscribeToPlan(1);
            btnPremium.Click += (s, e) => SubscribeToPlan(2);
            btnUltra.Click += (s, e) => SubscribeToPlan(3);

            // Настройка карточек
            SetupPlanCards();

            // Загрузка данных
            UpdateSubscriptionStatus();
        }

        private void SetupPlanCards()
        {
            // Базовая карточка
            AddPlanInfo(planBasic, "🎁 Базовый", "Бесплатно", new string[]
            {
                "• 720p качество",
                "• С рекламой",
                "• Базовый контент"
            });

            // Премиум карточка
            AddPlanInfo(planPremium, "⭐ Премиум", "299₽/мес", new string[]
            {
                "• 1080p качество",
                "• Без рекламы",
                "• Весь контент",
                "• Оффлайн просмотр"
            });

            // Ультра карточка
            AddPlanInfo(planUltra, "👑 Ультра", "599₽/мес", new string[]
            {
                "• 4K качество",
                "• Ранний доступ",
                "• Эксклюзивы",
                "• 4 устройства"
            });
        }

        private void AddPlanInfo(Panel panel, string title, string price, string[] features)
        {
            // Заголовок
            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location = new Point(10, 15),
                Size = new Size(100, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Цена
            var priceLabel = new Label
            {
                Text = price,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                Location = new Point(10, 40),
                Size = new Size(100, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Особенности
            var featuresLabel = new Label
            {
                Text = string.Join("\n", features),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(10, 65),
                Size = new Size(100, 50)
            };

            panel.Controls.Add(titleLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(featuresLabel);

            // Эффекты при наведении
            panel.MouseEnter += (s, e) => panel.BackColor = Color.LightYellow;
            panel.MouseLeave += (s, e) => panel.BackColor = Color.White;
        }

        private void UpdateSubscriptionStatus()
        {
            var subscription = subscriptionService.GetUserSubscription(currentUserId);

            if (subscription != null && subscription.IsValid)
            {
                var plan = subscriptionService.GetPlanById(subscription.PlanId);
                lblStatus.Text = $"Активна: {plan.Name} (до {subscription.EndDate:dd.MM.yy})";
                lblStatus.ForeColor = Color.DarkGreen;

                // Обновляем кнопки
                UpdatePlanButtons(plan.Id);
            }
            else
            {
                lblStatus.Text = "Нет активной подписки";
                lblStatus.ForeColor = Color.DarkRed;

                // Сбрасываем все кнопки
                ResetPlanButtons();
            }
        }

        private void UpdatePlanButtons(int activePlanId)
        {
            btnBasic.Enabled = activePlanId != 1;
            btnPremium.Enabled = activePlanId != 2;
            btnUltra.Enabled = activePlanId != 3;

            if (activePlanId == 1) btnBasic.Text = "Текущий";
            if (activePlanId == 2) btnPremium.Text = "Текущий";
            if (activePlanId == 3) btnUltra.Text = "Текущий";
        }

        private void ResetPlanButtons()
        {
            btnBasic.Enabled = true;
            btnPremium.Enabled = true;
            btnUltra.Enabled = true;

            btnBasic.Text = "Базовый";
            btnPremium.Text = "Премиум";
            btnUltra.Text = "Ультра";
        }

        private void SubscribeToPlan(int planId)
        {
            var plan = subscriptionService.GetPlanById(planId);
            var currentSub = subscriptionService.GetUserSubscription(currentUserId);

            // Проверяем, не активна ли уже эта подписка
            if (currentSub != null && currentSub.PlanId == planId && currentSub.IsValid)
            {
                MessageBox.Show($"У вас уже активна подписка '{plan.Name}'",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Подтверждение
            var result = MessageBox.Show(
                $"Оформить подписку '{plan.Name}'?\n" +
                $"Цена: {(plan.Price == 0 ? "Бесплатно" : $"{plan.Price} руб./мес")}",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = subscriptionService.SubscribeUser(currentUserId, planId);
                if (success)
                {
                    UpdateSubscriptionStatus();
                    MessageBox.Show($"Подписка '{plan.Name}' оформлена!",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // Показываем главную форму при закрытии
            mainForm?.Show();
        }
    }
}
