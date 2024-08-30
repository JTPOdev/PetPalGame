using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public AudioSource ButtonPlayerP;
    public AudioSource ButtonPlayerN;
    public AudioSource EggCrack;
    public void PostiveAudio()
    {
        ButtonPlayerP.Play();
    }
    public void NegativeAudio()
    {
        ButtonPlayerN.Play();
    }
    public void EggCrackAudio()
    {
        EggCrack.Play();
    }
}
