using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour{

    Sprite[] diceSides;
    SpriteRenderer rend;
    public int whosTurn = 1;
    bool coroutineAllowed = true;

	void Start () {

        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
	}

    void OnMouseDown(){

        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    IEnumerator RollTheDice(){

        coroutineAllowed = false;
        int randomDiceSide = 0;

        for (int i = 0; i <= 20; i++){

            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;
        if (whosTurn == 1){

            GameControl.MovePlayer(1);
        }else if (whosTurn == -1){

            GameControl.MovePlayer(2);
        }

        this.gameObject.SetActive(false);
        QuizManager.instance.GenerateQuestion();

        whosTurn *= -1;
        coroutineAllowed = true;
    }
}