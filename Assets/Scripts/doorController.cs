using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;
    public float delayBeforeLoad = 2f; // Adjust this value as needed

    public void OpenDoor(GameObject obj)
    {
        if (!isOpen)
        {
            playerManager manager = obj.GetComponent<playerManager>();
            if (manager)
            {
                if (manager.keyCount > 0)
                {
                    isOpen = true;
                    manager.UseKey();
                    animator.SetBool("IsOpen", isOpen);
                    Debug.Log("Door is now Unlocked!");

                    // Start the coroutine to delay scene loading
                    StartCoroutine(LoadNextSceneWithDelay(delayBeforeLoad));
                }
            }
        }
    }

    IEnumerator LoadNextSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
