using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void gotoLoadSave()
    {
        SceneManager.LoadScene(SceneData.load);
        Debug.Log("loadsave works!");
    }
    public void gotoSettings()
    {
        SceneManager.LoadScene(SceneData.setting);
        Debug.Log("settings works!");
    }
    public void gotoMainGame()
    {
        SceneManager.LoadScene(SceneData.main);
        Debug.Log("Maingame works!");
    }
    public void gotoEggSelection()
    {
        SceneManager.LoadScene(SceneData.eggselect);
        Debug.Log("eggselection works!");
    }
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
