using System.Collections;
using TMPro;
<<<<<<< Updated upstream
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
=======
using UnityEngine.Networking;
using System.Collections;
>>>>>>> Stashed changes

public class NameScript : MonoBehaviour
{
    public TextMeshProUGUI display_pet_name;
    public GameObject popupPanel; // Reference to the popup panel

    public void Awake()
    {
        display_pet_name.text = PawScript.scene1.pet_name;
        popupPanel.SetActive(false); // Hide the popup at the start
    }

    void Start()
    {
<<<<<<< Updated upstream
        StartCoroutine(GetPetNames());
=======
        // Load the previously saved pet name if it exists
        if (PlayerPrefs.HasKey(PetNameKey))
        {
            string savedName = PlayerPrefs.GetString(PetNameKey);
            nameInputField.text = ""; 
        }
        else
        {
            nameDisplayText.text = "";            
        }
        namePopupPanel.SetActive(true);     
        StartCoroutine(GetPetNames());  
>>>>>>> Stashed changes
    }

    IEnumerator GetPetNames()
    {
<<<<<<< Updated upstream
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/PetPalGame/GetName.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                // JSON response
                string jsonResponse = www.downloadHandler.text;
                NameList petNamesList = JsonUtility.FromJson<NameList>(jsonResponse);

                if (petNamesList.names.Length > 0)
                {
                    display_pet_name.text = petNamesList.names[20];
                    popupPanel.SetActive(true); 
                }
                else
                {
                    display_pet_name.text = "No names found.";
                    popupPanel.SetActive(true); 
                }
            }
        }
    }

    
    public void ClosePopup()
    {
        popupPanel.SetActive(false); // Hide the popup
=======
        string petName = nameInputField.text.Trim(); // Trim to remove leading/trailing spaces

        if (!string.IsNullOrEmpty(petName) && IsValidName(petName))
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
            Debug.LogWarning("Invalid name entered. Please use only letters."); 
           
        }
>>>>>>> Stashed changes
    }

    private bool IsValidName(string name)
    {
        
        foreach (char c in name)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                return false; 
            }
        }
        return true;
    }
        IEnumerator GetPetNames()
        {
            using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/petpal/progress.php"))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogError("Error: " + www.error);
                }
                else
                {
                    
                    string jsonResponse = www.downloadHandler.text;
                    NameList petNamesList = JsonUtility.FromJson<NameList>(jsonResponse);


                    if (petNamesList.names.Length > 0)
                    {
                        nameDisplayText.text = petNamesList.names[20]; 
                    }
                    else
                    {
                        nameDisplayText.text = "No names found.";
                    }
                }
        }
}
    [System.Serializable]
    public class NameList
    {
        public string[] names;
    }
}


[System.Serializable]
public class NameList
{
    public string[] names;
}
