using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class BuynFeed : MonoBehaviour
{
    public CoinScript coinScript;
    public FoodSelection foodSelection;

    public StatsFunction statsFunction;

    public Stats stats;

     public TMP_Text descriptionText;
    public TMP_Text costText;
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

    [Header("Feed and But Buttons")]
    public Button buyButton;
    public Button feedButtonFood1;
    public Button feedButtonFood2;
    public Button feedButtonFood3;
    public Button feedButtonWater;
    public Button feedButtonMilk;
    public Button feedButtonMilkshake;

    private int selectedFoodCost = 0;

    private bool isBuying = false;

    private FoodType selectedFoodType;
    private DrinkType selectedDrinkType;



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
    public enum FoodType
    {
        DogFood,
        Turkey,
        Steak,
    }
    public enum DrinkType
    {
        Water,
        Milk,
        Milkshake
    }



    
    private FoodItem foodImg1 = new FoodItem("Dog Food", "+5 HUNGER", 10);
    private FoodItem foodImg2 = new FoodItem("Turkey", "+15 HUNGER", 30);
    private FoodItem foodImg3 = new FoodItem("Steak", "+20 HUNGER", 50);
    private FoodItem water = new FoodItem("Water", "+10 THIRST", 5);
    private FoodItem milk = new FoodItem("Milk", "+15 THIRST", 15);
    private FoodItem milkshake = new FoodItem("Milkshake", "+20 THIRST", 20);



    void Start()
    {
        // Find and check buttons
        if (FoodButton1 == null || FoodButton2 == null || FoodButton3 == null ||
            waterDrinkButton == null || milkDrinkButton == null || milkShakeDrinkButton == null ||
            buyButton == null || feedButtonFood1 == null || feedButtonFood2 == null || feedButtonFood3 == null
            || feedButtonWater == null || feedButtonMilk == null || feedButtonMilkshake == null)
        {
            Debug.LogError("One or more buttons are not assigned!");
        }

        void ShowFoodInfo(FoodItem food)
        {
            Debug.Log("ShowFoodInfo called for: " + food.itemName);
            if (descriptionText != null && costText != null)
            {
                descriptionText.text = food.description;
                costText.text = "coins: " + food.cost.ToString();
            }
        }

        //Pages turned OFF
        mainPage.SetActive(false);
        storePage.SetActive(true);
        tablePage.SetActive(false);

        //Food Image turned OFF
        FoodImg1.SetActive(false);
        FoodImg2.SetActive(false);
        FoodImg3.SetActive(false);

        //Drink Image Turned OFF
        waterDrinkImg.SetActive(false);
        milkDrinkImg.SetActive(false);
        milkshakeDrinkImg.SetActive(false);

        feedButtonFood1.gameObject.SetActive(false);
        feedButtonFood2.gameObject.SetActive(false);
        feedButtonFood3.gameObject.SetActive(false);
        feedButtonWater.gameObject.SetActive(false);
        feedButtonMilk.gameObject.SetActive(false);
        feedButtonMilkshake.gameObject.SetActive(true);

        FoodButton1.onClick.AddListener(() => { ShowFoodInfo(foodImg1); SelectFood(10, FoodType.DogFood); FoodImage1(); });
        FoodButton2.onClick.AddListener(() => { ShowFoodInfo(foodImg2); SelectFood(30, FoodType.Turkey); FoodImage2(); });
        FoodButton3.onClick.AddListener(() => { ShowFoodInfo(foodImg3); SelectFood(50, FoodType.Steak); FoodImage3(); });
        waterDrinkButton.onClick.AddListener(() => { ShowFoodInfo(water); SelectDrink(water.cost, DrinkType.Water); waterDrinkImage(); });
        milkDrinkButton.onClick.AddListener(() => { ShowFoodInfo(milk); SelectDrink(milk.cost, DrinkType.Milk); milkDrinkImage(); });
        milkShakeDrinkButton.onClick.AddListener(() => { ShowFoodInfo(milkshake); SelectDrink(milkshake.cost, DrinkType.Milkshake); milkshakeDrinkImage(); });



        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(BuyItem);

        feedButtonFood1.onClick.RemoveAllListeners();
        feedButtonFood1.onClick.AddListener(FeedPetFood1);

        feedButtonFood2.onClick.RemoveAllListeners();
        feedButtonFood2.onClick.AddListener(FeedPetFood2);

        feedButtonFood3.onClick.RemoveAllListeners();
        feedButtonFood3.onClick.AddListener(FeedPetFood3);

        feedButtonWater.onClick.RemoveAllListeners();
        feedButtonWater.onClick.AddListener(FeedPetWater);

        feedButtonMilk.onClick.RemoveAllListeners();
        feedButtonMilk.onClick.AddListener(FeedPetMilk);

        feedButtonMilkshake.onClick.RemoveAllListeners();
        feedButtonMilkshake.onClick.AddListener(FeedPetMilkshake);
    }

    // Select the food item and set its cost
    void SelectFood(int itemCost, FoodType foodType)
    {
        selectedFoodCost = itemCost;
        selectedFoodType = foodType; // Set selected food type
        Debug.Log("Selected food cost: " + selectedFoodCost);
    }

    void SelectDrink(int itemCost, DrinkType drinkType)
    {
        selectedFoodCost = itemCost;  
        selectedDrinkType = drinkType;  
        Debug.Log("Selected drink cost: " + selectedFoodCost);
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

        if (coinScript.SpendCoins(selectedFoodCost))  // Deduct the selected food cost from coins
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

    // When Feed button is clicked
    public void FeedPetFood1()
    {
        if (coinScript == null)
        {
            Debug.LogError("CoinScript reference is null!");
            return;
        }

        if (itemPurchased && hungerLevel < 100)  // Ensure item was purchased and pet can be fed
        {
            hungerLevel = Mathf.Min(hungerLevel + hungerRestoreAmount, 100);  // Restore hunger
            Debug.Log("Pet fed. Hunger level: " + hungerLevel);
            itemPurchased = false;
            AudioManager.instance.Play("ButtonPressed");
            mainPage.SetActive(true);  //  Opens mainpage scene
            storePage.SetActive(false);  //  Closes storepage scene
            tablePage.SetActive(true);
            FoodImg1.SetActive(true);
            stats.Eat((int)selectedFoodType);
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

    public void FeedPetFood2()
    {
        if (coinScript == null)
        {
            Debug.LogError("CoinScript reference is null!");
            return;
        }

        if (itemPurchased && hungerLevel < 100)  // Ensure item was purchased and pet can be fed
        {
            hungerLevel = Mathf.Min(hungerLevel + hungerRestoreAmount, 100);  // Restore hunger
            Debug.Log("Pet fed. Hunger level: " + hungerLevel);
            itemPurchased = false;
            AudioManager.instance.Play("ButtonPressed");
            mainPage.SetActive(true);  //  Opens mainpage scene
            storePage.SetActive(false);  //  Closes storepage scene
            tablePage.SetActive(true);
            FoodImg2.SetActive(true);
            stats.Eat((int)selectedFoodType);

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

    public void FeedPetFood3()
    {
        if (coinScript == null)
        {
            Debug.LogError("CoinScript reference is null!");
            return;
        }

        if (itemPurchased && hungerLevel < 100)  // Ensure item was purchased and pet can be fed
        {
            hungerLevel = Mathf.Min(hungerLevel + hungerRestoreAmount, 100);  // Restore hunger
            Debug.Log("Pet fed. Hunger level: " + hungerLevel);
            itemPurchased = false;
            AudioManager.instance.Play("ButtonPressed");
            mainPage.SetActive(true);  //  Opens mainpage scene
            storePage.SetActive(false);  //  Closes storepage scene
            tablePage.SetActive(true);
            FoodImg3.SetActive(true);
            stats.Eat((int)selectedFoodType);

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

    public void FeedPetWater()
    {
        if (coinScript == null)
        {
            Debug.LogError("CoinScript reference is null!");
            return;
        }

        if (itemPurchased && hungerLevel < 100)  // Ensure item was purchased and pet can be fed
        {
            hungerLevel = Mathf.Min(hungerLevel + hungerRestoreAmount, 100);  // Restore hunger
            Debug.Log("Pet fed. Hunger level: " + hungerLevel);
            itemPurchased = false;
            AudioManager.instance.Play("ButtonPressed");
            mainPage.SetActive(true);  //  Opens mainpage scene
            storePage.SetActive(false);  //  Closes storepage scene
            tablePage.SetActive(true);
            waterDrinkImg.SetActive(true);
            stats.Drink((int)selectedDrinkType); 

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

    public void FeedPetMilk()
    {
        if (coinScript == null)
        {
            Debug.LogError("CoinScript reference is null!");
            return;
        }

        if (itemPurchased && hungerLevel < 100)  // Ensure item was purchased and pet can be fed
        {
            hungerLevel = Mathf.Min(hungerLevel + hungerRestoreAmount, 100);  // Restore hunger
            Debug.Log("Pet fed. Hunger level: " + hungerLevel);
            itemPurchased = false;
            AudioManager.instance.Play("ButtonPressed");
            mainPage.SetActive(true);  //  Opens mainpage scene
            storePage.SetActive(false);  //  Closes storepage scene
            tablePage.SetActive(true);
            milkDrinkImg.SetActive(true);
            stats.Drink((int)selectedDrinkType); 
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

    public void FeedPetMilkshake()
    {
        if (coinScript == null)
        {
            Debug.LogError("CoinScript reference is null!");
            return;
        }

        if (itemPurchased && hungerLevel < 100)  // Ensure item was purchased and pet can be fed
        {
            hungerLevel = Mathf.Min(hungerLevel + hungerRestoreAmount, 100);  // Restore hunger
            Debug.Log("Pet fed. Hunger level: " + hungerLevel);
            itemPurchased = false;
            AudioManager.instance.Play("ButtonPressed");
            mainPage.SetActive(true);  //  Opens mainpage scene
            storePage.SetActive(false);  //  Closes storepage scene
            tablePage.SetActive(true);
            milkshakeDrinkImg.SetActive(true);
           stats.Drink((int)selectedDrinkType); 
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

    // Activate Image
    public void FoodImage1()
    {
        AudioManager.instance.Play("Selected");
        FoodImg1.SetActive(false);
        feedButtonFood1.gameObject.SetActive(true);
        feedButtonFood2.gameObject.SetActive(false);
        feedButtonFood3.gameObject.SetActive(false);
        feedButtonWater.gameObject.SetActive(false);
        feedButtonMilk.gameObject.SetActive(false);
        feedButtonMilkshake.gameObject.SetActive(false);
    }

    public void FoodImage2()
    {
        AudioManager.instance.Play("Selected");
        FoodImg2.SetActive(false);
        feedButtonFood1.gameObject.SetActive(false);
        feedButtonFood2.gameObject.SetActive(true);
        feedButtonFood3.gameObject.SetActive(false);
        feedButtonWater.gameObject.SetActive(false);
        feedButtonMilk.gameObject.SetActive(false);
        feedButtonMilkshake.gameObject.SetActive(false);
    }

    public void FoodImage3()
    {
        AudioManager.instance.Play("Selected");
        FoodImg3.SetActive(false);
        feedButtonFood1.gameObject.SetActive(false);
        feedButtonFood2.gameObject.SetActive(false);
        feedButtonFood3.gameObject.SetActive(true);
        feedButtonWater.gameObject.SetActive(false);
        feedButtonMilk.gameObject.SetActive(false);
        feedButtonMilkshake.gameObject.SetActive(false);
    }

    public void waterDrinkImage()
    {
        AudioManager.instance.Play("Selected");
        waterDrinkImg.SetActive(false);
        feedButtonFood1.gameObject.SetActive(false);
        feedButtonFood2.gameObject.SetActive(false);
        feedButtonFood3.gameObject.SetActive(false);
        feedButtonWater.gameObject.SetActive(true);
        feedButtonMilk.gameObject.SetActive(false);
        feedButtonMilkshake.gameObject.SetActive(false);
    }

    public void milkDrinkImage()
    {
        AudioManager.instance.Play("Selected");
        milkDrinkImg.SetActive(false);
        feedButtonFood1.gameObject.SetActive(false);
        feedButtonFood2.gameObject.SetActive(false);
        feedButtonFood3.gameObject.SetActive(false);
        feedButtonWater.gameObject.SetActive(false);
        feedButtonMilk.gameObject.SetActive(true);
        feedButtonMilkshake.gameObject.SetActive(false);
    }

    public void milkshakeDrinkImage()
    {
        AudioManager.instance.Play("Selected");
        milkshakeDrinkImg.SetActive(false);
        feedButtonFood1.gameObject.SetActive(false);
        feedButtonFood2.gameObject.SetActive(false);
        feedButtonFood3.gameObject.SetActive(false);
        feedButtonWater.gameObject.SetActive(false);
        feedButtonMilk.gameObject.SetActive(false);
        feedButtonMilkshake.gameObject.SetActive(true);
    }
}