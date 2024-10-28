using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public Button YesButton;

    private void Start()
    {
        if (YesButton != null)
        {
            YesButton.onClick.AddListener(ResetGameData);
            Debug.Log("Listener added to the New Game button.");
        }
        else
        {
            Debug.LogError("New Game Button is not assigned in the Inspector!");
        }
    }

    public void ResetGameData()
    {
        Debug.Log("ResetGameData function called.");

        
        if (ConfirmReset())
        {
            
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

            Debug.Log("All player data has been deleted. Starting a new game.");

        }
        else
        {
            Debug.Log("Game reset cancelled.");
        }
    }

    private bool ConfirmReset()
    {
        // Currently always returns true. Customize if needed.
        return true;
    }
}
