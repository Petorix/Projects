using System;
using System.Collections.Generic;
using System.Text;

namespace MyFitnessApp.Services
{

    //When adding to the enums later on, make sure it's added on last or it will break everything\\

    public enum Mealtypes
    {
        Normal,
        Vegan,
        Vegetarian,
        GlutenFree
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum ActivityLevels
    {
        Low,
        Medium,
        High
    }

    public enum Intensity
    {
        Low,
        MediumLow,
        Medium,
        MediumHigh,
        High,
        VeryHigh
    }

    public enum BodyArea
    {
        Legs,
        Glutes,
        Core,
        Chest,
        Shoulders,
        Arms,
        Back
    }

    public enum MainGoal
    {
        Lose,
        Maintain,
        Gain
    }

    public enum WorkoutTimeFrame
    {
        LessThanTwenty,
        Thirty,
        FourtyFive,
        OverOneHour
    }

    public static class Enumerations
    {
        public static List<string> EnumToList(Type t)
        {
            var list = new List<string>();

            foreach (string item in Enum.GetNames(t))
            {
                list.Add(item);
            }

            return list;
        }

        public static T StringtoEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
