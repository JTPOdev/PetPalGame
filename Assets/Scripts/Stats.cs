using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite; 
using System.Data;
using System.IO;

public class Stats : MonoBehaviour
{
    public float hunger = 100f;
    public float thirst = 100f;
    public float sleep = 100f;
    public float bath = 100f;
    public float fun = 100f;

    public Slider HungerBar;
    public Slider ThirstBar;
    public Slider SleepBar;
    public Slider BathBar;
    public Slider FunBar;

    public float decreaseAmount = 10f; // The amount to decrease
    public float decreaseInterval = 300f; // 5 minutes in seconds

    private string dbPath;
    private int petID = 1; // Assuming the player has one pet with ID = 1, adjust as needed

    void Start()
    {
        // Set up the database path (persistent data path)
        // dbPath = "URI=file:" + Application.persistentDataPath + "/GameDatabase.db";

        // Load stats from the database
        LoadStatsFromDatabase();

        // Update the UI bars with the loaded values
        UpdateBars();

        // Start coroutines to decrease stats
        StartCoroutine(DecreaseHunger());
        StartCoroutine(DecreaseThirst());
        StartCoroutine(DecreaseSleep());
        StartCoroutine(DecreaseBath());
        StartCoroutine(DecreaseFun());
    }

    // Load the stats from the database
    void LoadStatsFromDatabase()
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                // Fetch stats for the pet with PetID = 1 (or any other ID you need)
                command.CommandText = "SELECT * FROM PetStats WHERE PetID = @petID";
                command.Parameters.AddWithValue("@petID", petID);

                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hunger = reader.GetFloat(reader.GetOrdinal("Hunger"));
                        thirst = reader.GetFloat(reader.GetOrdinal("Thirst"));
                        sleep = reader.GetFloat(reader.GetOrdinal("Sleep"));
                        bath = reader.GetFloat(reader.GetOrdinal("Bath"));
                        fun = reader.GetFloat(reader.GetOrdinal("Mood"));
                    }
                }
            }
            connection.Close();
        }
    }

    // Save the stats to the database
    void SaveStatsToDatabase()
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                // Update the pet's stats in the database
                command.CommandText = @"
                    UPDATE PetStats
                    SET Hunger = @hunger, Thirst = @thirst, Sleep = @sleep, Bath = @bath, Mood = @fun
                    WHERE PetID = @petID";
                    
                command.Parameters.AddWithValue("@hunger", hunger);
                command.Parameters.AddWithValue("@thirst", thirst);
                command.Parameters.AddWithValue("@sleep", sleep);
                command.Parameters.AddWithValue("@bath", bath);
                command.Parameters.AddWithValue("@fun", fun);
                command.Parameters.AddWithValue("@petID", petID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    // Periodically save the stats (you can save them when exiting the game, or periodically in the background)
    void OnApplicationQuit()
    {
        SaveStatsToDatabase();
    }

    // Coroutines for decreasing stats
    IEnumerator DecreaseHunger()
    {
        while (hunger > 0)
        {
            yield return new WaitForSeconds(decreaseInterval);
            hunger -= decreaseAmount;
            if (hunger < 0) hunger = 0;
            UpdateBars();
            SaveStatsToDatabase(); // Save to database after updating
        }
    }

    IEnumerator DecreaseThirst()
    {
        while (thirst > 0)
        {
            yield return new WaitForSeconds(decreaseInterval);
            thirst -= decreaseAmount;
            if (thirst < 0) thirst = 0;
            UpdateBars();
            SaveStatsToDatabase(); // Save to database after updating
        }
    }

    IEnumerator DecreaseSleep()
    {
        while (sleep > 0)
        {
            yield return new WaitForSeconds(decreaseInterval);
            sleep -= decreaseAmount;
            if (sleep < 0) sleep = 0;
            UpdateBars();
            SaveStatsToDatabase(); // Save to database after updating
        }
    }

    IEnumerator DecreaseBath()
    {
        while (bath > 0)
        {
            yield return new WaitForSeconds(decreaseInterval);
            bath -= decreaseAmount;
            if (bath < 0) bath = 0;
            UpdateBars();
            SaveStatsToDatabase(); // Save to database after updating
        }
    }

    IEnumerator DecreaseFun()
    {
        while (fun > 0)
        {
            yield return new WaitForSeconds(decreaseInterval);
            fun -= decreaseAmount;
            if (fun < 0) fun = 0;
            UpdateBars();
            SaveStatsToDatabase(); // Save to database after updating
        }
    }

    // Update all UI bars to reflect current stats
    void UpdateBars()
    {
        if (HungerBar != null) HungerBar.value = hunger;
        if (ThirstBar != null) ThirstBar.value = thirst;
        if (SleepBar != null) SleepBar.value = sleep;
        if (BathBar != null) BathBar.value = bath;
        if (FunBar != null) FunBar.value = fun;
    }
}
