using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour{

    public bool isCorrect = false;

    [SerializeField] int scorePoints = 100;
    [SerializeField] GameObject diceButton;

    Dice dice;

    void Start(){
        
        dice = FindObjectOfType<Dice>();
    }

    public void Answer(){

        if (isCorrect){

            diceButton.SetActive(true);

            if(dice.whosTurn == -1){

                GameControl.instance.Score1 += scorePoints;
                QuizManager.instance.Correct();
            }
            if (dice.whosTurn == 1){

                GameControl.instance.Score2 += scorePoints;
                QuizManager.instance.Correct();
            }
        }
        else{

            diceButton.SetActive(true);
            QuizManager.instance.Incorrect();
        }
    }
}
