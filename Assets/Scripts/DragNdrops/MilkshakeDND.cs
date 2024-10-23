using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkshakeDND : MonoBehaviour
{
    public TMPro.TMP_Text countdownText;
    public int countdownTime;
    private Animator foodAnim;
    public GameObject hungry;
    public GameObject idle;
    bool startDragging, inUse;
    Vector2 startPos, slotPos;

    void Start()
    {
        idle.SetActive(true);
        foodAnim = GetComponent<Animator>();
        startPos = transform.position; //start position
    }

    void Update()
    {
        if (startDragging)
        {
            transform.position = Input.mousePosition; //mouse or tap caller if it collided to the image
        }
    }

    public void StartDrag()
    {
        if (!inUse)//cant be dragged when it has collided the image
        {
            AudioManager.instance.Play("Grab");
            idle.SetActive(false);
            hungry.SetActive(true);
            startDragging = true; // if mouse or tap collided, dragging is true
        }
    }

    public void StopDrag()
    {
        startDragging = false; // if mouse or  tap stops colliding, dragging is false

        if (inUse)
        {
            hungry.SetActive(true);
            transform.position = slotPos;
        }
        else
        {
            hungry.SetActive(false);
            idle.SetActive(true);
            transform.position = startPos;//When image stop moving, it snaps back to original position
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouth"))//tag for image box
        {
            inUse = true;//holding the image
            hungry.SetActive(true);
            foodAnim.SetTrigger("Milkshake Ate");
            slotPos = collision.transform.position;//collider for box position
            StartCoroutine(CountDownToStart());


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouth"))//tag for image box
        {
            foodAnim.SetTrigger("Milkshake Idle");
            inUse = false;//if not inuse, not holding the image

        }
    }

    IEnumerator CountDownToStart()
    {
        while (countdownTime > 0)
        {
            inUse = true;
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        yield return new WaitForSeconds(1f);
        inUse = false;
        transform.position = startPos;
        foodAnim.SetTrigger("Milkshake Idle");

    }
}
