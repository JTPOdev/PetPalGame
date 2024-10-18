using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("mali teh");
        }
    }

    void Start()
    {
        StartCoroutine(GetName());
    }

    public IEnumerator GetName()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://192.168.100.126/petpalgame/GetName.php"))
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

    public IEnumerator AddPet(string petName)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", petName);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/petpalgame/AddPet.php", form))
        {
            yield return www.SendWebRequest();

               
            Debug.Log("Response Code: " + www.responseCode);
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                    Debug.LogError("Error while adding pet: " + www.error);
            }
            else
            {
                    Debug.Log("Pet added successfully: " + www.downloadHandler.text);
            }
        }
    }


    [System.Serializable]
    public class PetNameList
    {
        public string[] name;
    }
}
