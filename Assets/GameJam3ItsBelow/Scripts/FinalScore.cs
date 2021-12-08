using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    public int finalFishScore;
    public CountdownTimer countdownTimer;
    public bool isFinish;
    public Scene currentScene;

    private void Update()
    {
        countdownTimer = FindObjectOfType<CountdownTimer>();
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "MainMenu" )
        {
            countdownTimer = null;
        }

        if(countdownTimer == null) 
            return;
        
        if(countdownTimer.isTimerDone)
        {
            GetScore();
        }
    }
  
    void GetScore()
    {
        finalFishScore = countdownTimer.finalScore;
    }
}
