using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBar;

    private Animator animator;
    private bool isDead = false;

    public GameManager gameManager;
    

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp((float)currentHealth / maxHealth, 0f, 1f);
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return; // Exit the function if the player is already dead

        Debug.Log("Player taking damage!");

        currentHealth -= damage;

        // Check if the player is still alive
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            
            // Set the "Hurt" parameter in the animator if the conditions are met
            if (animator != null && animator.GetFloat("Speed") < 0.01f)
            {
                animator.SetBool("Hurt", true);
            }

            // For now, let's just log that the player is hurt
            Debug.Log("Player is hurt!");
        }
    }

    // Called from the hurt animation event to signify the end of the hurt animation
    public void EndHurtAnimation()
    {
        animator.SetBool("HurtEnded", true);
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

        // Disable collider
        GetComponent<Collider2D>().enabled = false;

        

        // Disable the Rigidbody2D component to prevent the player from falling infinitely
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = false;
        }

        // Call the gameOver() method from the GameManager
        if (gameManager != null)
        {
            gameManager.gameOver();
        }

        // Freeze the scene by setting the time scale to 0
        Time.timeScale = 0f;

        // For now, let's just log that the player died
        Debug.Log("Player died!");

        isDead = true; // Set the flag to indicate that the player has died
    }

}
