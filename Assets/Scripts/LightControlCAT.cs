using UnityEngine;
using UnityEngine.UI;

public class LightControlCAT : MonoBehaviour
{
    public Sprite lightOnSprite;  // Light ON image
    public Sprite lightOffSprite; // Light OFF image
    public Sprite switchUpSprite; // Switch UP image
    public Sprite switchDownSprite; // Switch DOWN image

    public Image lightBulb;  // Reference to LightBulb UI Image
    public Image lightSwitch;  // Reference to LightSwitch UI Image
    public GameObject darkOverlay;  // Reference to the dark overlay object
    public GameObject catAwake;  // Awake cat image
    public GameObject catSleep;  // Sleeping cat image

    private bool isLightOn = true;  // Track the light state

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
            catAwake.SetActive(true);
            catSleep.SetActive(false);
        }
        else
        {
            // Light OFF state
            lightBulb.sprite = lightOffSprite;
            lightSwitch.sprite = switchDownSprite;
            darkOverlay.SetActive(true);  // Show the dark overlay
            catAwake.SetActive(false);
            catSleep.SetActive(true);
        }
    }
}
