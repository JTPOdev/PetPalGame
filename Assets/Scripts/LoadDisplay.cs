using UnityEngine;
using TMPro;

public class LoadDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private TMP_Text coinText;

    private const string PetNameKey = "PetName";  

    void Start()
    {
        DisplaySavedValues();
    }

    private void DisplaySavedValues()
    {
        string playerName = PlayerPrefs.GetString(PetNameKey, "No Name");  
        int coinStore = PlayerPrefs.GetInt("StoringCoins", 0); 

        // Display values in TMP fields
        NameText.text = $"NAME: {playerName}";
        coinText.text = $"{coinStore}";
    }
}
