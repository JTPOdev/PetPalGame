using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEatingScript : MonoBehaviour
{
    [Header("Counter")]
    public TMPro.TMP_Text countdownText;
    public int countdownTime;
    private Animator catAnim;

    [Header("Page")]
    public GameObject cathungry;
    public GameObject catidle;
    public GameObject exitButton;
    public GameObject table;
    public GameObject path;

    [Header("Food Image")]
    public GameObject FoodImg_1;
    public GameObject FoodImg_2;
    public GameObject FoodImg_3;

    [Header("Drink Image")]
    public GameObject waterDrinkImg;
    public GameObject milkDrinkImg;
    public GameObject milkshakeDrinkImg;

    void Start()
    {
        catAnim = GetComponent<Animator>();
        exitButton.SetActive(false);
        table.SetActive(false);
        path.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Eats"))
        {
            catAnim.SetTrigger("Cat Eating");
            //Destroy(other.gameObject, 1);
            StartCoroutine(CountDownToStart());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Eats"))
        {
            catAnim.SetTrigger("Cat Idle");
        }
    }

    IEnumerator CountDownToStart()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
            table.SetActive(true);
            path.SetActive(true);
        }

        countdownText.text = "ATE!";

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
        FoodImg_1.gameObject.SetActive(false);
        FoodImg_2.gameObject.SetActive(false);
        FoodImg_3.gameObject.SetActive(false);
        waterDrinkImg.gameObject.SetActive(false);
        milkDrinkImg.gameObject.SetActive(false);
        milkshakeDrinkImg.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        exitButton.SetActive(true);
        cathungry.SetActive(false);
        catidle.SetActive(true);
    }
}
