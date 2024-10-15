using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text.RegularExpressions;

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
        string petName = nameInputField.text;

    
        if (!string.IsNullOrEmpty(petName) && Regex.IsMatch(petName, @"^[a-zA-Z]+$"))
        {
            PlayerPrefs.SetString(PetNameKey, petName);
            PlayerPrefs.Save();

            nameDisplayText.text = petName;
            namePopupPanel.SetActive(false);

            SceneManager.LoadScene("Egg Hatch Dog"); 
            SceneManager.LoadScene("Egg Hatch Cat");
        }
        else
        {
           
            nameDisplayText.text = "Please enter a valid name using letters only.";
        }
    }
}
