using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour{
    
    public static UIManager instance;
    [SerializeField] Text scoreText1;
    [SerializeField] Text scoreText2;

    void Awake(){

        if (instance == null){
        
            instance = this;
        }
    }

    public void UpdateScore1(int newScore){

        scoreText1.text = newScore.ToString();
    }
    public void UpdateScore2(int newScore){

        scoreText2.text = newScore.ToString();
    }
}