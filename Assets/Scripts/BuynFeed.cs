using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        FoodButton1.onClick.RemoveAllListeners();
        FoodButton1.onClick.AddListener(() => SelectFood(10));
        FoodButton1.onClick.AddListener(FoodImage1);

        FoodButton2.onClick.RemoveAllListeners();
        FoodButton2.onClick.AddListener(() => SelectFood(30));
        FoodButton2.onClick.AddListener(FoodImage2);


        FoodButton3.onClick.RemoveAllListeners();
        FoodButton3.onClick.AddListener(() => SelectFood(50));
        FoodButton3.onClick.AddListener(FoodImage3);

        waterDrinkButton.onClick.RemoveAllListeners();
        waterDrinkButton.onClick.AddListener(() => SelectFood(5));
        waterDrinkButton.onClick.AddListener(waterDrinkImage);

        milkDrinkButton.onClick.RemoveAllListeners();
        milkDrinkButton.onClick.AddListener(() => SelectFood(15));
        milkDrinkButton.onClick.AddListener(milkDrinkImage);

        milkShakeDrinkButton.onClick.RemoveAllListeners();
        milkShakeDrinkButton.onClick.AddListener(() => SelectFood(20));
        milkShakeDrinkButton.onClick.AddListener(milkshakeDrinkImage);


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
    void SelectFood(int itemCost)
    {
        selectedFoodCost = itemCost;
        Debug.Log("Selected food cost: " + selectedFoodCost);
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
