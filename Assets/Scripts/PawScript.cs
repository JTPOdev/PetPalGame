using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;

public class PawScript : MonoBehaviour
{
    [SerializeField] RectTransform PawAnim;
    public static PawScript scene1;
    public TMP_InputField inputField;
    public string pet_name;

    public void Awake()
    {
        if (scene1 == null)
        {
            scene1 = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PawAnim.gameObject.SetActive(true);

        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 0);
        LeanTween.scale(PawAnim, Vector3.zero, 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            PawAnim.gameObject.SetActive(false);
        });
    }

    public void openEggSelect()
    {
        AudioManager.instance.Play("ButtonPressed");
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            SceneManager.LoadScene(SceneData.eggselect);
        });
    }

    public void openEggCat()
    {
        StartCoroutine(SubmitPetName(""));
        AudioManager.instance.Play("ButtonPressed");
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            pet_name = inputField.text;
            PlayerPrefs.SetString("PetName", pet_name); // Save the pet name
            SceneManager.LoadScene(SceneData.egghatchcat);
        });
    }

    public void openEggDog()
    {
        StartCoroutine(SubmitPetName(""));
        AudioManager.instance.Play("ButtonPressed");
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            pet_name = inputField.text;
            PlayerPrefs.SetString("PetName", pet_name); 
            SceneManager.LoadScene(SceneData.egghatchdog);
        });
    }
    private IEnumerator SubmitPetName(string type)
    {
        pet_name = inputField.text; // Get the name from the input field
        PlayerPrefs.SetString("PetName", pet_name); // Save the pet name

        // Create form data
        WWWForm form = new WWWForm();
        form.AddField("name", pet_name); // Add name to form data

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/PetPalGame/GetName.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                
                SceneManager.LoadScene(type == "cat" ? SceneData.egghatchcat : SceneData.egghatchdog);
            }
        }
    }
}
