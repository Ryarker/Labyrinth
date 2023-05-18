using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] Transform visual;
    [SerializeField] CoinData coinData;
    [SerializeField] BaseAnimation baseAnimation;
    [SerializeField, Range(0,10)] float rotationSpeed = 1;
    [SerializeField] private AudioSource coinCollectedSoundEffect;
    public int Value { get => coinData.value; }

    public void Collected()
    {
        GetComponent<Collider>().enabled = false;
        rotationSpeed *= 5;
        coinCollectedSoundEffect.Play();
        this.transform.DOJump(
            this.transform.position,
            1.5f,
            1,
            0.5f
        ).onComplete = SelfDestruct;
    }
    private void SelfDestruct () {
        Destroy(this.gameObject);
    }

    private void Start() {
        visual.GetComponent<Renderer>().material = coinData.material;
        if (baseAnimation!=null)
            baseAnimation.Animate(visual);
    }
}
