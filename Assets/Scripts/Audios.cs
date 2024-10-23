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

    public void Ate1()
    {
        AudioManager.instance.Play("Ate 1");
    }

    public void Ate2()
    {
        AudioManager.instance.Play("Ate 2");
    }

    public void Ate3()
    {
        AudioManager.instance.Play("Ate 3");
    }

    public void Drink1()
    {
        AudioManager.instance.Play("Drink 1");
        AudioManager.instance.Play("Drink 1");
    }

    public void Drink2()
    {
        AudioManager.instance.Play("Drink 2");
        AudioManager.instance.Play("Drink 2");
    }

    public void Drink3()
    {
        AudioManager.instance.Play("Drink 3");
        AudioManager.instance.Play("Drink 3");
    }
}
