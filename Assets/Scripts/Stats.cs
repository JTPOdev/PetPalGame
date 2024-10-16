using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour 
{
    public Slider bathSlider;
    public Slider funSlider;
    public Slider thirstSlider;
    public Slider hungerSlider;
    public Slider energySlider;

    private const int MAX_BATH = 100;
    private const int MAX_FUN = 100;
    private const int MAX_THIRST = 100;
    private const int MAX_HUNGER = 100;
    private const int MAX_ENERGY = 100;

    private const int BATH_DECREASE_AMOUNT = 5;
    private const int FUN_DECREASE_AMOUNT = 3;
    private const int THIRST_DECREASE_AMOUNT = 2;
    private const int HUNGER_DECREASE_AMOUNT = 4;
    private const int ENERGY_DECREASE_AMOUNT = 3;

    private const float DECREASE_INTERVAL = 30f; 

    private void Start()
    {
        SetMaxValues();
        StartCoroutine(DecreaseStatsOverTime());
    }

    private void SetMaxValues()
    {
        SetMaxBath(MAX_BATH);
        SetMaxFun(MAX_FUN);
        SetMaxThirst(MAX_THIRST);
        SetMaxHunger(MAX_HUNGER);
        SetMaxEnergy(MAX_ENERGY);
    }

    public void SetMaxBath(int bath)
    {
        bathSlider.maxValue = bath;
        bathSlider.value = bath;
    }

    public void SetMaxFun(int fun)
    {
        funSlider.maxValue = fun;
        funSlider.value = fun;
    }

    public void SetMaxThirst(int thirst)
    {
        thirstSlider.maxValue = thirst;
        thirstSlider.value = thirst;
    }

    public void SetMaxHunger(int hunger)
    {
        hungerSlider.maxValue = hunger;
        hungerSlider.value = hunger;
    }

    public void SetMaxEnergy(int energy)
    {
        energySlider.maxValue = energy;
        energySlider.value = energy;
    }

    public void SetBath(int bath)
    {
        bathSlider.value = bath;
    }

    public void SetFun(int fun)
    {
        funSlider.value = fun;
    }

    public void SetThirst(int thirst)
    {
        thirstSlider.value = thirst;
    }

    public void SetHunger(int hunger)
    {
        hungerSlider.value = hunger;
    }

    public void SetEnergy(int energy)
    {
        energySlider.value = energy;
    }

    private IEnumerator DecreaseStatsOverTime()
    {
        while (true) 
        {
            yield return new WaitForSeconds(DECREASE_INTERVAL); 

            // Decrease bath value
            if (bathSlider.value > BATH_DECREASE_AMOUNT) 
            {
                SetBath((int)(bathSlider.value - BATH_DECREASE_AMOUNT));
            }
            else
            {
                SetBath(0);
            }

            // Decrease fun value
            if (funSlider.value > FUN_DECREASE_AMOUNT) 
            {
                SetFun((int)(funSlider.value - FUN_DECREASE_AMOUNT));
            }
            else
            {
                SetFun(0);
            }

            // Decrease thirst value
            if (thirstSlider.value > THIRST_DECREASE_AMOUNT) 
            {
                SetThirst((int)(thirstSlider.value - THIRST_DECREASE_AMOUNT));
            }
            else
            {
                SetThirst(0);
            }

            // Decrease hunger value
            if (hungerSlider.value > HUNGER_DECREASE_AMOUNT) 
            {
                SetHunger((int)(hungerSlider.value - HUNGER_DECREASE_AMOUNT));
            }
            else
            {
                SetHunger(0);
            }

            // Decrease energy value
            if (energySlider.value > ENERGY_DECREASE_AMOUNT) 
            {
                SetEnergy((int)(energySlider.value - ENERGY_DECREASE_AMOUNT));
            }
            else
            {
                SetEnergy(0);
            }
        }
    }
}
