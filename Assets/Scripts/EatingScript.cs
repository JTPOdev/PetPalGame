using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingScript : MonoBehaviour
{
    public TMPro.TMP_Text countdownText;
    public int countdownTime;
    private Animator dogAnim;
    public GameObject exitButton;
    public GameObject dogFoodImg;

    void Start()
    {
        dogAnim = GetComponent<Animator>();
        exitButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Eats"))
        {
            dogAnim.SetTrigger("Dog Eating");
            //Destroy(other.gameObject, 1);
            exitButton.SetActive(true);
            StartCoroutine(CountDownToStart());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Eats"))
        {
            dogAnim.SetTrigger("Dog Idle");
        }
    }

    IEnumerator CountDownToStart()
    {
        while (countdownTime > 0)
        {
            dogFoodImg.gameObject.SetActive(true);
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        countdownText.text = "GO!";

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
        dogFoodImg.gameObject.SetActive(false);
    }
}
