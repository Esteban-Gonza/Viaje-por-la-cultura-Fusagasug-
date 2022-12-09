using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    
    public static GameManager instance;
    public List<Character> characters1;
    public List<Character2> characters2;

    void Awake(){

        if (instance == null) { 
        
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else{

            Destroy(gameObject);
        }
    }
}