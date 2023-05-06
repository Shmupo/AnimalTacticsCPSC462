using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1.0f; // The speed at which the enemy moves
    public float attackRange = 2.0f; // The distance at which the enemy attacks
    public int health = 1; // The health of the enemy
    public int attack = 3; // The amount of damage the enemy deals
    public int AP = 2; // Action Points
    public PlayerController playerScript;
    public GameObject playerCharacter;

    public MainHUDScript HUD;

    // Display HUD for clicked enemy
    void OnMouseUp()
    {
        HUD.ToggleEnemy(gameObject);
    }

    // Modify this so that the enemy will move the specified number of action points (AP)
    // The enemy should move 1 unit of distance per action
    private void PerformAction()
    {
        // Check if the player character is within attack range
        float distanceToCharacter = Vector3.Distance(transform.position, playerCharacter.transform.position);
        if (distanceToCharacter <= attackRange)
        {
            // Attack the player character
            if (playerScript != null)
            {
                playerScript.TakeDamage(attack);
                Debug.Log("Enemy attacked player character!");
            }
        }
        else{
            // Move towards the player character one block each time, it can only move horizontal or vertical and keeps 1 block distance away from players
            // so find x and y distance from the player
            float xDistance = Mathf.Abs(transform.position.x - playerCharacter.transform.position.x);
            float yDistance = Mathf.Abs(transform.position.y - playerCharacter.transform.position.y);
            // if x distance is greater than y distance, move horizontally
            if (xDistance > yDistance)
            {
                // if the enemy is to the left of the player, move right
                if (transform.position.x < playerCharacter.transform.position.x)
                {
                    transform.position += new Vector3(1, 0, 0);
                    Debug.Log("Enemy is moving right");
                }
                // if the enemy is to the right of the player, move left
                else if (transform.position.x > playerCharacter.transform.position.x)
                {
                    transform.position += new Vector3(-1, 0, 0);
                    Debug.Log("Enemy is moving left");
                }
            }
            // if y distance is greater than x distance, move vertically
            else if (yDistance > xDistance)
            {
                // if the enemy is below the player, move up
                if (transform.position.y < playerCharacter.transform.position.y)
                {
                    transform.position += new Vector3(0, 1, 0);
                    Debug.Log("Enemy is moving up");
                }
                // if the enemy is above the player, move down
                else if (transform.position.y > playerCharacter.transform.position.y)
                {
                    transform.position += new Vector3(0, -1, 0);
                    Debug.Log("Enemy is moving down");
                }
            }
            

        }
    }

    public void StartTurn()
    {
        PerformAction();
    }

    public void DeleteEnemy()
    {
        // Output a message indicating that the enemy is dead
        Debug.Log("Enemy dead.");
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DeleteEnemy();
        }
        else
        {
            // Output a message indicating that the enemy has been damaged
            Debug.Log("Enemy has been damaged.");
        }
    }
}
