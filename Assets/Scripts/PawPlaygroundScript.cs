using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PawPlaygroundScript : MonoBehaviour
{
    [SerializeField] RectTransform PawAnim;

    public void openMainCat()
    {
        AudioManager.instance.Play("ButtonPressed");
        AudioManager.instance.Stop("PlaygroundBGaudio");
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            AudioManager.instance.Play("MainBGaudio");
            SceneManager.LoadScene(SceneData.maincat);
        });
    }

    public void openMainDog()
    {
        AudioManager.instance.Play("ButtonPressed");
        AudioManager.instance.Stop("PlaygroundBGaudio");
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            AudioManager.instance.Play("MainBGaudio");
            SceneManager.LoadScene(SceneData.maindog);
        });
    }
}

