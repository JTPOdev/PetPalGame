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


        dogFoodButton.onClick.RemoveAllListeners(); 
        dogFoodButton.onClick.AddListener(() => SelectFood(10));  
        
        turkeyFoodButton.onClick.RemoveAllListeners();
        turkeyFoodButton.onClick.AddListener(() => SelectFood(30));  
        
        steakFoodButton.onClick.RemoveAllListeners();
        steakFoodButton.onClick.AddListener(() => SelectFood(50));   
        
        waterDrinkButton.onClick.RemoveAllListeners();
        waterDrinkButton.onClick.AddListener(() => SelectFood(5));    
        
        milkDrinkButton.onClick.RemoveAllListeners();
        milkDrinkButton.onClick.AddListener(() => SelectFood(15));    
        
        milkShakeDrinkButton.onClick.RemoveAllListeners();
        milkShakeDrinkButton.onClick.AddListener(() => SelectFood(20)); 

        
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
}
