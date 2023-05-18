using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] TMP_Text finishedText;
    [SerializeField] CustomEvent gameOverEvent;
    [SerializeField] CustomEvent playerWinEvent;
    [SerializeField] TMP_Text timerText;
    [SerializeField] float timeLimit = 60;
    private float currentTime;
    private void Start()
    {
        currentTime = timeLimit;
        UpdateTimerText();
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                GameOver();
            }
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timeString;
    }
    private void OnEnable() {
        gameOverEvent.onInvoked.AddListener(GameOver);
        playerWinEvent.onInvoked.AddListener(Winner);

    }

    private void OnDisable() {
        gameOverEvent.onInvoked.RemoveListener(GameOver);
        playerWinEvent.onInvoked.RemoveListener(Winner);
    }
   public void GameOver () {
    finishedCanvas.SetActive(true);
    finishedText.text = "you failed";
   }

   public void Winner () {
    finishedCanvas.SetActive(true);
    finishedText.text = "you win\nTime: " + getTime();
   }

   private float getTime () {
    return ((int)currentTime);
   }
}
