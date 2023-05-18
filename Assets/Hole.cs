using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hole : MonoBehaviour
{
    [SerializeField] CustomEvent customEvent;
    
    void OnCollisionEnter(Collision other)
    {
        OnTriggerEnter(other.collider);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball")){
            customEvent.onInvoked.Invoke();
        }
    }
}
