using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public int keyCount;
    public void PickupKey()
    {
        keyCount++;
        Debug.Log("Picked up key");
    }
    public void UseKey()
    {
        keyCount--;
        Debug.Log("Used a key");
    }
}
