using UnityEngine;
using UnityEngine.UI;

public class LightControl : MonoBehaviour
{
    public Sprite lightOnSprite;  // Light ON image
    public Sprite lightOffSprite; // Light OFF image
    public Sprite switchUpSprite; // Switch UP image
    public Sprite switchDownSprite; // Switch DOWN image

    public Image lightBulb;  // Reference to LightBulb UI Image
    public Image lightSwitch;  // Reference to LightSwitch UI Image
    public GameObject darkOverlay;  // Reference to the dark overlay object
    public GameObject dogAwake;  // Awake dog image
    public GameObject dogSleep;  // Sleeping dog image
    public GameObject backButton;

    private bool isLightOn = true;  // Track the light state

    void Start()
    {
        AudioManager.instance.Play("NightBGaudio");
    }
    public void ToggleLight()
    {
        isLightOn = !isLightOn;  // Toggle the light state
        UpdateObjects();
    }

    private void UpdateObjects()
    {
        if (isLightOn)
        {
            // Light ON state
            lightBulb.sprite = lightOnSprite;
            lightSwitch.sprite = switchUpSprite;
            darkOverlay.SetActive(false);  // Hide the dark overlay
            dogAwake.SetActive(true);
            dogSleep.SetActive(false);
            backButton.SetActive(true);
            AudioManager.instance.Play("Switch");
        }
        else
        {
            // Light OFF state
            lightBulb.sprite = lightOffSprite;
            lightSwitch.sprite = switchDownSprite;
            darkOverlay.SetActive(true);  // Show the dark overlay
            dogAwake.SetActive(false);
            dogSleep.SetActive(true);
            backButton.SetActive(false);
            AudioManager.instance.Play("Switch");
        }
    }
}
