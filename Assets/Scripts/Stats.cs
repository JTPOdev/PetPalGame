using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float hunger = 100f;
    public float thirst = 100f;
    public float health = 100f;
    public float bath = 100f;
    public float fun = 100f;

    public Slider HungerBar;
    public Slider ThirstBar;
    public Slider HealthBar;
    public Slider BathBar;
    public Slider FunBar;

    // Decrease amount and time interval
    public float decreaseAmount = 10f; // The amount to decrease
    public float decreaseInterval = 300f; // 5 minutes in seconds

    void Start()
    {

        UpdateBars();

        StartCoroutine(DecreaseHunger());
        StartCoroutine(DecreaseThirst());
        StartCoroutine(DecreaseHealth());
        StartCoroutine(DecreaseBath());
        StartCoroutine(DecreaseFun());
    }

    IEnumerator DecreaseHunger()
    {
        while (hunger > 0)
        {
            yield return new WaitForSeconds(decreaseInterval);
            hunger -= decreaseAmount;
            if (hunger < 0) hunger = 0;
            UpdateBars();
        }
    }

    IEnumerator DecreaseThirst()
    {
        while (thirst > 0)
        {
            yield return new WaitForSeconds(decreaseInterval);
            thirst -= decreaseAmount;
            if (thirst < 0) thirst = 0;
            UpdateBars();
        }
    }

    // Coroutine to decrease health over time
    IEnumerator DecreaseHealth()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(decreaseInterval);
            health -= decreaseAmount;
            if (health < 0) health = 0;
            UpdateBars();
        }
    }

    // Coroutine to decrease bath over time
    IEnumerator DecreaseBath()
    {
        while (bath > 0)
        {
            yield return new WaitForSeconds(decreaseInterval);
            bath -= decreaseAmount;
            if (bath < 0) bath = 0;
            UpdateBars();
        }
    }

    // Coroutine to decrease fun over time
    IEnumerator DecreaseFun()
    {
        while (fun > 0)
        {
            yield return new WaitForSeconds(decreaseInterval);
            fun -= decreaseAmount;
            if (fun < 0) fun = 0;
            UpdateBars();
        }
    }

    // Update all bars to reflect the current status values
    void UpdateBars()
    {
        if (HungerBar != null) HungerBar.value = hunger;
        if (ThirstBar != null) ThirstBar.value = thirst;
        if (HealthBar != null) HealthBar.value = health;
        if (BathBar != null) BathBar.value = bath;
        if (FunBar != null) FunBar.value = fun;
    }
}