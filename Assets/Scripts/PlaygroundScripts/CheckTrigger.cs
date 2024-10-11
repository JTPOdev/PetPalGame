using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Coin
        if (other.gameObject.tag == "Coin")
        {
            // Add Score ++
            GameManager.Instance.AddScore();
            Destroy(other.gameObject, 0.02f);
            
        }

        // Walls
        if (other.gameObject.tag == "Wall")
        {
            // Game Over
            GameManager.Instance.GameOver();
            Destroy(gameObject, 0.02f);
        }
    }
}

