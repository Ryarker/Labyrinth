using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    
    


    public void Pause () {
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume () {
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
     public void ReplayGame () {
        var replayButton = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(replayButton);
        Time.timeScale = 1f;
        }

    public void GameToMenu () {
        SceneManager.LoadScene(0);
    }
    
    public void MenuToGame () {
        SceneManager.LoadScene(1);
    }

    public void SelectLevel1 () {
        SceneManager.LoadScene(2);
    }

    public void selectLevel2 () {
        SceneManager.LoadScene(3);
    }

    public void ExitGame () {
        Application.Quit();
    }

}
