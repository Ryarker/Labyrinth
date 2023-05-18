using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownPlay : MonoBehaviour
{
    [SerializeField] int countdownDuration = 3;
    [SerializeField] TMP_Text countdownText;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gravityController;
    [SerializeField] GameObject playManager;

    private float currentTime;
    private bool isCountingDown;

    private void Start()
    {
        currentTime = countdownDuration;
        isCountingDown = true;
        countdownText.text = countdownDuration.ToString();
        startPanel.SetActive(true);
        gravityController.SetActive(false);
        playManager.SetActive(false);
    }

    private void Update()
    {
        if (isCountingDown)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isCountingDown = false;
                countdownText.text = "Go!";
                Invoke("StartGame", 1f); 
            }
            else
            {
                int seconds = Mathf.CeilToInt(currentTime);
                countdownText.text = seconds.ToString();
            }
        }
    }

    private void StartGame()
    {
        startPanel.SetActive(false);
        gravityController.SetActive(true);
        playManager.SetActive(true);
    }
}
