using UnityEngine;
using UnityEngine.UI;

public class LightControl : MonoBehaviour
{
    public Sprite lightOnSprite;  
    public Sprite lightOffSprite; 
    public Sprite switchUpSprite; 
    public Sprite switchDownSprite; 

    public Image lightBulb;  
    public Image lightSwitch;  
    public GameObject darkOverlay;  
    public GameObject dogAwake;  
    public GameObject dogSleep;  
    public GameObject backButton;

    private bool isLightOn = true;  
    void Start()
    {
        AudioManager.instance.Play("NightBGaudio");
    }
    public void ToggleLight()
    {
        isLightOn = !isLightOn;  
        UpdateObjects();
    }

    private void UpdateObjects()
    {
        if (isLightOn)
        {
            
            lightBulb.sprite = lightOnSprite;
            lightSwitch.sprite = switchUpSprite;
            darkOverlay.SetActive(false);  
            dogAwake.SetActive(true);
            dogSleep.SetActive(false);
            backButton.SetActive(true);
            AudioManager.instance.Play("Switch");
        }
        else
        {
            
            lightBulb.sprite = lightOffSprite;
            lightSwitch.sprite = switchDownSprite;
            darkOverlay.SetActive(true);  
            dogAwake.SetActive(false);
            dogSleep.SetActive(true);
            backButton.SetActive(false);
            AudioManager.instance.Play("Switch");
        }
    }
}
