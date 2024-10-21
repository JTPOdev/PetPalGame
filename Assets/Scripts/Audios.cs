using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{

    public void ButtonPressed()
    {
        AudioManager.instance.Play("ButtonPressed");
    }

    public void Duck()
    {
        AudioManager.instance.Play("Quack");
    }

    public void PopUp()
    {
        AudioManager.instance.Play("PopUp");
    }

    public void GameOver()
    {
        AudioManager.instance.Play("Gameover");
    }

    public void Pop()
    {
        AudioManager.instance.Play("Pop");
    }

    public void Snore()
    {
        AudioManager.instance.Play("Snore");
    }

    public void BubblePop()
    {
        AudioManager.instance.Play("BubblePop");
    }
}
