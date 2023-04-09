using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Tilemaps;

// ##### INFO #####
// Defines and implements actions for the character
// Actions are called from the start block controller

// Directions are as follows : "UP" "DOWN" "LEFT" "RIGHT"
public class PlayerController : MonoBehaviour
{
    // These are assigned within the unity editor inspector window
    public float moveSpeed;
    public Transform movePoint;
    // must be "land" or "air" or "water
    public string movementType;

    public Tilemap tilemap;

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

    public void DoAction(string name)
    {
        if (name == "Up")
        {
            changeMovePoint(name);
            if (!checkMoveTile())
            {
                changeMovePoint("Down");
            }
        }
        else if (name == "Down")
        {
            changeMovePoint(name);
            if (!checkMoveTile())
            {
                changeMovePoint("Up");
            }
        }
        else if (name == "Left")
        {
            changeMovePoint(name);
            if (!checkMoveTile())
            {
                changeMovePoint("Right");
            }
        }
        else if (name == "Right")
        {
            changeMovePoint(name);
            if (!checkMoveTile())
            {
                changeMovePoint("Left");
            }
        }
        else if (name == "Attack")
        {

        }
    }

    // moves player again after previous move is done
    public IEnumerator ActivatePlayer(List<string> actionStack)
    {
        foreach (string action in actionStack)
        {
            DoAction(action);

            while (transform.position != movePoint.position)
            {
                MoveToPoint();
                StartCoroutine(MoveToPoint());
                yield return new WaitUntil(() => transform.position == movePoint.position); // wait for the next frame
            }
        }
    }

    // check if tile to move to is passable, false if not
    private bool checkMoveTile()
    {
        Vector3Int movePointTile = tilemap.WorldToCell(movePoint.position);
        TileBase tile = tilemap.GetTile(movePointTile);

        if (tile is CustomTile customTile)
        {
            if (customTile.tileType != movementType)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    // move the character to the move point
    // needs to be called through Update()
    private IEnumerator MoveToPoint()
    {
        while (transform.position != movePoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, Time.deltaTime * moveSpeed);
            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }
}
