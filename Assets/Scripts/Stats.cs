using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    private NotificationManager notificationManager; 
    // Global stat values that persist across scenes
    private float bathValue = 100f;
    private float funValue = 100f;
    private float thirstValue = 100f;
    private float hungerValue = 100f;
    private float energyValue = 100f;

    // Public Sliders for UI assignment
    public Slider bathBar;
    public Slider funBar;
    public Slider thirstBar;
    public Slider hungerBar;
    public Slider energyBar;

    // Public properties to access hunger and thirst values
    public float Hunger => hungerValue;
    public float Thirst => thirstValue;

    // Constants for max values
    private const int MAX_BATH = 100;
    private const int MAX_FUN = 100;
    private const int MAX_THIRST = 100;
    private const int MAX_HUNGER = 100;
    private const int MAX_ENERGY = 100;

    private const float DECREASE_INTERVAL = 3f;

    private Dictionary<string, bool> sceneSliderVisibility = new Dictionary<string, bool>
    {
        { "Main Dog", true },
        { "DogBath", true },
        { "DogBed", true },
        { "DogPlayground", true },
    };

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        notificationManager = FindObjectOfType<NotificationManager>();
        SceneManager.sceneLoaded += OnSceneChanged;
        InitializeSliders();
        StartCoroutine(DecreaseStatsOverTime());
    }

    private void CheckAndNotifyStatLevel(string statName, float statValue)
    {
        // Check if the stat is below 30% of its maximum value
        if (statValue <= 0.3f * MAX_BATH && statName == "Bath" || 
            statValue <= 0.3f * MAX_FUN && statName == "Fun" || 
            statValue <= 0.3f * MAX_THIRST && statName == "Thirst" || 
            statValue <= 0.3f * MAX_HUNGER && statName == "Hunger" || 
            statValue <= 0.3f * MAX_ENERGY && statName == "Energy")
        {
            notificationManager.ScheduleNotification(
                "Low Stat Alert",
                $"{statName} is below 30%! Please take care of it soon!",
                0
            );
        }
    }

    private void OnSceneChanged(Scene scene, LoadSceneMode mode)
    {
        InitializeSliders();

        if (sceneSliderVisibility.TryGetValue(scene.name, out bool shouldShow))
        {
            if (shouldShow) ShowSliders();
            else HideSliders();
        }

        UpdateSlidersFromGlobalValues();
    }

    private void InitializeSliders()
    {
        bathBar = GameObject.Find("BathBar")?.GetComponent<Slider>();
        funBar = GameObject.Find("FunBar")?.GetComponent<Slider>();
        thirstBar = GameObject.Find("ThirstBar")?.GetComponent<Slider>();
        hungerBar = GameObject.Find("HungerBar")?.GetComponent<Slider>();
        energyBar = GameObject.Find("EnergyBar")?.GetComponent<Slider>();

        if (bathBar != null) bathBar.maxValue = MAX_BATH;
        if (funBar != null) funBar.maxValue = MAX_FUN;
        if (thirstBar != null) thirstBar.maxValue = MAX_THIRST;
        if (hungerBar != null) hungerBar.maxValue = MAX_HUNGER;
        if (energyBar != null) energyBar.maxValue = MAX_ENERGY;
    }

    private void UpdateSlidersFromGlobalValues()
    {
        if (bathBar != null) bathBar.value = bathValue;
        if (funBar != null) funBar.value = funValue;
        if (thirstBar != null) thirstBar.value = thirstValue;
        if (hungerBar != null) hungerBar.value = hungerValue;
        if (energyBar != null) energyBar.value = energyValue;
    }

    public void TakeBath(int amount) 
    { 
        ChangeGlobalStat(ref bathValue, MAX_BATH, amount);
        UpdateSlidersFromGlobalValues();
    }

    public void HaveFun(int amount) 
    { 
        ChangeGlobalStat(ref funValue, MAX_FUN, amount);
        UpdateSlidersFromGlobalValues();
    }

    public void Drink(int amount) 
    { 
        ChangeGlobalStat(ref thirstValue, MAX_THIRST, amount);
        UpdateSlidersFromGlobalValues();
    }

    public void Eat(int amount) 
    { 
        ChangeGlobalStat(ref hungerValue, MAX_HUNGER, amount);
        UpdateSlidersFromGlobalValues();
    }

    public void Rest(int amount) 
    { 
        ChangeGlobalStat(ref energyValue, MAX_ENERGY, amount);
        UpdateSlidersFromGlobalValues();
    }

    private void ChangeGlobalStat(ref float statValue, int maxValue, int amount)
    {
        statValue = Mathf.Clamp(statValue + amount, 0, maxValue);
    }

    private IEnumerator DecreaseStatsOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(DECREASE_INTERVAL);
            DecreaseGlobalStat(ref bathValue, 5);
            DecreaseGlobalStat(ref funValue, 8);
            DecreaseGlobalStat(ref thirstValue, 3);
            DecreaseGlobalStat(ref hungerValue, 5);
            DecreaseGlobalStat(ref energyValue, 4);

            // Check if any stat is below 30 and notify
            CheckAndNotifyStatLevel("Bath", bathValue);
            CheckAndNotifyStatLevel("Fun", funValue);
            CheckAndNotifyStatLevel("Thirst", thirstValue);
            CheckAndNotifyStatLevel("Hunger", hungerValue);
            CheckAndNotifyStatLevel("Energy", energyValue);

            // Update sliders in the current scene with the decreased values
            UpdateSlidersFromGlobalValues();
        }
    }

    private void DecreaseGlobalStat(ref float statValue, int decreaseAmount)
    {
        statValue = Mathf.Max(statValue - decreaseAmount, 0);
    }

    private void ShowSliders()
    {
        if (bathBar != null) bathBar.gameObject.SetActive(true);
        if (funBar != null) funBar.gameObject.SetActive(true);
        if (thirstBar != null) thirstBar.gameObject.SetActive(true);
        if (hungerBar != null) hungerBar.gameObject.SetActive(true);
        if (energyBar != null) energyBar.gameObject.SetActive(true);
    }

    private void HideSliders()
    {
        if (bathBar != null) bathBar.gameObject.SetActive(false);
        if (funBar != null) funBar.gameObject.SetActive(false);
        if (thirstBar != null) thirstBar.gameObject.SetActive(false);
        if (hungerBar != null) hungerBar.gameObject.SetActive(false);
        if (energyBar != null) energyBar.gameObject.SetActive(false);
    }
}