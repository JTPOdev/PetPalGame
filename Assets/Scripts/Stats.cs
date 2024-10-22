using System.Collections;
using System.Collections.Generic; // For Dictionary
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour 
{
    public static Stats Instance { get; private set; }
    public Slider bathBar; 
    public Slider funBar;  
    public Slider thirstBar; 
    public Slider hungerBar; 
    public Slider energyBar;

    private const int MAX_BATH = 100;
    private const int MAX_FUN = 100;
    private const int MAX_THIRST = 100;
    private const int MAX_HUNGER = 100;
    private const int MAX_ENERGY = 100;

    private const float DECREASE_INTERVAL = 10f;

    private Dictionary<string, bool> sceneSliderVisibility = new Dictionary<string, bool>
    {
       { "Main Dog", true },
        { "DogBath", true },         
        { "DogBed", true },          
        { "DogPlayground", false },        
        { "PlaygroundScene", false } 
    };

    private void Awake()
    {
        Debug.Log("Awake called for Stats instance.");

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            Debug.Log("Stats instance created.");
        }
        else
        {
            Debug.Log("Destroying duplicate Stats instance.");
            Destroy(gameObject); 
        }

    }


    private void Start()
    {
        InitializeSliders();
        SceneManager.sceneLoaded += OnSceneChanged;
        StartCoroutine(DecreaseStatsOverTime());
    }

    private bool CheckSliders()
    {
        if (bathBar == null || funBar == null || thirstBar == null || hungerBar == null || energyBar == null)
        {
            Debug.LogError("One or more sliders are missing!");
            return false;
        }
        return true;
    }

    private void OnSceneChanged(Scene scene, LoadSceneMode mode)
    {
        SaveSliderValues();

        if (sceneSliderVisibility.ContainsKey(scene.name))
        {
            bool shouldShow = sceneSliderVisibility[scene.name];
            if (shouldShow) ShowSliders();
            else HideSliders();
        }
    }

    public void SaveSliderValues() 
    { 
        if (bathBar != null)
            PlayerPrefs.SetFloat("BathValue", bathBar.value);
        if (funBar != null)
            PlayerPrefs.SetFloat("FunValue", funBar.value);
        if (thirstBar != null)
            PlayerPrefs.SetFloat("ThirstValue", thirstBar.value);
        if (hungerBar != null)
            PlayerPrefs.SetFloat("HungerValue", hungerBar.value);
        if (energyBar != null)
            PlayerPrefs.SetFloat("EnergyValue", energyBar.value);
        PlayerPrefs.Save();
    }

    private void InitializeSliders()
    {
        bathBar = GameObject.Find("BathBar")?.GetComponent<Slider>();
        funBar = GameObject.Find("FunBar")?.GetComponent<Slider>();
        thirstBar = GameObject.Find("ThirstBar")?.GetComponent<Slider>();
        hungerBar = GameObject.Find("HungerBar")?.GetComponent<Slider>();
        energyBar = GameObject.Find("EnergyBar")?.GetComponent<Slider>();

        Debug.Log($"BathBar: {bathBar}, FunBar: {funBar}, ThirstBar: {thirstBar}, HungerBar: {hungerBar}, EnergyBar: {energyBar}");

        if (!CheckSliders()) return;

        LoadSliderValues();
        SetMaxValues();
    }

    private void HideSliders()
    { 
        if (bathBar != null) bathBar.gameObject.SetActive(false);
        if (funBar != null) funBar.gameObject.SetActive(false);
        if (thirstBar != null) thirstBar.gameObject.SetActive(false);
        if (hungerBar != null) hungerBar.gameObject.SetActive(false);
        if (energyBar != null) energyBar.gameObject.SetActive(false);
    }

    private void ShowSliders() 
    { 
        if (bathBar != null) bathBar.gameObject.SetActive(true);
        if (funBar != null) funBar.gameObject.SetActive(true);
        if (thirstBar != null) thirstBar.gameObject.SetActive(true);
        if (hungerBar != null) hungerBar.gameObject.SetActive(true);
        if (energyBar != null) energyBar.gameObject.SetActive(true);
    }

    private void SetMaxValues()
    {
        SetMaxBath(MAX_BATH);
        SetMaxFun(MAX_FUN);
        SetMaxThirst(MAX_THIRST);
        SetMaxHunger(MAX_HUNGER);
        SetMaxEnergy(MAX_ENERGY);
    }

    public void SetMaxBath(int bath) { bathBar.maxValue = bath; bathBar.value = bath; }
    public void SetMaxFun(int fun) { funBar.maxValue = fun; funBar.value = fun; }
    public void SetMaxThirst(int thirst) { thirstBar.maxValue = thirst; thirstBar.value = thirst; }
    public void SetMaxHunger(int hunger) { hungerBar.maxValue = hunger; hungerBar.value = hunger; }
    public void SetMaxEnergy(int energy) { energyBar.maxValue = energy; energyBar.value = energy; }

    // Now accepts variable amounts for more flexibility
    public void TakeBath(int amount, bool isPercentage = false) { ChangeStat(bathBar, MAX_BATH, amount, isPercentage); }
    public void HaveFun(int amount, bool isPercentage = false) { ChangeStat(funBar, MAX_FUN, amount, isPercentage); }
    public void Drink(int amount, bool isPercentage = false) { ChangeStat(thirstBar, MAX_THIRST, amount, isPercentage); }
    public void Eat(int amount, bool isPercentage = false) { ChangeStat(hungerBar, MAX_HUNGER, amount, isPercentage); }
    public void Rest(int amount, bool isPercentage = false) { ChangeStat(energyBar, MAX_ENERGY, amount, isPercentage); }

    private void ChangeStat(Slider slider, int maxValue, int amount, bool isPercentage = false)
    {
        if (slider == null) return;

        int newAmount = isPercentage ? (int)(maxValue * (amount / 100f)) : amount;
        slider.value = Mathf.Clamp(slider.value + newAmount, 0, maxValue);
    }

    private IEnumerator DecreaseStatsOverTime()
    {
        while (true) 
        {
            yield return new WaitForSeconds(DECREASE_INTERVAL);

            DecreaseStat(bathBar, 5);
            DecreaseStat(funBar, 8);
            DecreaseStat(thirstBar, 3);
            DecreaseStat(hungerBar, 5);
            DecreaseStat(energyBar, 4);
        }
    }

    private void DecreaseStat(Slider slider, int decreaseAmount)
    {
        if (slider == null) return;
        slider.value = Mathf.Max(slider.value - decreaseAmount, 0);
    }

    private void LoadSliderValues() 
    {  
        if (bathBar != null && PlayerPrefs.HasKey("BathValue"))
            bathBar.value = PlayerPrefs.GetFloat("BathValue");

        if (funBar != null && PlayerPrefs.HasKey("FunValue"))
            funBar.value = PlayerPrefs.GetFloat("FunValue");

        if (thirstBar != null && PlayerPrefs.HasKey("ThirstValue"))
            thirstBar.value = PlayerPrefs.GetFloat("ThirstValue");

        if (hungerBar != null && PlayerPrefs.HasKey("HungerValue"))
            hungerBar.value = PlayerPrefs.GetFloat("HungerValue");

        if (energyBar != null && PlayerPrefs.HasKey("EnergyValue"))
            energyBar.value = PlayerPrefs.GetFloat("EnergyValue");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneChanged;
    }
}
