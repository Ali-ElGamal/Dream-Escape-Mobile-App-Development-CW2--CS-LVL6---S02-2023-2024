using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trap : MonoBehaviour

{   public float bounceForce = 10f;
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerBounce(collision.gameObject);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage((int)damage);
        }
    }
    private void HandlePlayerBounce(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (rb)
        {   //reset player speed
            rb.velocity = new Vector2(rb.velocity.x, 0f);

            //apply bounce effect up
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
