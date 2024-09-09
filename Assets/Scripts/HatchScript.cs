using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HatchScript : MonoBehaviour
{
    [SerializeField] RectTransform PawAnim;
    public int max = 10;
    public int ClickCounter;
    public BarScript barscript;
    void Start()
    {
        ClickCounter = max;
        barscript.SetMaxFill(max);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AddClicks(1);
            AudioManager.instance.Play("HatchAudio");

            if (ClickCounter == 0)
            {
                PawAnim.gameObject.SetActive(true);
                LeanTween.scale(PawAnim, Vector3.zero, 0f);
                LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
                    SceneManager.LoadScene(SceneData.main);
                });
            }
        }
    }
    
    void AddClicks(int add)
    {
        ClickCounter -= add;
        barscript.SetFill(ClickCounter);
    }
}
