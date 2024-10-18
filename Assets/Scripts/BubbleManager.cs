using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour
{
    public List<GameObject> bubbleImages; 
    public Button takeBathButton;         
    private float respawnTime = 10f;      
    private float autoDisappearTime = 20f; 
    private float floatHeight = 3f;      
    private float floatSpeed = 1.5f;        
    private float waveAmplitude = 2f;    
    private float waveFrequency = 2f;     

    void Start()
    {
        
        takeBathButton.onClick.AddListener(StartBath);

        
        foreach (GameObject bubble in bubbleImages)
        {
            bubble.SetActive(false);
        }
    }

    
    void StartBath()
    {
        
        StartCoroutine(ShowBubblesWithDelay());
    }

    
    private IEnumerator ShowBubblesWithDelay()
    {
        foreach (GameObject bubble in bubbleImages)
        {
            
            yield return StartCoroutine(AnimateBubbleAppearance(bubble));
            StartCoroutine(AutoHideBubble(bubble)); 
            StartCoroutine(FloatBubble(bubble)); 
            yield return new WaitForSeconds(1.5f); 
        }
    }

    
    private IEnumerator AnimateBubbleAppearance(GameObject bubble)
    {
        
        bubble.transform.localScale = Vector3.zero;
        bubble.SetActive(true); 

        float animationDuration = 0.6f; 
        float bounceDuration = 0.6f; 
        float elapsedTime = 0f;

        Vector3 initialScale = Vector3.zero; 
        Vector3 overshootScale = Vector3.one * 1.2f; 
        Vector3 finalScale = Vector3.one; 

        
        while (elapsedTime < animationDuration)
        {
            
            float t = elapsedTime / animationDuration;
            t = t * t * (3f - 2f * t); 

            
            bubble.transform.localScale = Vector3.Lerp(initialScale, overshootScale, t);

            elapsedTime += Time.deltaTime; 
            yield return null; 
        }

        
        bubble.transform.localScale = overshootScale;

        
        elapsedTime = 0f;
        while (elapsedTime < bounceDuration)
        {
            float t = elapsedTime / bounceDuration;
            t = t * t * (3f - 2f * t); 

            
            bubble.transform.localScale = Vector3.Lerp(overshootScale, finalScale, t);

            elapsedTime += Time.deltaTime; 
            yield return null;
        }


        bubble.transform.localScale = finalScale;
    }


    private IEnumerator FloatBubble(GameObject bubble)
    {
        Vector3 originalPosition = bubble.transform.position; 

        while (true) 
        {
            
            float newY = originalPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
            float newX = originalPosition.x + Mathf.Sin(Time.time * waveFrequency) * waveAmplitude; 
            bubble.transform.position = new Vector3(newX, newY, originalPosition.z);
            yield return null; // Wait for the next frame
        }
    }

    
    public void OnBubbleClicked(GameObject bubble)
    {
        StartCoroutine(AnimateBubblePop(bubble)); 
    }

    
    private IEnumerator AnimateBubblePop(GameObject bubble)
    {
        Vector3 originalScale = bubble.transform.localScale; 
        Vector3 popScale = originalScale * 1.2f; 
        float popDuration = 0.2f; 
        float elapsedTime = 0f;


        while (elapsedTime < popDuration)
        {
            float t = elapsedTime / popDuration;
            t = t * t * (3f - 2f * t); 
            bubble.transform.localScale = Vector3.Lerp(originalScale, popScale, t);
            elapsedTime += Time.deltaTime; 
            yield return null; 
        }

        
        bubble.transform.localScale = popScale;

    
        elapsedTime = 0f;
        while (elapsedTime < popDuration)
        {
            float t = elapsedTime / popDuration;
            t = t * t * (3f - 2f * t); 
            bubble.transform.localScale = Vector3.Lerp(popScale, originalScale, t);
            elapsedTime += Time.deltaTime; 
            yield return null; 
        }

        
        bubble.transform.localScale = originalScale;

        bubble.SetActive(false); 
        StartCoroutine(RespawnBubble(bubble)); 
    }

    
    private IEnumerator RespawnBubble(GameObject bubble)
    {
        yield return new WaitForSeconds(respawnTime); 
        yield return StartCoroutine(AnimateBubbleAppearance(bubble)); 
        StartCoroutine(AutoHideBubble(bubble)); 
    }

    
    private IEnumerator AutoHideBubble(GameObject bubble)
    {
        yield return new WaitForSeconds(autoDisappearTime); 
        bubble.SetActive(false); 
        StartCoroutine(RespawnBubble(bubble)); 
    }
}