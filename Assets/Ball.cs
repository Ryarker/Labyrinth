using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent<int> onGetCoin;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin")){
            var coin = other.GetComponent<Coin>();
            onGetCoin.Invoke(coin.Value);
            coin.Collected();
        }
    }
}
