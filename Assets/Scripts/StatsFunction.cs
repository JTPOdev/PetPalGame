using System.Collections;
using UnityEngine;

public enum FoodType
{
    DogFood = 10,
    TurkeyFood = 20,
    SteakFood = 30
}

public enum DrinkType
{
    Water = 5,
    Milk = 10,
    MilkShake = 15
}

public class StatsFunction : MonoBehaviour
{
    public Stats stats;

    private int hunger;
    private int thirst;
    private int sleep;

    public int bathAmount = 5;
    public int playAmount = 15;
    public int sleepAmount = 3;

    private Coroutine sleepCoroutine;

    public void FeedDogFood()
    {
        Feed(FoodType.DogFood);
    }

    public void FeedTurkeyFood()
    {
        Feed(FoodType.TurkeyFood);
    }

    public void FeedSteakFood()
    {
        Feed(FoodType.SteakFood);
    }

    public void FeedWater()
    {
        Drink(DrinkType.Water);
    }

    public void FeedMilk()
    {
        Drink(DrinkType.Milk);
    }

    public void FeedMilkShake()
    {
        Drink(DrinkType.MilkShake);
    }

    public void TakeBath()
    {
        stats.TakeBath(bathAmount);
        Debug.Log($"Pet has taken a bath. Bath value increased by {bathAmount}.");
    }

    public void Play()
    {
        stats.HaveFun(playAmount);
        Debug.Log($"Pet has played. Fun value increased by {playAmount}.");
    }

    public void Sleep()
    {
        stats.Rest(sleepAmount);
        Debug.Log($"Pet has slept. Energy increased by {sleepAmount}.");
    }

    public void StartIncreasingSleep()
    {
        if (sleepCoroutine == null)
        {
            sleepCoroutine = StartCoroutine(IncreaseSleepOverTime());
        }
    }

    public void StopIncreasingSleep()
    {
        if (sleepCoroutine != null)
        {
            StopCoroutine(sleepCoroutine);
            sleepCoroutine = null;
        }
    }

    private IEnumerator IncreaseSleepOverTime()
    {
        while (true)
        {
            stats.Rest(3);
            Debug.Log($"Sleep increased by 3. Current sleep: {stats.energyBar}.");
            yield return new WaitForSeconds(3f);
        }
    }

    public void Feed(FoodType foodType)
    {
        if (stats == null)
        {
            Debug.LogError("Stats reference is missing in Feed.");
            return;
        }

        stats.Eat((int)foodType);
        Debug.Log($"Pet fed {foodType}. Hunger level: {stats.Hunger}");
    }

    public void Drink(DrinkType drinkType)
    {
        if (stats == null)
        {
            Debug.LogError("Stats reference is missing in Drink.");
            return;
        }

        stats.Drink((int)drinkType);
        Debug.Log($"Pet drank {drinkType}. Thirst level: {stats.Thirst}");
    }
}
