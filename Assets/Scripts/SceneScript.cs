using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //--------------------------------------------------------------------
    public void gotoLoadSave()
    {
        SceneManager.LoadScene(SceneData.load);
    }
    public void gotoSettings()
    {
        SceneManager.LoadScene(SceneData.setting);
    }
    public void gotoMainGame()
    {
        SceneManager.LoadScene(SceneData.main);

    }
    // First to Run ------------------------------------------------------
    public void gotoEggSelection() 
    {
        SceneManager.LoadScene(SceneData.eggselect);
    }
    //--------------------------------------------------------------------

    public void gotoEggCat()
    {
        SceneManager.LoadScene(SceneData.egghatchcat);
        Debug.Log("egg hatch cat works!");
    }
    public void gotoEggDog()
    {
        SceneManager.LoadScene(SceneData.egghatchdog);
        Debug.Log("egg hatch dog works!");
    }
}
