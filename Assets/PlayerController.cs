using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Directions are as follows : "UP" "DOWN" "LEFT" "RIGHT"
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    // move the movePoint in a given direction by 1 tile
    public void changeMovePoint(string direction)
    {
        Vector3 moveVector;

        if (direction == "UP")
        {
            moveVector = new Vector3(0, 1, 0);
        }
        else if (direction == "DOWN")
        {
            moveVector = new Vector3(0, -1, 0);
        }
        else if (direction == "LEFT")
        {
            moveVector = new Vector3(1, 0, 0);
        }
        else if (direction == "RIGHT")
        {
            moveVector = new Vector3(-1, 0, 0);
        }
        else { moveVector = Vector3.zero;  }

        movePoint.position += moveVector;
    }

    // move the character to the move point
    public void MoveToPoint()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        changeMovePoint("UP");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
