using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaitCountText : MonoBehaviour
{
    [SerializeField] TMP_Text waitText;
    

    public void UpdateWaitText(int value){
        waitText.text = "wait " + value +"s";
    }
}
