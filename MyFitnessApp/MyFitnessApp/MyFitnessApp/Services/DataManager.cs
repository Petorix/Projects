using MyFitnessApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyFitnessApp.Services
{
    public class DataManager
    {
        private readonly SQLiteAsyncConnection conn;
        private readonly IDataStore<User> userData;

        private readonly IDataStore<Meals> mealData;
        private readonly IDataStore<Exercises> exerciseData;

        private readonly IDataStore<TotalHistory> thData;
        private readonly IDataStore<MealsHistory> mhData;
        private readonly IDataStore<ExercisesHistory> ehData;
        private readonly IDataStore<WeightHistory> whData;

        private readonly IDataStore<ExternalContent> exContentData;

        public DataManager()
        {
            conn = new SQLiteAsyncConnection(App.FilePath);
            userData = new DataStore<User>(conn);
            mhData = new DataStore<MealsHistory>(conn);
            mealData = new DataStore<Meals>(conn);
            thData = new DataStore<TotalHistory>(conn);
            exerciseData = new DataStore<Exercises>(conn);
            ehData = new DataStore<ExercisesHistory>(conn);
            whData = new DataStore<WeightHistory>(conn);
            exContentData = new DataStore<ExternalContent>(conn);

            CreateTables();
        }

        private async void CreateTables()
        {
            await conn.CreateTablesAsync<Exercises, ExercisesHistory, Meals, MealsHistory, TotalHistory>();
            await conn.CreateTablesAsync<User, WeightHistory, ExternalContent>();
        }

        public async void RESET_EVERYTHING()
        {
            try
            {
                await conn.DeleteAllAsync<User>();
                await conn.DeleteAllAsync<WeightHistory>();
                await conn.DeleteAllAsync<TotalHistory>();

                await conn.DeleteAllAsync<ExternalContent>();

                await conn.DeleteAllAsync<MealsHistory>();
                await conn.DeleteAllAsync<Meals>();

                await conn.DeleteAllAsync<ExercisesHistory>();
                await conn.DeleteAllAsync<Exercises>();
            }
            catch
            {
                Debug.WriteLine("** ERROR ** RESET_EVERYTHING failed.");
            }
        }

        #region USER DATA
        public async Task<User> GetUser()
        {
            try
            {
                var result = await userData.Get();

                return result.First();
            }
            catch
            {
                Debug.WriteLine("Failed on get user");

                return null;
            }
        }

        public async void UpdateUser(User user)
        {
            if (user == null)
                return;
            try
            {
                await userData.Update(user);
            }
            catch
            {
                Debug.WriteLine("User update failed.");
            }
        }

        public async Task<bool> InsertUser(User user)
        {
            try
            {
                await userData.Insert(user);

                return true;
            }
            catch
            {
                Debug.WriteLine("User not added.");

                return false;
            }
        }
        #endregion

        #region MEALS AND EXERCISES DATA
        //Exercise data
        public async Task<Exercises> GetExercise(int id)
        {
            try
            {
                return await exerciseData.Get(id);
            }
            catch
            {
                Debug.WriteLine("GetAllMeals failed.");

                return null;
            }
        }

        public async Task<List<Exercises>> GetListedExercises(string searchStr)
        {
            try
            {
                var exs = await exerciseData.Get(predicate: x => x.ExerciseName.ToLower().Contains(searchStr.ToLower()), orderBy: x => x.ExerciseName); ;

                return exs;
            }
            catch
            {
                Debug.WriteLine("GetListedExercises failed.");

                return null;
            }
        }

        public async Task<bool> DeleteExercise(Exercises ex)
        {
            try
            {
                //Need to remove history if it exists before removing the meal itself
                var results = await ehData.Get<Meals>(x => x.ExerciseFK == ex.ID);
                var tEntry = await thData.Get(x => x.EntryDate == DateTime.Today);

                foreach (var item in results)
                {
                    await ehData.Delete(item);

                    if (tEntry == null)
                    {
                        Debug.WriteLine("**IRREGULARITY** - No TotalHistory found for today under DeleteExercise.");
                    }
                    else
                    {
                        tEntry.CaloriesTotal += ex.Calories;
                        await thData.Update(tEntry);
                    }
                }

                await exerciseData.Delete(ex);

                return true;
            }
            catch
            {
                Debug.WriteLine("RemDeleteExerciseoveMeal Failed.");

                return false;
            }
        }

        public async Task<bool> InsertExercise(Exercises ex)
        {
            try
            {
                await exerciseData.Insert(ex);

                return true;
            }
            catch
            {
                Debug.WriteLine("InsertExercise failed.");

                return false;
            }
        }

        public async Task<bool> UpdateExercise(Exercises ex)
        {
            try
            {
                await exerciseData.Update(ex);

                return true;
            }
            catch
            {
                Debug.WriteLine("UpdateExercise failed.");

                return false;
            }
        }


        //Meal data
        public async Task<Meals> GetMeal(int id)
        {
            try
            {
                return await mealData.Get(id);
            }
            catch
            {
                Debug.WriteLine("GetMeal failed.");

                return null;
            }
        }

        public async Task<List<Meals>> GetListedMeals(string searchStr)
        {
            try
            {
                var meals = await mealData.Get(predicate: x => x.MealName.ToLower().Contains(searchStr.ToLower()), orderBy: x => x.MealName); ;

                return meals;
            }
            catch
            {
                Debug.WriteLine("GetListedMeals failed.");

                return null;
            }
        }

        public async Task<bool> DeleteMeal(Meals meal)
        {
            try
            {
                //Need to remove history if it exists before removing the meal itself
                var results = await mhData.Get<Meals>(x => x.MealsFK == meal.ID);
                var tEntry = await thData.Get(x => x.EntryDate == DateTime.Today);

                foreach (var item in results)
                {
                    await mhData.Delete(item);

                    if (tEntry == null)
                    {
                        Debug.WriteLine("**IRREGULARITY** - No TotalHistory found for today under DeleteMeal.");
                    }
                    else
                    {
                        tEntry.CaloriesTotal -= meal.Calories;
                        await thData.Update(tEntry);
                    }
                }

                await mealData.Delete(meal);

                return true;
            }
            catch
            {
                Debug.WriteLine("DeleteMeal failed.");

                return false;
            }
        }

        public async Task<bool> InsertMeal(Meals meal)
        {
            try
            {
                await mealData.Insert(meal);

                return true;
            }
            catch
            {
                Debug.WriteLine("InsertMeal failed.");

                return false;
            }
        }

        public async Task<bool> UpdateMeal(Meals meal)
        {
            try
            {
                await mealData.Update(meal);

                return true;
            }
            catch
            {
                Debug.WriteLine("UpdateMeal failed.");

                return false;
            }
        }
        #endregion

        #region HISTORY
        //Exercise histories
        public async Task<int> GetTodaysExerciseCalories()
        {
            try
            {
                int calories = 0;
                var ehSearch = await ehData.Get<ExercisesHistory>(x => x.EntryDate == DateTime.Today);

                foreach (ExercisesHistory eh in ehSearch)
                {
                    var e = await exerciseData.Get(eh.ExerciseFK);
                    calories += e.Calories;
                }

                return calories;
            }
            catch
            {
                Debug.WriteLine("GetTodaysExerciseCalories failed.");

                return 0;
            }
        }

        public async Task<List<Exercises>> GetTodaysWorkouts()
        {
            try
            {
                var exercises = new List<Exercises>();
                var ehSearch = await ehData.Get<ExercisesHistory>(x => x.EntryDate == DateTime.Today);

                foreach (ExercisesHistory eh in ehSearch)
                {
                    var e = await exerciseData.Get(eh.ExerciseFK);
                    e.EH_FK = eh.ID;
                    exercises.Add(e);
                }

                return exercises;
            }
            catch
            {
                Debug.WriteLine("GetTodaysWorkouts failed.");

                return null;
            }
        }

        public async void InsertExerciseEntry(int exerciseId, int cal, int goal)
        {
            try
            {
                var ehEntry = new ExercisesHistory()
                {
                    EntryDate = DateTime.Today,
                    ExerciseFK = exerciseId
                };

                await ehData.Insert(ehEntry);

                var tEntry = await thData.Get(x => x.EntryDate == DateTime.Today);
                if (tEntry == null)
                {
                    tEntry = new TotalHistory()
                    {
                        EntryDate = DateTime.Today,
                        CaloriesTotal = 0 - cal,
                        CaloriesGoal = goal
                    };

                    await thData.Insert(tEntry);
                }
                else
                {
                    tEntry.CaloriesTotal -= cal;

                    await thData.Update(tEntry);
                }
            }
            catch
            {
                Debug.WriteLine("InsertExerciseEntry Failed.");
            }
        }

        public async Task<bool> DeleteExerciseEntry(int ehid, int cal)
        {
            try
            {
                var ehEntry = await ehData.Get(x => x.ID == ehid);
                if (ehEntry != null)
                {
                    await ehData.Delete(ehEntry);
                }

                var tEntry = await thData.Get(x => x.EntryDate == DateTime.Today);
                if (tEntry == null)
                {
                    Debug.WriteLine("**IRREGULARITY** - No TotalHistory found for today under DeleteExerciseEntry.");
                }
                else
                {
                    tEntry.CaloriesTotal += cal;

                    await thData.Update(tEntry);
                }

                return true;
            }
            catch
            {
                Debug.WriteLine("DeleteExerciseEntry Failed.");

                return false;
            }
        }

        public async Task<List<Exercises>> GetExercisesHistory(Expression<Func<ExercisesHistory, bool>> predicate = null)
        {
            try
            {
                var exercises = new List<Exercises>();
                List<ExercisesHistory> ehSearch = new List<ExercisesHistory>();
                if (predicate != null)
                    ehSearch = await ehData.Get<ExercisesHistory>(predicate);
                else
                    ehSearch = await ehData.Get();


                foreach (ExercisesHistory eh in ehSearch)
                {
                    var e = await exerciseData.Get(eh.ExerciseFK);
                    e.EH_FK = eh.ID;
                    e.Entry = eh.EntryDate;
                    exercises.Add(e);
                }

                return exercises;
            }
            catch
            {
                Debug.WriteLine("GetExercisesHistory failed.");

                return null;
            }
        }


        //Meal histories
        public async Task<int> GetTodaysMealCalories()
        {
            try
            {
                int calories = 0;
                var mhSearch = await mhData.Get<MealsHistory>(x => x.EntryDate == DateTime.Today);

                foreach (MealsHistory mh in mhSearch)
                {
                    var m = await mealData.Get(mh.MealsFK);
                    calories += m.Calories;
                }

                return calories;
            }
            catch
            {
                Debug.WriteLine("GetTodaysMealCalories failed.");

                return 0;
            }
        }

        public async Task<List<Meals>> GetTodaysMeals()
        {
            try
            {
                var meals = new List<Meals>();
                var mhSearch = await mhData.Get<MealsHistory>(x => x.EntryDate == DateTime.Today);

                foreach (MealsHistory mh in mhSearch)
                {
                    var m = await mealData.Get(mh.MealsFK);
                    m.MH_FK = mh.ID;
                    meals.Add(m);
                }

                return meals;
            }
            catch
            {
                Debug.WriteLine("GetTodaysMeals failed.");

                return null;
            }
        }

        public async void InsertMealEntry(int mealId, int cal, int goal)
        {
            try
            {
                var mhEntry = new MealsHistory()
                {
                    EntryDate = DateTime.Today,
                    MealsFK = mealId
                };
                await mhData.Insert(mhEntry);

                var tEntry = await thData.Get(x => x.EntryDate == DateTime.Today);
                if (tEntry == null)
                {
                    tEntry = new TotalHistory()
                    {
                        EntryDate = DateTime.Today,
                        CaloriesTotal = cal,
                        CaloriesGoal = goal
                    };

                    await thData.Insert(tEntry);
                }
                else
                {
                    tEntry.CaloriesTotal += cal;

                    await thData.Update(tEntry);
                }
            }
            catch
            {
                Debug.WriteLine("InsertMealEntry Failed.");
            }
        }

        public async Task<bool> DeleteMealEntry(int mhid, int cal)
        {
            try
            {
                var mhEntry = await mhData.Get(x => x.ID == mhid);
                if(mhEntry != null)
                {
                    await mhData.Delete(mhEntry);
                }

                var tEntry = await thData.Get(x => x.EntryDate == DateTime.Today);
                if (tEntry == null)
                {
                    Debug.WriteLine("**IRREGULARITY** - No TotalHistory found for today under DeleteMealEntry.");
                }
                else
                {
                    tEntry.CaloriesTotal -= cal;

                    await thData.Update(tEntry);
                }

                return true;
            }
            catch
            {
                Debug.WriteLine("DeleteMealEntry Failed.");

                return false;
            }
        }

        public async Task<List<Meals>> GetMealsHistory(Expression<Func<MealsHistory, bool>> predicate = null)
        {
            try
            {
                var meals = new List<Meals>();
                List<MealsHistory> mhSearch = new List<MealsHistory>();
                if (predicate != null)
                    mhSearch = await mhData.Get<MealsHistory>(predicate);
                else
                    mhSearch = await mhData.Get();


                foreach (MealsHistory mh in mhSearch)
                {
                    var m = await mealData.Get(mh.MealsFK);
                    m.MH_FK = mh.ID;
                    m.Entry = mh.EntryDate;
                    meals.Add(m);
                }

                return meals;
            }
            catch
            {
                Debug.WriteLine("GetExercisesHistory failed.");

                return null;
            }
        }


        //Weight histories
        public async Task<List<WeightHistory>> GetAllWeightEntries()
        {
            try
            {
                return await whData.Get();
            }
            catch
            {
                Debug.WriteLine("GetAllWeightEntries failed.");
                return null;
            }
        }

        public async Task<List<WeightHistory>> GetWeightHistories(Expression<Func<WeightHistory, bool>> predicate = null)
        {
            try
            {
                List<WeightHistory> whSearch = new List<WeightHistory>();

                if (predicate != null)
                    whSearch = await whData.Get<WeightHistory>(predicate);
                else
                {
                    whSearch = await whData.Get();
                }
                    

                return whSearch;
            }
            catch
            {
                Debug.WriteLine("GetWeightHistories failed.");

                return null;
            }
        }

        public async void InsertWeightEntry(int weight)
        {
            try
            {
                var recordExist = await GetAllWeightEntries();
                var item = recordExist.Find(x => x.EntryDate == DateTime.Today);

                if (item != null)
                {
                    item.Weight = weight;
                    await whData.Update(item);
                    return;
                }

                var entry = new WeightHistory()
                {
                    EntryDate = DateTime.Today,
                    Weight = weight
                };

                await whData.Insert(entry);
            }
            catch
            {
                Debug.WriteLine("InsertWeightEntry failed.");
            }
        }

        public async void UpdateWeightEntry(WeightHistory entry)
        {
            try
            {
                await whData.Update(entry);
            }
            catch
            {
                Debug.WriteLine("InsertWeightEntry failed.");
            }
        }


        //Total History
        public async Task<List<TotalHistory>> GetTotalHistories(Expression<Func<TotalHistory, bool>> predicate = null)
        {
            try
            {
                List<TotalHistory> thSearch = new List<TotalHistory>();

                if (predicate != null)
                    thSearch = await thData.Get<TotalHistory>(predicate);
                else
                    thSearch = await thData.Get();

                return thSearch;
            }
            catch
            {
                Debug.WriteLine("GetTotalHistories failed.");

                return null;
            }
        }

        //Reset histories
        public async void ResetMealHistoryTable()
        {
            try
            {
                var mh = await mhData.Get();

                foreach (var item in mh)
                {
                    await mhData.Delete(item);
                }

                Debug.WriteLine("Reset ResetMealHistoryTable Successful.");
            }
            catch
            {
                Debug.WriteLine("Reset ResetMealHistoryTable Failed.");

            }
        }

        public async void ResetTotalHistory()
        {
            try
            {
                var th = await thData.Get();

                foreach (var item in th)
                {
                    await thData.Delete(item);
                }

                Debug.WriteLine("Reset Total History Successful.");
            }
            catch
            {
                Debug.WriteLine("Reset Total History Failed.");

            }
        }
        #endregion

        #region
        public async Task<List<ExternalContent>> GetExternalContent()
        {
            try
            {
                return await exContentData.Get();
            }
            catch
            {
                Debug.WriteLine("GetExternalContent failed.");

                return null;
            }
        }

        public async Task<bool> InsertExternalContent(ExternalContent content)
        {
            try
            {
                await exContentData.Insert(content);

                return true;
            }
            catch
            {
                Debug.WriteLine("InsertExternalContent failed.");

                return false;
            }
        }
        #endregion
    }
}
