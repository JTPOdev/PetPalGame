using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PawScript : MonoBehaviour
{
    [SerializeField] RectTransform PawAnim;

    private void Start()
    {
        PawAnim.gameObject.SetActive(true);

        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 0);
        LeanTween.scale(PawAnim, Vector3.zero, 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            PawAnim.gameObject.SetActive(false);
        });
    }

    public void openHomeMenu()
    {
        AudioManager.instance.Play("ButtonPressed");
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            AudioManager.instance.Stop("MainBGaudio");
            SceneManager.LoadScene(SceneData.home);
        });
    }

    public void openNameScene()
    {
        AudioManager.instance.Play("ButtonPressed");
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            SceneManager.LoadScene(SceneData.namescene);
        });
    }

    public void openEggSelect()
    {
        AudioManager.instance.Play("ButtonPressed");
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            SceneManager.LoadScene(SceneData.eggselect);
        });
    }

    public void openEggCat()
    {
        AudioManager.instance.Play("ButtonPressed");
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
           
            SceneManager.LoadScene(SceneData.egghatchcat);
        });
    }

    public void openEggDog()
    {
        AudioManager.instance.Play("ButtonPressed");
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            
            SceneManager.LoadScene(SceneData.egghatchdog);
        });
    }

    public void openCatPlays()
    {
        AudioManager.instance.Play("ButtonPressed");
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            AudioManager.instance.Stop("MainBGaudio");
            AudioManager.instance.Play("PlaygroundBGaudio");
            SceneManager.LoadScene(SceneData.catplayground);
        });
    }

    public void openDogPlays()
    {
        AudioManager.instance.Play("ButtonPressed");
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            AudioManager.instance.Stop("MainBGaudio");
            AudioManager.instance.Play("PlaygroundBGaudio");
            SceneManager.LoadScene(SceneData.dogplayground);
        });
    }

    public void openCatBedroom()
    {
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            AudioManager.instance.Stop("MainBGaudio");
            SceneManager.LoadScene(SceneData.catbed);
        });
    }

    public void openDogBedroom()
    {
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            AudioManager.instance.Stop("MainBGaudio");
            SceneManager.LoadScene(SceneData.dogbed);
        });
    }

    public void openDogBath()
    {
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            AudioManager.instance.Stop("MainBGaudio");
            AudioManager.instance.Play("BathBGaudio");
            SceneManager.LoadScene(SceneData.dogbath);
        });
    }

    public void openCatBath()
    {
        PawAnim.gameObject.SetActive(true);
        LeanTween.scale(PawAnim, Vector3.zero, 0f);
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            AudioManager.instance.Stop("MainBGaudio");
            AudioManager.instance.Play("BathBGaudio");
            SceneManager.LoadScene(SceneData.catbath);
        });
    }
}
