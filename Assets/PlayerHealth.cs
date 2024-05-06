using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return; // Exit the function if the player is already dead

        currentHealth -= damage;

        // Check if the player is still alive
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Player is hurt but still alive
            // Add logic to trigger hurt animation or perform any other actions

            // Set the "Hurt" parameter in the animator if the conditions are met
            if (animator != null && animator.GetFloat("Speed") < 0.01f)
            {
                animator.SetBool("Hurt", true);
            }

            // For now, let's just log that the player is hurt
            Debug.Log("Player is hurt!");
        }
    }

    void Die()
    {
        if (isDead)
            return; // Exit the function if the player is already dead

        // Player died, trigger death animation or perform any other actions

        // Set the "Death" parameter in the animator to trigger the death animation
        if (animator != null)
        {
            animator.SetBool("Death", true);
        }

        // Disable collider and this script
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        // For now, let's just log that the player died
        Debug.Log("Player died!");

        isDead = true; // Set the flag to indicate that the player has died
    }

}
