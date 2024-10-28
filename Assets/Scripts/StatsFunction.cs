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

    public int bathAmount = 5;

    public int drinkWater = 10;
    public int drinkMilk = 15;
    public int drinkMilkShake = 20;

    public int eatDogFood = 10;
    public int eatTurkey = 20;
    public int eatSteak = 30;
    public int playAmount = 15;
    public float playDuration = 3f; 
    public int sleepAmount = 3;
    public float sleepDuration = 3f; 

    private Coroutine sleepCoroutine;
    private Coroutine funCoroutine;

    public void Feed(FoodType foodType)
    {
        if (stats == null)
        {
            Debug.LogError("Stats reference is missing in Feed.");
            return;
        }

        stats.Eat((int)foodType); 
        Debug.Log($"Pet fed {foodType}. Hunger level: {stats.Hunger}");

        stats.CheckAndDisplayFullStats(); 
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

        stats.CheckAndDisplayFullStats(); 
    }

    public void TakeBath()
    {
        if (stats == null)
        {
            Debug.LogError("Stats reference is missing in TakeBath.");
            return;
        }

        stats.TakeBath(bathAmount);
        Debug.Log($"Pet has taken a bath. Bath value increased by {bathAmount}.");
        
        stats.CheckAndDisplayFullStats(); 
    }

    public void Play()
    {
        if (funCoroutine != null)
        {
            Debug.Log("Pet is already playing.");
            return; 
        }

        funCoroutine = StartCoroutine(FunCoroutine());
    }

    public void Sleep()
    {
        if (sleepCoroutine != null)
        {
            Debug.Log("Pet is already sleeping.");
            return; // Prevent starting another sleep coroutine
        }

        sleepCoroutine = StartCoroutine(SleepCoroutine());
    }

    private IEnumerator SleepCoroutine()
    {
        while (stats.Energy < 100) // Assuming 100 is the max energy
        {
            stats.Rest(sleepAmount); // Increase energy by 3
            Debug.Log($"Pet is sleeping. Energy increased by {sleepAmount}. Current energy: {stats.Energy}");
            stats.CheckAndDisplayFullStats();
            yield return new WaitForSeconds(sleepDuration); // Wait for 3 seconds
        }

        sleepCoroutine = null; // Reset the coroutine reference when done
        Debug.Log("Pet has finished sleeping."); 
    }

    private IEnumerator FunCoroutine()
    {
        while (stats.Fun < 100) // Check if fun is below maximum
        {
            stats.HaveFun(playAmount); // Increase fun
            Debug.Log($"Pet is playing. Fun increased by {playAmount}. Current fun: {stats.Fun}");

            // Check and display full stats after updating fun
            stats.CheckAndDisplayFullStats();

            // Delay before next fun increment
            yield return new WaitForSeconds(playDuration); 
        }

        funCoroutine = null; // Reset the coroutine reference when done
        Debug.Log("Pet has finished playing.");
    }


    public void FeedDogFood() => Feed(FoodType.DogFood);
    public void FeedTurkeyFood() => Feed(FoodType.TurkeyFood);
    public void FeedSteakFood() => Feed(FoodType.SteakFood);

    public void FeedWater() => Drink(DrinkType.Water);
    public void FeedMilk() => Drink(DrinkType.Milk);
    public void FeedMilkShake() => Drink(DrinkType.MilkShake);
}
