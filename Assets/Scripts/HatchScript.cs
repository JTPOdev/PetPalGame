using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HatchScript : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Space))
        {   AddClicks(1);
            if (ClickCounter == 0)
            {
                SceneManager.LoadScene(SceneData.main);
            }
        }
    }
    
    void AddClicks(int add)
    {
        ClickCounter -= add;
        barscript.SetFill(ClickCounter);
    }
}
