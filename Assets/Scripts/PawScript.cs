using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {

            SceneManager.LoadScene(SceneData.egghatchdog);
        });
    }
}
