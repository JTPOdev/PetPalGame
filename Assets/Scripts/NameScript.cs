// using System.Collections;
// using TMPro;
// using UnityEngine;
// using UnityEngine.Networking;

// public class NameScript : MonoBehaviour
// {
//     public TextMeshProUGUI display_pet_name;

//     public void Awake()
//     {
//          display_pet_name.text = PawScript.scene1.pet_name; 
//     }

//     void Start()
//     {
//         StartCoroutine(GetPetNames());
//     }

//     IEnumerator GetPetNames()
//     {
//         using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/PetPalGame/GetName.php"))
//         {
//             yield return www.SendWebRequest();

//             if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
//             {
//                 Debug.LogError("Error: " + www.error);
//             }
//             else
//             {
//                 // JSON response
//                 string jsonResponse = www.downloadHandler.text;
//                 NameList petNamesList = JsonUtility.FromJson<NameList>(jsonResponse);


//                 if (petNamesList.names.Length > 0)
//                 {
//                     display_pet_name.text = petNamesList.names[20]; 
//                 }
//                 else
//                 {
//                     display_pet_name.text = "No names found.";
//                 }
//             }
//         }
//     }
// }

// // Create the NameList class to hold the JSON response
// [System.Serializable]
// public class NameList
// {
//     public string[] names;
// }
