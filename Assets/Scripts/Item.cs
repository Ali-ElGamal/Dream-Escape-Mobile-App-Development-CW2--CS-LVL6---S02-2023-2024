using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum InteractionType { None, PickUp}
    public InteractionType type;
    
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }
    
    public void Interact()
    {
        switch (type)
        {
            case InteractionType.PickUp:
                //add object to pickedupitems list _ looks in the interactionsystem script
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                //disables object after being picked up
                gameObject.SetActive(false);
                break;
            default:
                Debug.Log("Null item");
                break;
        }
    }
}
