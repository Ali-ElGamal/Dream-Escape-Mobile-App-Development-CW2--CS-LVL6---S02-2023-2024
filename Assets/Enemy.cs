using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public float deathAnimationDuration = 1f;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

    }
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        animator.SetTrigger("Hit");

        Debug.Log("Enemy hit! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("Dead", true);

        //disable enemy after being dead
        StartCoroutine(DisableAfterDeathAnimation());
       // GetComponent<Collider2D>().enabled = false;
       // this.enabled = false;

    }
    private IEnumerator DisableAfterDeathAnimation()
    {
        // Wait for the duration of the death
        yield return new WaitForSeconds(deathAnimationDuration);         // Disable or destroy the enemy GameObject
        gameObject.SetActive(false); // Option 1: Simply disable the GameObject// OR// Destroy(gameObject); // Option 2: Destroy the GameObject  
    }
}
