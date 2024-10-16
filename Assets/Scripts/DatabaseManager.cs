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
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(GetName());
    }

    IEnumerator GetName()
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
            Debug.Log("Response: " + www.downloadHandler.text);
        }
    }
}


    [System.Serializable]
    public class PetNameList
    {
        public string[] name;
    }
}
