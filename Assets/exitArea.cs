using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("Player").SendMessage("Finnish");
        
    }
}
