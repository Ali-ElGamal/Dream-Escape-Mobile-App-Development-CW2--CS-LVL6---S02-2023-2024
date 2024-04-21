using UnityEngine;

public class Door : MonoBehaviour
{
    public int requiredKeyCount = 3; // Number of keys required to open the door
    public Animator doorAnimator; // Reference to the Animator component for door animation


    public void Interact()
    {
        if (FindObjectOfType<InteractionSystem>().pickedItems.Count >= requiredKeyCount)
        {
            // If player has enough keys, unlock the door -> play unlock animation
            doorAnimator.SetTrigger("Unlock"); // play animation trigger named "Unlock"
        }
        else
        {
            // Optionally, provide feedback to the player that the door is locked
            Debug.Log("The door is locked. You need more keys to unlock it.");
        }
    }
}