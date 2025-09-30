using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public List<string> Features { get; set; }

        public SubscriptionPlan()
        {
            Features = new List<string>();
        }
    }

    // UserSubscription.cs
    public class UserSubscription
    {
        public int UserId { get; set; }
        public int PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string Status => IsActive ? "Активна" : "Неактивна";

        public bool IsValid => IsActive && EndDate > DateTime.Now;
    }
}
