using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour{

    public static GameControl instance;

    static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;
    static GameObject player1, player2;
    [SerializeField] GameObject returnMenuButton;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject video;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public int score1;
    public int score2;

    public static bool gameOver = false;

    public int Score1{

        get => score1;

        set{

            score1 = value;
            UIManager.instance.UpdateScore1(score1);
        }
    }

    public int Score2{

        get => score2;

        set{

            score2 = value;
            UIManager.instance.UpdateScore2(score2);
        }
    }

    void Awake(){

        if (instance == null){
        
            instance = this;
        }
    }

    void Start(){

        returnMenuButton.SetActive(false);

        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(false);
        video.gameObject.SetActive(false);
    }

    void Update(){

        if (player1.GetComponent<FollowThePath>().waypointIndex > player1StartWaypoint + diceSideThrown){

            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex > player2StartWaypoint + diceSideThrown){

            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player1.GetComponent<FollowThePath>().waypointIndex == player1.GetComponent<FollowThePath>().waypoints.Length){

            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Ganó jugador 1!!";
            returnMenuButton.gameObject.SetActive(true);
            winPanel.gameObject.SetActive(true);
            gameOver = true;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex == player2.GetComponent<FollowThePath>().waypoints.Length){

            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Ganó jugador 2!!";
            returnMenuButton.gameObject.SetActive(true);
            winPanel.gameObject.SetActive(true);
            gameOver = true;
        }
    }

    public static void MovePlayer(int playerToMove){

        switch (playerToMove){
            
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }
}