using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingScript : MonoBehaviour
{
    private Animator dogAnim;
    public GameObject exitButton;

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
            Destroy(other.gameObject, 1);
            exitButton.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Eats"))
        {
            dogAnim.SetTrigger("Dog Idle");
        }
    }
}
