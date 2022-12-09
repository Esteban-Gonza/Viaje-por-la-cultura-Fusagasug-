using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour{
    
    public static QuizManager instance;

    public List<QuizandAnswers> QnA;
    public GameObject[] options;
    public GameObject qnaCanvas;
    public GameObject correctCanvas;
    public GameObject incorrectCanvas;
    public GameObject diceButton;
    public int currentQuestion;

    public Text QuestionTxt;

    void Start(){

        qnaCanvas.SetActive(false);
        correctCanvas.SetActive(false);
        incorrectCanvas.SetActive(false);

        if (instance == null){
        
            instance = this;
        }
    }

    public void Correct(){

        QnA.RemoveAt(currentQuestion);
        qnaCanvas.SetActive(false);
        diceButton.SetActive(true);
        StartCoroutine("CorrectCanvas");
    }

    public void Incorrect(){

        qnaCanvas.SetActive(false);
        diceButton.SetActive(true);
        StartCoroutine("IncorrectCanvas");
    }

    void SetAnswer(){

        for (int i = 0; i < options.Length; i++){

            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i + 1){

                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void GenerateQuestion() {

        StartCoroutine("ShowQuestion");
        
    }

    IEnumerator CorrectCanvas(){

        correctCanvas.SetActive(true);
        yield return new WaitForSeconds(1f);
        correctCanvas.SetActive(false);
    }

    IEnumerator IncorrectCanvas(){

        incorrectCanvas.SetActive(true);
        yield return new WaitForSeconds(1f);
        incorrectCanvas.SetActive(false);
    }

    IEnumerator ShowQuestion(){

        yield return new WaitForSeconds(2f);

        if (QnA.Count > 0){

            qnaCanvas.SetActive(true);
            diceButton.SetActive(false);
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;

            SetAnswer();
        }else{

            Debug.Log("Ya no quedan preguntas");
        }
    }
}