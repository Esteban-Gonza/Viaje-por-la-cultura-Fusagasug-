using UnityEngine;

public class FollowThePath : MonoBehaviour{

    [SerializeField] 

    public float moveSpeed = 1f;

    public int waypointIndex = 0;
    public bool moveAllowed = false;
    public bool isMoving = false;
    public Transform[] waypoints;

    void Start() {

        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	void Update(){

        //First stair
        if(waypointIndex == 2 && moveAllowed == false){

            this.transform.position = Vector2.MoveTowards(transform.position,
            waypoints[11].transform.position,
            moveSpeed * Time.deltaTime);

            waypointIndex = 11;
        }

        //Second stair
        if (waypointIndex == 9 && moveAllowed == false){

            this.transform.position = Vector2.MoveTowards(transform.position,
            waypoints[21].transform.position,
            moveSpeed * Time.deltaTime);

            waypointIndex = 21;
        }

        //Third stair
        if (waypointIndex == 25 && moveAllowed == false){

            this.transform.position = Vector2.MoveTowards(transform.position,
            waypoints[30].transform.position,
            moveSpeed * Time.deltaTime);

            waypointIndex = 30;
        }

        //First snake
        if (waypointIndex == 26 && moveAllowed == false){

            this.transform.position = Vector2.MoveTowards(transform.position,
            waypoints[15].transform.position,
            moveSpeed * Time.deltaTime);

            waypointIndex = 15;
        }

        //Second snake
        if (waypointIndex == 34 && moveAllowed == false){

            this.transform.position = Vector2.MoveTowards(transform.position,
            waypoints[18].transform.position,
            moveSpeed * Time.deltaTime);

            waypointIndex = 18;
        }

        if (moveAllowed)
            Move();
	}

    void Move(){

        if (waypointIndex <= waypoints.Length - 1){

            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position){

                waypointIndex += 1;
            }
        }
    }
}