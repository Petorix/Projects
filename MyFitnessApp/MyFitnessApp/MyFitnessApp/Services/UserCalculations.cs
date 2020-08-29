using MyFitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessApp.Services
{
    public static class UserCalculations
    {
        public static async Task<int> TodaysCalories()
        {
            var user = await App.dm.GetUser();
            var gender = user.Gender;

            if (user.GeneralGoal == (int)MainGoal.Maintain)
            {
                if (user.StartingWeight == user.CurrentWeight)
                    return (gender == (int)Gender.Male) ? (user.CurrentWeight * 14) : (user.CurrentWeight * 11);

                if (user.StartingWeight > user.CurrentWeight)
                {
                    return GainWeight(gender, user.CurrentWeight);
                }

                if (user.StartingWeight < user.CurrentWeight)
                {
                    return LoseWeight(gender, user.CurrentWeight);
                }
            }                

            if (user.CurrentWeight < user.GoalWeight)
            {
                return GainWeight(gender, user.CurrentWeight);
            }

            if (user.CurrentWeight > user.GoalWeight)
            {
                return LoseWeight(gender, user.CurrentWeight);
            }

            return 0;
        }

        private static int GainWeight(int gender, int current)
        {
            return (gender == (int)Gender.Male) ? (current * 14) + 400 : (current * 11) + 300;
        }

        private static int LoseWeight(int gender, int current)
        {
            return (gender == (int)Gender.Male) ? (current * 14) - 400 : (current * 11) - 300;
        }

        public static decimal WeeklyWeightGoal(int cal, int curr, int gender)
        {
            decimal mult = GetMult(gender);
            decimal diff = GetDiff(curr, mult, cal);

            if (diff == 0)
                return 0;
            decimal calc = (Math.Abs(diff) * 7) / 3500;
            return decimal.Round(calc, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal GetMult(int gender)
        {
            return (gender == (int)Gender.Male) ? 14 : 11;
        }

        public static decimal GetDiff(int curr, decimal mult, int cal)
        {
            return (curr * mult) - cal;
        }
    }
}
