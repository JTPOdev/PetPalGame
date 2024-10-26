using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Include TMP for text

public class BuynFeed : MonoBehaviour
{
    public CoinScript coinScript;
    public bool itemPurchased = false;

    [Header("Hunger Stats")]
    public int hungerLevel = 100;
    public int hungerRestoreAmount = 20;

    [Header("Food and Drinks Buttons")]
    public Button DogFoodButton;
    public Button TurkeyButton;
    public Button SteakButton;
    public Button WaterButton;
    public Button MilkButton;
    public Button MilkShakeButton;

    [Header("Description and Cost Texts")]
    public TMP_Text descriptionText;
    public TMP_Text costText;

    [Header("Pages")]
    public GameObject mainPage;
    public GameObject storePage;
    public GameObject tablePage;

    [Header("Food Images")]
    public GameObject FoodImg1;
    public GameObject FoodImg2;
    public GameObject FoodImg3;
    public GameObject waterDrinkImg;
    public GameObject milkDrinkImg;
    public GameObject milkshakeDrinkImg;

    [Header("Feed Buttons")]
    public Button buyButton;
    public Button feedButtonFood1;
    public Button feedButtonFood2;
    public Button feedButtonFood3;
    public Button feedButtonWater;
    public Button feedButtonMilk;
    public Button feedButtonMilkshake;

    private int selectedFoodCost = 0;
    private FoodItem selectedFoodItem;
    private bool isBuying = false;

    // Define the FoodItem class
    public class FoodItem
    {
        public string itemName;
        public string description;
        public int cost;
        public FoodItem(string name, string desc, int price)
        {
            itemName = name;
            description = desc;
            cost = price;
        }
    }

    // Food items
    private FoodItem dogFood = new FoodItem("Dog Food", "+5 HUNGER", 10);
    private FoodItem turkey = new FoodItem("Turkey", "+15 HUNGER", 30);
    private FoodItem steak = new FoodItem("Steak", "+20 HUNGER", 50);
    private FoodItem water = new FoodItem("Water", "+10 THIRST", 5);
    private FoodItem milk = new FoodItem("Milk", "+15 THIRST", 15);
    private FoodItem milkshake = new FoodItem("Milkshake", "+20 THIRST", 20);

    void Start()
    {
        // Pages turned OFF
        mainPage.SetActive(false);
        storePage.SetActive(true);
        tablePage.SetActive(false);

        // Food Images turned OFF
        FoodImg1.SetActive(false);
        FoodImg2.SetActive(false);
        FoodImg3.SetActive(false);
        waterDrinkImg.SetActive(false);
        milkDrinkImg.SetActive(false);
        milkshakeDrinkImg.SetActive(false);

        // Set up button listeners
        InitializeButton(DogFoodButton, dogFood);
        InitializeButton(TurkeyButton, turkey);
        InitializeButton(SteakButton, steak);
        InitializeButton(WaterButton, water);
        InitializeButton(MilkButton, milk);
        InitializeButton(MilkShakeButton, milkshake);

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(BuyItem);

        // Feed buttons
        feedButtonFood1.onClick.RemoveAllListeners();
        feedButtonFood1.onClick.AddListener(() => FeedPet(selectedFoodItem, FoodImg1));

        feedButtonFood2.onClick.RemoveAllListeners();
        feedButtonFood2.onClick.AddListener(() => FeedPet(selectedFoodItem, FoodImg2));

        feedButtonFood3.onClick.RemoveAllListeners();
        feedButtonFood3.onClick.AddListener(() => FeedPet(selectedFoodItem, FoodImg3));

        feedButtonWater.onClick.RemoveAllListeners();
        feedButtonWater.onClick.AddListener(() => FeedPet(water, waterDrinkImg));

        feedButtonMilk.onClick.RemoveAllListeners();
        feedButtonMilk.onClick.AddListener(() => FeedPet(milk, milkDrinkImg));

        feedButtonMilkshake.onClick.RemoveAllListeners();
        feedButtonMilkshake.onClick.AddListener(() => FeedPet(milkshake, milkshakeDrinkImg));
    }

    void InitializeButton(Button button, FoodItem foodItem)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => ShowFoodInfo(foodItem));
    }

    void ShowFoodInfo(FoodItem food)
    {
        selectedFoodItem = food;
        selectedFoodCost = food.cost;

        if (descriptionText != null && costText != null)
        {
            descriptionText.text = food.description;
            costText.text = "Cost: " + food.cost.ToString();
        }

        // Update UI to reflect selection
        AudioManager.instance.Play("Selected");
        // Update food image or any other UI components as needed
    }

    void BuyItem()
    {
        if (isBuying) return;
        isBuying = true;

        if (coinScript == null)
        {
            Debug.LogError("CoinScript reference is null!");
            isBuying = false;
            return;
        }

        if (coinScript.SpendCoins(selectedFoodCost))
        {
            AudioManager.instance.Play("ButtonPressed");
            itemPurchased = true;
            Debug.Log("Food purchased for: " + selectedFoodCost + " coins.");
        }
        else
        {
            AudioManager.instance.Play("Wrong");
            Debug.Log("Not enough coins to purchase the item.");
        }

        isBuying = false;
    }

    void FeedPet(FoodItem foodItem, GameObject foodImage)
    {
        if (coinScript == null)
        {
            Debug.LogError("CoinScript reference is null!");
            return;
        }

        if (itemPurchased && hungerLevel < 100)
        {
            hungerLevel = Mathf.Min(hungerLevel + hungerRestoreAmount, 100); 
            Debug.Log("Pet fed. Hunger level: " + hungerLevel);
            itemPurchased = false;
            AudioManager.instance.Play("ButtonPressed");
            mainPage.SetActive(true);
            storePage.SetActive(false);
            tablePage.SetActive(true);
            foodImage.SetActive(true);
        }
        else if (hungerLevel >= 100)
        {
            AudioManager.instance.Play("Wrong");
            Debug.Log("Hunger level is already at maximum!");
        }
        else
        {
            AudioManager.instance.Play("Wrong");
            Debug.Log("You need to purchase food first.");
        }
    }
}
