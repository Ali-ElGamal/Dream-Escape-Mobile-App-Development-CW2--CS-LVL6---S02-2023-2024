using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;
    // Start is called before the first frame update
    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Chest is now open");
            animator.SetBool("IsOpen", isOpen);
        }
    }
}
