using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] RectTransform PawAnim;
    private void Start()
    {
        CheckPlayerProgress();
    }

    public void PlayGame()
    {
        // Check if the player has entered a name and selected an egg
        if (PlayerProgress.HasName())
        {
            string selectedEgg = PlayerProgress.GetSelectedEgg();
            if (selectedEgg == "dog")
            {
                AudioManager.instance.Play("ButtonPressed");
                PawAnim.gameObject.SetActive(true);
                LeanTween.scale(PawAnim, Vector3.zero, 0f);
                LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
                {
                    AudioManager.instance.Stop("HomeBGaudio");
                    AudioManager.instance.Play("MainBGaudio");
                    SceneManager.LoadScene(SceneData.maindog); // Load main dog scene
                });
            }
            else if (selectedEgg == "cat")
            {
                AudioManager.instance.Play("ButtonPressed");
                PawAnim.gameObject.SetActive(true);
                LeanTween.scale(PawAnim, Vector3.zero, 0f);
                LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
                {
                    AudioManager.instance.Stop("HomeBGaudio");
                    AudioManager.instance.Play("MainBGaudio");
                    SceneManager.LoadScene(SceneData.maincat); // Load main cat scene
                });
            }
            else
            {
                Debug.Log("No egg selected. Please select an egg first.");
            }
        }
        else
        {
            Debug.Log("No name entered. Please enter a name first.");
            SceneManager.LoadScene(SceneData.namescene); // Load the name input scene
        }
    }

    private void CheckPlayerProgress()
    {
        if (PlayerProgress.HasName())
        {
            string selectedEgg = PlayerProgress.GetSelectedEgg();
            string playerName = PlayerPrefs.GetString("PetName", "No name found"); // Retrieve the player's name here
        }
    }
}
