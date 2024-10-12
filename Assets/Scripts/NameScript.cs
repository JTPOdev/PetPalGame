using UnityEngine;
using TMPro;
using System.Text.RegularExpressions; // Add this to use Regex

public class NameScript : MonoBehaviour
{
    public TMP_InputField nameInputField;   
    public TextMeshProUGUI nameDisplayText;  
    public GameObject namePopupPanel;        

    private const string PetNameKey = "PetName";  

    void Start()
    {
        nameDisplayText.text = "";            
        namePopupPanel.SetActive(true);       
    }

    // Called when the user submits the name
    public void OnSubmitName()
    {
        string petName = nameInputField.text;  // Get the text from the input field.

        // Regular expression to check if the name contains only letters (a-z, A-Z)
        if (!string.IsNullOrEmpty(petName) && Regex.IsMatch(petName, @"^[a-zA-Z]+$"))
        {
            // Save the name to PlayerPrefs (optional, if you want to save it for later)
            PlayerPrefs.SetString(PetNameKey, petName);
            PlayerPrefs.Save();  // Save changes to PlayerPrefs

            // Display the name on the main screen
            nameDisplayText.text = petName;

            // Hide the pop-up after submitting the name
            namePopupPanel.SetActive(false);
        }
        else
        {
            nameDisplayText.text = "Please enter a valid name using letters only."; // Error message if the name is invalid.
        }
    }
}
