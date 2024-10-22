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
            AudioManager.instance.Play("CoinCollect");
            GameManager.Instance.AddScore();

            // Claims the coins
            Destroy(other.gameObject, 0.02f);

            
        }

        // Walls
        if (other.gameObject.tag == "Wall")
        {
            // Game Over
            AudioManager.instance.Play("Dies");
            GameManager.Instance.GameOver();
            Destroy(gameObject, 0.02f);
        }
    }
}

