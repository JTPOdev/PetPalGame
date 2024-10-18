using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.Networking; // Ensure this is included

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

    public void OnSubmitName()
    {
        Debug.Log("OnSubmitName called");
        Debug.Log("Is NameInput active: " + nameInputField.gameObject.activeSelf);
        
        string petName = nameInputField.text.Trim(); // Trim whitespace

        // Validate input
        if (!string.IsNullOrEmpty(petName) && Regex.IsMatch(petName, @"^[a-zA-Z]+$"))
        {
            PlayerPrefs.SetString(PetNameKey, petName);
            PlayerPrefs.Save();

            Debug.Log("Starting coroutine to add pet.");
            StartCoroutine(DatabaseManager.Instance.AddPet(petName));

            nameDisplayText.text = $"Pet Name: {petName}"; 
            namePopupPanel.SetActive(false); 
            nameInputField.text = ""; 

        }
        else
        {
            // Show feedback for invalid input
            nameDisplayText.text = "Please enter a valid name using letters only.";
            nameInputField.text = ""; 
            nameInputField.Select();
        }
    }
}
