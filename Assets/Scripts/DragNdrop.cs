using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNdrop : MonoBehaviour
{
    //private Animator anim;
    bool startDragging, inUse;
    Vector2 startPos, slotPos;

    void Start()
    {
        //anim = GetComponent<Animator>();
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
            startDragging = true; // if mouse or tap collided, dragging is true
        }
    }

    public void StopDrag()
    {
        startDragging = false; // if mouse or tap stops colliding, dragging is false

        if (inUse)
        {
            transform.position = slotPos;
        }
        else
        {
            transform.position = startPos;//When image stop moving, it snaps back to original position
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouth"))//tag for image box
        {
            inUse = true;//holding the image
            //anim.SetTrigger("TRcrack");
            slotPos = collision.transform.position;//collider for box position
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouth"))//tag for image box
        {
            inUse = false;//if not inuse, not holding the image
        }
    }
}
