using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioSetting : MonoBehaviour
{
    bool muted = false;
    public static audioSetting instance;
   private void Awake() {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start() {
        if(!PlayerPrefs.HasKey("muted")){
            PlayerPrefs.SetInt("muted",0);
        Load();
        }    
        else{
            Load();
        }
    }
    
    public void ToggleMute () {
        if(muted == false){
            muted = true;
            AudioListener.pause = true;
        }
        else{
            muted = false;
            AudioListener.pause = false;
        }
        Save();
    }
    private void Load () {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save () {
        PlayerPrefs.SetInt("muted",muted?1:0);
    }
}
