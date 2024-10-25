using System.Collections;
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

    public StatsFunction statsFunction;  // Reference to the StatsFunction script

    private bool isLightOn = true;  
    private Coroutine statCoroutine;  // To keep track of the stats coroutine

    void Start()
    {
        AudioManager.instance.Play("NightBGaudio");
        UpdateObjects(); // Ensure the initial state is correct
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

            // Start the stats coroutine if it's not already running
            if (statCoroutine == null) 
            {
                statCoroutine = StartCoroutine(IncreaseStats());
            }
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

            // Stop the stats coroutine if it's running
            if (statCoroutine != null) 
            {
                StopCoroutine(statCoroutine);
                statCoroutine = null;
            }
        }
    }

    private IEnumerator IncreaseStats()
    {
        while (true) 
        {
            statsFunction.Sleep(); 
            yield return new WaitForSeconds(3f); 
        }
    }
}
