using UnityEngine;
using UnityEngine.UI;

public class LightControlCAT : MonoBehaviour
{
    public Sprite lightOnSprite; 
    public Sprite lightOffSprite; 
    public Sprite switchUpSprite; 
    public Sprite switchDownSprite; 

    public Image lightBulb;  
    public Image lightSwitch;  
    public GameObject darkOverlay;  
    public GameObject catAwake; 
    public GameObject catSleep; 

    private bool isLightOn = true;  

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
            catAwake.SetActive(true);
            catSleep.SetActive(false);
        }
        else
        {
            
            lightBulb.sprite = lightOffSprite;
            lightSwitch.sprite = switchDownSprite;
            darkOverlay.SetActive(true); 
            catAwake.SetActive(false);
            catSleep.SetActive(true);
        }
    }
}
