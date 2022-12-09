using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayer : MonoBehaviour{
    
    void Start(){

        int playerIndex1 = PlayerPrefs.GetInt("Jugador1Index");
        var player1 = Instantiate(GameManager.instance.characters1[playerIndex1].playableCharacter, transform.position, Quaternion.identity);
        player1.name = "Player1";


        int playerIndex2 = PlayerPrefs.GetInt("Jugador2Index");
        var player2 = Instantiate(GameManager.instance.characters2[playerIndex2].playableCharacter, transform.position, Quaternion.identity);
        player2.name = "Player2";
    }
}