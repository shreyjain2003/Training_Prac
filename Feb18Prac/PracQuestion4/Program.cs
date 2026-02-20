using System;
using System.Collections.Generic;

namespace PracQuestion4
{
    public interface IBroadBandPlan
    {
        int GetBroadBandPlanAmount();
    }

    public class Black : IBroadBandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 3000;

        public Black(bool isSubscriptionValid, int discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 50)
                throw new ArgumentOutOfRangeException(nameof(discountPercentage));

            _isSubscriptionValid = isSubscriptionValid;
            _discountPercentage = discountPercentage;
        }

        public int GetBroadBandPlanAmount()
        {
            if (_isSubscriptionValid)
                return PlanAmount - (PlanAmount * _discountPercentage / 100);

            return PlanAmount;
        }
    }

    public class Gold : IBroadBandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 1500;

        public Gold(bool isSubscriptionValid, int discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 30)
                throw new ArgumentOutOfRangeException(nameof(discountPercentage));

            _isSubscriptionValid = isSubscriptionValid;
            _discountPercentage = discountPercentage;
        }

        public int GetBroadBandPlanAmount()
        {
            if (_isSubscriptionValid)
                return PlanAmount - (PlanAmount * _discountPercentage / 100);

            return PlanAmount;
        }
    }

    public class SubscribePlan
    {
        private readonly IList<IBroadBandPlan> _broadbandPlans;

        public SubscribePlan(IList<IBroadBandPlan> broadbandPlans)
        {
            _broadbandPlans = broadbandPlans ??
                throw new ArgumentNullException(nameof(broadbandPlans));
        }

        public IList<Tuple<string, int>> GetSubscriptionPlan()
        {
            IList<Tuple<string, int>> result = new List<Tuple<string, int>>();

            foreach (var plan in _broadbandPlans)
            {
                string planType = plan.GetType().Name;
                int amount = plan.GetBroadBandPlanAmount();

                result.Add(new Tuple<string, int>(planType, amount));
            }

            return result;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var plans = new List<IBroadBandPlan>
            {
                new Black(true, 50),
                new Black(false, 10),
                new Gold(true, 30),
                new Black(true, 20),
                new Gold(false, 20)
            };

            var subscriptionPlans = new SubscribePlan(plans);
            var result = subscriptionPlans.GetSubscriptionPlan();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Item1}, {item.Item2}");
            }
        }
    }
}
