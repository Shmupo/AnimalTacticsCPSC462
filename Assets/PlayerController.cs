using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Tilemaps;

// ##### INFO #####
// Defines and implements actions for the character
// Actions are called from the start block controller

// Directions are as follows : "Up" "Down" "Left" "Right"
public class PlayerController : MonoBehaviour
{
    // These are assigned within the unity editor inspector window
    public float moveSpeed;
    public Transform movePoint;
    // must be "land" or "air" or "water
    public string movementType;
    public int attack;
    public int health;

    public Tilemap tilemap;
    private GameObject[] enemies;

    // move the movePoint in a given direction by 1 tile
    private void ChangeMovePoint(string direction)
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
            if (CheckMoveTile())
            {
                ChangeMovePoint(name);
            }
        }
        else if (name == "Down")
        {
            if (CheckMoveTile())
            {
                ChangeMovePoint(name);
            }
        }
        else if (name == "Left")
        {
            if (CheckMoveTile())
            {
                ChangeMovePoint(name);
            }
        }
        else if (name == "Right")
        {
            if (CheckMoveTile())
            {
                ChangeMovePoint(name);
            }
        }
        else if (name == "Attack")
        {
            AttackAll();
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

    // Initializing the enemies list
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
