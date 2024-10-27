using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NameScript : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI nameDisplayText;

    private const string PetNameKey = "PetName"; 
    private const int MaxNameLength = 10;

    void Start()
    {
        nameDisplayText.text = "";
        nameInputField.text = "";
        
    }

    public void OnSubmitName()
    {
        Debug.Log("OnSubmitName called");
        Debug.Log("Is NameInput active: " + nameInputField.gameObject.activeSelf);

        string petName = nameInputField.text.Trim();

        if (!string.IsNullOrEmpty(petName))
        {
            if (petName.Length <= MaxNameLength)
            {
                PlayerPrefs.SetString(PetNameKey, petName); // Save the name here
                PlayerPrefs.SetInt("NameEntered", 1); // Mark that the name has been entered
                PlayerPrefs.Save(); // Save PlayerPrefs to disk

                Debug.Log("Starting coroutine to add pet.");
                StartCoroutine(DatabaseManager.Instance.AddPet(petName));

                nameDisplayText.text = $"{petName}";
                nameInputField.text = "";

                SceneManager.LoadScene(SceneData.eggselect);
            }
            else
            {
                nameDisplayText.text = "Name cannot exceed 10 letters.";
                nameInputField.text = "";
                nameInputField.Select();
            }
        }
        else
        {
            AudioManager.instance.Play("Wrong");
            nameDisplayText.text = "Please enter a valid name.";
            nameInputField.text = "";
            nameInputField.Select();
        }
    }
}
