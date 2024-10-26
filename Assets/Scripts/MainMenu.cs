using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Make sure this is included

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI nameDisplayText; // Ensure this is set in the Inspector

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
                SceneManager.LoadScene(SceneData.maindog); // Load main dog scene
            }
            else if (selectedEgg == "cat")
            {
                SceneManager.LoadScene(SceneData.maincat); // Load main cat scene
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
            nameDisplayText.text = $"Welcome back, {playerName}!"; // Display the player's name
        }
    }
}
