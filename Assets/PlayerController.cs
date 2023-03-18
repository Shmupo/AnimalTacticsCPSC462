using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ##### INFO #####
// Defines and implements actions for the character
// Actions are called from the start block controller

// Directions are as follows : "UP" "DOWN" "LEFT" "RIGHT"
public class PlayerController : MonoBehaviour
{
    // These are assigned within the unity editor inspector window
    public float moveSpeed;
    public Transform movePoint;

    // move the movePoint in a given direction by 1 tile
    private void changeMovePoint(string direction)
    {
        Vector3 moveVector;

        if (direction == "Up")
        {
            moveVector = new Vector3(0, 1, 0);
        }
        else if (direction == "Down")
        {
            moveVector = new Vector3(0, -1, 0);
        }
        else if (direction == "Left")
        {
            moveVector = new Vector3(-1, 0, 0);
        }
        else if (direction == "Right")
        {
            moveVector = new Vector3(1, 0, 0);
        }
        else { moveVector = Vector3.zero;  }

        movePoint.position += moveVector;
    }

    // called in other scripts to make the character do something
    public void DoAction(string name, int value)
    {
        if (name == "Up")
        {
            changeMovePoint(name);
        }
        else if (name == "Down") 
        {
            changeMovePoint(name);
        }
        else if (name == "Left") 
        {
            changeMovePoint(name);
        }
        else if (name == "Right") 
        {
            changeMovePoint(name);
        }
        else if (name == "Attack") 
        {

        }
    }

    // move the character to the move point
    // needs to be called through Update()
    private void MoveToPoint()
    {
        if (transform.position != movePoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, Time.deltaTime * moveSpeed);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPoint();
    }
}
