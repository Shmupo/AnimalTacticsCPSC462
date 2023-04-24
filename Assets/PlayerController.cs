using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Directions are as follows : "UP" "DOWN" "LEFT" "RIGHT"
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
<<<<<<< Updated upstream
=======
    // must be "land" or "air" or "water
    public string movementType;
    public int attack;
    public int health;
    public static bool isPlayerTurn = true;
    public Tilemap tilemap;
    private GameObject[] enemies;
>>>>>>> Stashed changes

    // move the movePoint in a given direction by 1 tile
    public void changeMovePoint(string direction)
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
            moveVector = new Vector3(1, 0, 0);
        }
        else if (direction == "MoveRightBlock")
        {
            moveVector = new Vector3(-1, 0, 0);
        }
        else { moveVector = Vector3.zero;  }

        movePoint.position += moveVector;
    }

    public void DoAction(string name, int value)
    {
        if (name == "MoveUpBlock")
        {
            
        }
        else if (name == "MoveDownBlock")
        {
            
        }
        else if (name == "MoveLeftBlock")
        {
            
        }
        else if (name == "MoveRightBlock")
        {
            
        }
        else if (name == "AttackBlock")
        {

<<<<<<< Updated upstream
=======
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
        PlayerController.isPlayerTurn = false; // End player's turn
    }


    // all enemies 1-grid square within this character takes damage
    private void AttackAll()
    {
        List<GameObject> nearbyEnemies = GetCloseEnemies();
        
        foreach (var enemy in nearbyEnemies)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(attack);
        }
    }

    // return a list of enemies 1-grid square away
    private List<GameObject> GetCloseEnemies()
    {
        List<GameObject> closeEnemies = new List<GameObject>();

        foreach (var enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= 1.2)
            {
                closeEnemies.Add(enemy);
            }
        }

        return closeEnemies;
    }

    // called by other entities to make this one take damage
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    // check if tile to move to is passable, false if not
    private bool CheckMoveTile()
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
>>>>>>> Stashed changes
        }
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
