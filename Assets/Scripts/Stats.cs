using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    // Global stat values that persist across scenes
    private float bathValue;
    private float funValue;
    private float thirstValue;
    private float hungerValue;
    private float energyValue;

    // Public Sliders for UI assignment
    public Slider bathBar;
    public Slider funBar;
    public Slider thirstBar;
    public Slider hungerBar;
    public Slider energyBar;

    // Public properties to access hunger and thirst values
    public float Hunger => hungerValue;
    public float Thirst => thirstValue;
    public float Energy => energyValue;
    public float Fun => funValue;

    [SerializeField] private Image Image;

    private const int MAX_BATH = 100;
    private const int MAX_FUN = 100;
    private const int MAX_THIRST = 100;
    private const int MAX_HUNGER = 100;
    private const int MAX_ENERGY = 100;

    private const float DECREASE_INTERVAL = 15f;

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
        LoadStats(); // Load the values when the game starts
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneChanged;
        InitializeSliders();
        StartCoroutine(DecreaseStatsOverTime());
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
        SaveStats(); // Save after taking a bath
    }

    public void HaveFun(int amount)
    {
        ChangeGlobalStat(ref funValue, MAX_FUN, amount);
        UpdateSlidersFromGlobalValues();
        SaveStats(); // Save after having fun
    }


    public void Drink(int amount) 
    { 
        ChangeGlobalStat(ref thirstValue, MAX_THIRST, amount);
        UpdateSlidersFromGlobalValues();
        SaveStats(); // Save after drinking

        Debug.Log($"Drinking amount: {amount}");
        Debug.Log($"New thirst value: {thirstValue}");
    }

    public void Eat(int amount) 
    { 
        ChangeGlobalStat(ref hungerValue, MAX_HUNGER, amount);
        UpdateSlidersFromGlobalValues();
        SaveStats(); // Save after eating

        Debug.Log($"Eating amount: {amount}");
        Debug.Log($"New hunger value: {hungerValue}"); 
    }

    public void Rest(int amount) 
    { 
        ChangeGlobalStat(ref energyValue, MAX_ENERGY, amount);
        UpdateSlidersFromGlobalValues();
        SaveStats(); // Save after resting
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
            DecreaseGlobalStat(ref energyValue, 9);

            UpdateSlidersFromGlobalValues();
            SaveStats(); // Save after decreasing stats

            CheckAndDisplayImg(); //dISPLAY IMG
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

    public void CheckAndDisplayFullStats()
    {
        if (bathValue >= MAX_BATH)
            DisplayFullStat("Bath is full!");
        if (funValue >= MAX_FUN)
            DisplayFullStat("Fun is full!");
        if (thirstValue >= MAX_THIRST)
            DisplayFullStat("Thirst is full!");
        if (hungerValue >= MAX_HUNGER)
            DisplayFullStat("Hunger is full!");
        if (energyValue >= MAX_ENERGY)
            DisplayFullStat("Energy is full!");
    }

    private void DisplayFullStat(string message)
    {
        Debug.Log(message);
    }

    private void SaveStats()
    {
        PlayerPrefs.SetFloat("BathValue", bathValue);
        PlayerPrefs.SetFloat("FunValue", funValue);
        PlayerPrefs.SetFloat("ThirstValue", thirstValue);
        PlayerPrefs.SetFloat("HungerValue", hungerValue);
        PlayerPrefs.SetFloat("EnergyValue", energyValue);
        PlayerPrefs.Save(); // Ensure data is saved
    }

    private void LoadStats()
    {
        bathValue = PlayerPrefs.GetFloat("BathValue", MAX_BATH);
        funValue = PlayerPrefs.GetFloat("FunValue", MAX_FUN);
        thirstValue = PlayerPrefs.GetFloat("ThirstValue", MAX_THIRST);
        hungerValue = PlayerPrefs.GetFloat("HungerValue", MAX_HUNGER);
        energyValue = PlayerPrefs.GetFloat("EnergyValue", MAX_ENERGY);

        UpdateSlidersFromGlobalValues();
    }

    //FUNCTION TO THE IMAGE, 
    private void CheckAndDisplayImg()
    {
        bool showWarning = bathValue <= MAX_BATH / 2 || funValue <= MAX_FUN / 2 || thirstValue <= MAX_THIRST / 2 || hungerValue <= MAX_HUNGER / 2 || energyValue <= MAX_ENERGY / 2;

        if (Image != null)
        {
            Image.gameObject.SetActive(showWarning);
        }
    }
}
