using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public static Audios instance;

    public void ButtonPressed()
    {
        AudioManager.instance.Play("ButtonPressed");
    }

    public void Duck()
    {
        AudioManager.instance.Play("Quack");
    }
}
