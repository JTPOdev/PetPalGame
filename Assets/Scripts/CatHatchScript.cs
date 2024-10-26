using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatHatchScript : MonoBehaviour
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

            // Play egg breaking sounds based on the ClickCounter value
            if (ClickCounter == 9) AudioManager.instance.Play("EggBreak 1");
            if (ClickCounter == 8) AudioManager.instance.Play("EggBreak 2");
            if (ClickCounter == 7) AudioManager.instance.Play("EggBreak 3");
            if (ClickCounter == 6) AudioManager.instance.Play("EggBreak 1");
            if (ClickCounter == 5) AudioManager.instance.Play("EggBreak 2");
            if (ClickCounter == 4) AudioManager.instance.Play("EggBreak 3");
            if (ClickCounter == 3) AudioManager.instance.Play("EggBreak 1");
            if (ClickCounter == 2) AudioManager.instance.Play("EggBreak 2");  
            if (ClickCounter == 1) AudioManager.instance.Play("EggBreak 3");
            
            if (ClickCounter == 0)
            {
                // Celebrate the hatching
                AudioManager.instance.Play("OpenCelebrate");
                AudioManager.instance.Stop("HomeBGaudio");
                PawAnim.gameObject.SetActive(true);
                LeanTween.scale(PawAnim, Vector3.zero, 0f);
                LeanTween.scale(PawAnim, new Vector3(1, 1, 1), 1.5f)
                    .setEase(LeanTweenType.easeInOutExpo)
                    .setOnComplete(() => {
                        AudioManager.instance.Play("MainBGaudio");
                        
                        // Save the selected egg type as "cat"
                        PlayerProgress.SaveSelectedEgg("cat");
                        
                        // Load the main scene for the cat
                        SceneManager.LoadScene(SceneData.maincat);
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
