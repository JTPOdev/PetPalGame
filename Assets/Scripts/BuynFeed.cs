using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuynFeed : MonoBehaviour
{
    public CoinScript coinScript; 
    public bool itemPurchased = false;

    public int hungerLevel = 100;  
    public int hungerRestoreAmount = 20; 

    public Button dogFoodButton;  
    public Button turkeyFoodButton;  
    public Button steakFoodButton;  
    public Button waterDrinkButton;  
    public Button milkDrinkButton;  
    public Button milkShakeDrinkButton;

    public GameObject mainPage;
    public GameObject storePage;
    public GameObject tablePage;

    public GameObject dogFoodImg;
    public GameObject turkeyFoodImg;
    public GameObject steakFoodImg;
    public GameObject waterDrinkImg;
    public GameObject milkDrinkImg;
    public GameObject milkshakeDrinkImg;

    public Button buyButton;  
    public Button feedButton;  

    private int selectedFoodCost = 0;
    private bool isBuying = false;  

    void Start()
    {
        // Find and check buttons
        if (dogFoodButton == null || turkeyFoodButton == null || steakFoodButton == null ||
            waterDrinkButton == null || milkDrinkButton == null || milkShakeDrinkButton == null ||
            buyButton == null || feedButton == null)
        {
            Debug.LogError("One or more buttons are not assigned!");
        }

        //Pages turned OFF
        mainPage.SetActive(false);
        storePage.SetActive(true);
        tablePage.SetActive(false);

        //Food Image turned OFF
        dogFoodImg.SetActive(false);
        turkeyFoodImg.SetActive(false);
        steakFoodImg.SetActive(false);

        //Drink Image Turned OFF
        waterDrinkImg.SetActive(false);
        milkDrinkImg.SetActive(false);
        milkshakeDrinkImg.SetActive(false);

        dogFoodButton.onClick.RemoveAllListeners(); 
        dogFoodButton.onClick.AddListener(() => SelectFood(10));
        dogFoodButton.onClick.AddListener(dogFoodImage);

        turkeyFoodButton.onClick.RemoveAllListeners();
        turkeyFoodButton.onClick.AddListener(() => SelectFood(30));
        turkeyFoodButton.onClick.AddListener(turkeyFoodImage);


        steakFoodButton.onClick.RemoveAllListeners();
        steakFoodButton.onClick.AddListener(() => SelectFood(50));
        steakFoodButton.onClick.AddListener(steakFoodImage);

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
        
        feedButton.onClick.RemoveAllListeners();
        feedButton.onClick.AddListener(FeedPet);
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
            itemPurchased = true;
            Debug.Log("Food purchased for: " + selectedFoodCost + " coins.");
        }
        else
        {
            Debug.Log("Not enough coins to purchase the item.");
        }

        isBuying = false;  
    }

    // When Feed button is clicked
    public void FeedPet()
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

            mainPage.SetActive(true);  //  Opens mainpage scene
            storePage.SetActive(false);  //  Closes storepage scene
            tablePage.SetActive(true);
        }
        else if (hungerLevel >= 100)
        {
            Debug.Log("Hunger level is already at maximum!");
        }
        else
        {
            Debug.Log("You need to purchase food first.");
        }
    }

    // Activate Image
    public void dogFoodImage()
    {
        dogFoodImg.SetActive(true);
    }

    public void turkeyFoodImage()
    {
        turkeyFoodImg.SetActive(true);
    }

    public void steakFoodImage()
    {
        steakFoodImg.SetActive(true);
    }

    public void waterDrinkImage()
    {
        waterDrinkImg.SetActive(true);
    }

    public void milkDrinkImage()
    {
        milkDrinkImg.SetActive(true);
    }

    public void milkshakeDrinkImage()
    {
        milkshakeDrinkImg.SetActive(true);
    }
}
