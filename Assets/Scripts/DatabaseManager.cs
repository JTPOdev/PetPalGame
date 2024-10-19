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
            Debug.LogError("Instance already exists");
        }
    }

    void Start()
    {
        StartCoroutine(GetName());
    }

    public IEnumerator GetName()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://192.168.100.126/petpalgame/GetName.php"))
        {
            // Bypass SSL certificate validation
            www.certificateHandler = new BypassCertificateHandler();
            
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

        using (UnityWebRequest www = UnityWebRequest.Post("https://192.168.100.126/petpalgame/AddPet.php", form))
        {
            // Bypass SSL certificate validation
            www.certificateHandler = new BypassCertificateHandler();

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

    // CertificateHandler class to bypass SSL validation (for development only)
    public class BypassCertificateHandler : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            // Always return true to bypass SSL validation (for development only)
            return true;
        }
    }

    [System.Serializable]
    public class PetNameList
    {
        public string[] name;
    }
}
