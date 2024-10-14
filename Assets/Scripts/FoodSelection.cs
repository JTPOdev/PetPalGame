using UnityEngine;
using TMPro; 
using UnityEngine.UI; 
public class FoodSelection : MonoBehaviour
{
    public TMP_Text descriptionText;
    public TMP_Text costText;

    public Button DogFoodButton;
    public Button TurkeyButton;
    public Button SteakButton;
    public Button WaterButton;
    public Button MilkButton;
    public Button MilkShakeButton;

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

    // Declare your food items the description and the cost of the food
    private FoodItem dogFood = new FoodItem("Dog Food", "+5 HUNGER", 10);
    private FoodItem turkey = new FoodItem("Turkey", "+15 HUNGER", 30);
    private FoodItem steak = new FoodItem("Steak", "+20 HUNGER", 50);
    private FoodItem water = new FoodItem("Water", "+10 THIRST", 5);
    private FoodItem milk = new FoodItem("Milk", "+15 THIRST", 15);
    private FoodItem milkshake = new FoodItem("Milkshake", "+20 THIRST", 20);


    void Start()
    {
        // Set up button listeners
        DogFoodButton.onClick.AddListener(() => ShowFoodInfo(dogFood));
        TurkeyButton.onClick.AddListener(() => ShowFoodInfo(turkey));
        SteakButton.onClick.AddListener(() => ShowFoodInfo(steak));
        WaterButton.onClick.AddListener(() => ShowFoodInfo(water));
        MilkButton.onClick.AddListener(() => ShowFoodInfo(milk));
        MilkShakeButton.onClick.AddListener(() => ShowFoodInfo(milkshake));
    }

    // Function to display the food information
    void ShowFoodInfo(FoodItem food)
    {
        if (descriptionText != null && costText != null)
        {
            descriptionText.text = food.description;
            costText.text = " " + food.cost.ToString() + " coins";
        }
    }
}
