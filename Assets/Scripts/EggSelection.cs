using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EggSelection : MonoBehaviour
{
    public Button dogEggButton;
    public Button catEggButton;

    private void Start()
    {
        // Add listeners to the buttons
        dogEggButton.onClick.AddListener(OnDogEggSelected);
        catEggButton.onClick.AddListener(OnCatEggSelected);
    }

    private void OnDogEggSelected()
    {
        PlayerProgress.SaveSelectedEgg("dog");
        Debug.Log("Dog egg selected.");
        // Optionally, you could load the egg hatching scene here
    }

    private void OnCatEggSelected()
    {
        PlayerProgress.SaveSelectedEgg("cat");
        Debug.Log("Cat egg selected.");
        // Optionally, you could load the egg hatching scene here
    }
}
