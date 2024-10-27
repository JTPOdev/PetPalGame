using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuynFeed : MonoBehaviour
{
    public CoinScript coinScript;
    public bool itemPurchased = false;

    [Header("Hunger Stats")]
    public int hungerLevel = 100;
    public int hungerRestoreAmount = 20;

    [Header("Food and Drinks Buttons")]
    public Button FoodButton1;
    public Button FoodButton2;
    public Button FoodButton3;
    public Button waterDrinkButton;
    public Button milkDrinkButton;
    public Button milkShakeDrinkButton;

    [Header("Pages")]
    public GameObject mainPage;
    public GameObject storePage;
    public GameObject tablePage;

    [Header("Food Image")]
    public GameObject FoodImg1;
    public GameObject FoodImg2;
    public GameObject FoodImg3;

    [Header("Drink Image")]
    public GameObject waterDrinkImg;
    public GameObject milkDrinkImg;
    public GameObject milkshakeDrinkImg;

    [Header("Feed and Buy Buttons")]
    public Button buyButton;
    public Button feedButtonFood1;
    public Button feedButtonFood2;
    public Button feedButtonFood3;
    public Button feedButtonWater;
    public Button feedButtonMilk;
    public Button feedButtonMilkshake;

    // New variables for food selection
    public TMP_Text descriptionText; // Reference to the description text
    public TMP_Text costText;         // Reference to the cost text

    private int selectedFoodCost = 0;
    private bool isBuying = false;

    public class FoodItem
    {
        public string itemName;
        public string description;
        public int cost;

        public int hungerRestoreAmount;
        public FoodItem(string name, string desc, int price)
        {
            itemName = name;
            description = desc;
            cost = price;
        }
    }

    // Food items information
    private FoodItem[] foodItems = {
        new FoodItem("Dog Food", "+5 HUNGER", 10),
        new FoodItem("Turkey", "+15 HUNGER", 30),
        new FoodItem("Steak", "+20 HUNGER", 50),
        new FoodItem("Water", "+10 THIRST", 5),
        new FoodItem("Milk", "+15 THIRST", 15),
        new FoodItem("Milkshake", "+20 THIRST", 20)
    };

    void Start()
    {
        ValidateButtons();
        SetInitialStates();
        SetButtonListeners();
    }

    void ValidateButtons()
    {
        if (FoodButton1 == null || FoodButton2 == null || FoodButton3 == null ||
            waterDrinkButton == null || milkDrinkButton == null || milkShakeDrinkButton == null ||
            buyButton == null || feedButtonFood1 == null || feedButtonFood2 == null || feedButtonFood3 == null ||
            feedButtonWater == null || feedButtonMilk == null || feedButtonMilkshake == null)
        {
            Debug.LogError("One or more buttons are not assigned!");
        }
    }

    void SetInitialStates()
    {
        mainPage.SetActive(false);
        storePage.SetActive(true);
        tablePage.SetActive(false);

        FoodImg1.SetActive(false);
        FoodImg2.SetActive(false);
        FoodImg3.SetActive(false);
        waterDrinkImg.SetActive(false);
        milkDrinkImg.SetActive(false);
        milkshakeDrinkImg.SetActive(false);

        // Set initial button visibility
        feedButtonFood1.gameObject.SetActive(false);
        feedButtonFood2.gameObject.SetActive(false);
        feedButtonFood3.gameObject.SetActive(false);
        feedButtonWater.gameObject.SetActive(false);
        feedButtonMilk.gameObject.SetActive(false);
        feedButtonMilkshake.gameObject.SetActive(true);
    }

    void SetButtonListeners()
    {
        // Food buttons listeners
        FoodButton1.onClick.AddListener(() => SelectFood(0, FoodImg1, feedButtonFood1));
        FoodButton2.onClick.AddListener(() => SelectFood(1, FoodImg2, feedButtonFood2));
        FoodButton3.onClick.AddListener(() => SelectFood(2, FoodImg3, feedButtonFood3));
        AudioManager.instance.Play("Selected");

        // Drink buttons listeners
        waterDrinkButton.onClick.AddListener(() => SelectFood(3, waterDrinkImg, feedButtonWater));
        milkDrinkButton.onClick.AddListener(() => SelectFood(4, milkDrinkImg, feedButtonMilk));
        milkShakeDrinkButton.onClick.AddListener(() => SelectFood(5, milkshakeDrinkImg, feedButtonMilkshake));
        AudioManager.instance.Play("Selected");

        // Buy and feed buttons listeners
        buyButton.onClick.AddListener(BuyItem);
        feedButtonFood1.onClick.AddListener(() => FeedPet(0));
        feedButtonFood2.onClick.AddListener(() => FeedPet(1));
        feedButtonFood3.onClick.AddListener(() => FeedPet(2));
        feedButtonWater.onClick.AddListener(() => FeedPet(3));
        feedButtonMilk.onClick.AddListener(() => FeedPet(4));
        feedButtonMilkshake.onClick.AddListener(() => FeedPet(5));
    }

    void SelectFood(int itemIndex, GameObject foodImage, Button feedButton)
    {
        if (itemIndex >= 0 && itemIndex < foodItems.Length)
        {
            selectedFoodCost = foodItems[itemIndex].cost;
            UpdateFoodInfo(itemIndex);
            foodImage.SetActive(true);
            feedButton.gameObject.SetActive(true);
            AudioManager.instance.Play("Selected");
            Debug.Log("Selected food cost: " + selectedFoodCost);
        }
    }

    void UpdateFoodInfo(int itemIndex)
    {
        if (descriptionText != null && costText != null)
        {
            descriptionText.text = foodItems[itemIndex].description;
            costText.text = "Coins: " + foodItems[itemIndex].cost.ToString();
        }
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

    public void FeedPet(int itemIndex)
    {
        if (coinScript == null)
        {
            Debug.LogError("CoinScript reference is null!");
            return;
        }

        if (itemPurchased && hungerLevel < 100)
        {
            hungerLevel = Mathf.Min(hungerLevel + foodItems[itemIndex].hungerRestoreAmount, 100);
            Debug.Log("Pet fed. Hunger level: " + hungerLevel);
            itemPurchased = false;
            AudioManager.instance.Play("ButtonPressed");
            mainPage.SetActive(true);
            storePage.SetActive(false);
            tablePage.SetActive(true);
            // Activate the corresponding image based on the itemIndex
            ActivateFoodImage(itemIndex);
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

    void ActivateFoodImage(int itemIndex)
    {
        FoodImg1.SetActive(itemIndex == 0);
        FoodImg2.SetActive(itemIndex == 1);
        FoodImg3.SetActive(itemIndex == 2);
        waterDrinkImg.SetActive(itemIndex == 3);
        milkDrinkImg.SetActive(itemIndex == 4);
        milkshakeDrinkImg.SetActive(itemIndex == 5);
    }
}
