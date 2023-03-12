using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (direction == "MoveUpBlock")
        {
            moveVector = new Vector3(0, 1, 0);
        }
        else if (direction == "MoveDownBlock")
        {
            moveVector = new Vector3(0, -1, 0);
        }
        else if (direction == "MoveLeftBlock")
        {
            moveVector = new Vector3(-1, 0, 0);
        }
        else if (direction == "MoveRightBlock")
        {
            moveVector = new Vector3(1, 0, 0);
        }
        else { moveVector = Vector3.zero;  }

        movePoint.position += moveVector;
    }

    // called in other scripts to make the character do something
    public void DoAction(string name, int value)
    {
        if (name == "MoveUpBlock")
        {
            changeMovePoint(name);
        }
        else if (name == "MoveDownBlock") 
        {
            changeMovePoint(name);
        }
        else if (name == "MoveLeftBlock") 
        {
            changeMovePoint(name);
        }
        else if (name == "MoveRightBlock") 
        {
            changeMovePoint(name);
        }
        else if (name == "AttackBlock") 
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
