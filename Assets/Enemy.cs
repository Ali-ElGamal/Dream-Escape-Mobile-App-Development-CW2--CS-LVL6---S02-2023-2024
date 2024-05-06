using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    public Animator animator;

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

        animator.SetTrigger("Hurt");


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

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }
   
}
