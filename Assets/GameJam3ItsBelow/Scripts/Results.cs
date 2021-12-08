using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
   FinalScore finalScore;

    public Text finalScoreText;

    private void OnEnable()
    {
        finalScore = FindObjectOfType<FinalScore>();
        SetFinalScore(finalScore.finalFishScore.ToString());
    }

    void SetFinalScore(string _score)
    {
        finalScoreText.text = _score;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
