using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Networking;

public class NameScript : MonoBehaviour
{
    public TMP_InputField nameInputField;   
    public TextMeshProUGUI nameDisplayText;      

    private const string PetNameKey = "PetName";  

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

        if (!string.IsNullOrEmpty(petName) && Regex.IsMatch(petName, @"^[a-zA-Z]+$"))
        {
            PlayerPrefs.SetString(PetNameKey, petName);
            PlayerPrefs.Save();

            Debug.Log("Starting coroutine to add pet.");
            StartCoroutine(DatabaseManager.Instance.AddPet(petName));

            nameDisplayText.text = $"{petName}";  
            nameInputField.text = ""; 

            SceneManager.LoadScene(SceneData.eggselect);
        }
        else
        {
            nameDisplayText.text = "Please enter a valid name using letters only.";
            nameInputField.text = ""; 
            nameInputField.Select();
        }
    }

    public IEnumerator GetName()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://172.20.10.3/petpalgame/GetName.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                Debug.Log("Response: " + www.downloadHandler.text);
            }
        }
    }
}
