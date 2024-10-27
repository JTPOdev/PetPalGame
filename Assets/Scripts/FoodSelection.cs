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
    
    private FoodItem dogFood = new FoodItem("Dog Food", "+5 HUNGER", 10);
    private FoodItem turkey = new FoodItem("Turkey", "+15 HUNGER", 30);
    private FoodItem steak = new FoodItem("Steak", "+20 HUNGER", 50);
    private FoodItem water = new FoodItem("Water", "+10 THIRST", 5);
    private FoodItem milk = new FoodItem("Milk", "+15 THIRST", 15);
    private FoodItem milkshake = new FoodItem("Milkshake", "+20 THIRST", 20);

    void Start()
    {
        InitializeButton(DogFoodButton, dogFood);
        InitializeButton(TurkeyButton, turkey);
        InitializeButton(SteakButton, steak);
        InitializeButton(WaterButton, water);
        InitializeButton(MilkButton, milk);
        InitializeButton(MilkShakeButton, milkshake);
    }


    // Function to initialize button listeners
    void InitializeButton(Button button, FoodItem foodItem)
    {
        button.onClick.RemoveAllListeners();  
        button.onClick.AddListener(() => ShowFoodInfo(foodItem));
        Debug.Log("Listener added to: " + foodItem.itemName);

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

}
