using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectCharacterMenu : MonoBehaviour{

    public int index1;
    public int index2;
    [SerializeField] Image image1;
    [SerializeField] Image image2;

    GameManager gameManager;

    void Start(){

        gameManager = GameManager.instance;
        index1 = PlayerPrefs.GetInt("Jugador1Index");
        index2 = PlayerPrefs.GetInt("Jugador2Index");

        if(index1 > gameManager.characters1.Count - 1){

            index1 = 0;
        }
        
        if(index2 > gameManager.characters2.Count - 1){

            index2 = 0;
        }

        ChangeScreen1();
        ChangeScreen2();
    }

    void ChangeScreen1(){

        PlayerPrefs.SetInt("Jugador1Index", index1);
        image1.sprite = gameManager.characters1[index1].image;
    }
    
    void ChangeScreen2(){

        PlayerPrefs.SetInt("Jugador2Index", index2);
        image2.sprite = gameManager.characters2[index2].image;
    }

    public void NextCharacter1(){

        if (index1 == gameManager.characters1.Count - 1){
        
            index1 = 0;
        }else{

            index1 += 1;
        }

        ChangeScreen1();
    }
    
    public void NextCharacter2(){

        if (index2 == gameManager.characters2.Count - 1){
        
            index2 = 0;
        }else{

            index2 += 1;
        }

        ChangeScreen2();
    }

    public void PrevCharacter1(){

        if (index1 == 0){

            index1 = gameManager.characters1.Count - 1;
        }else{

            index1 -= 1;
        }

        ChangeScreen1();
    }
    
    public void PrevCharacter2(){

        if (index2 == 0){

            index2 = gameManager.characters2.Count - 1;
        }else{

            index2 -= 1;
        }

        ChangeScreen2();
    }
}