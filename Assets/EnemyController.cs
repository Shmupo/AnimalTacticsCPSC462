using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1.0f; // The speed at which the enemy moves
    public float attackRange = 2.0f; // The distance at which the enemy attacks
    public int health = 1; // The health of the enemy
    public int attack = 3; // The amount of damage the enemy deals
    private PlayerController playerScript = null;
    public GameObject playerCharacter;

    private bool hasMovedThisTurn = false; // To keep track of whether the enemy has moved already this turn

    void Update()
    {
        if (!hasMovedThisTurn)
        {
            PerformAction();
        }
    }

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

            // End the enemy's turn after attacking
            EndTurn();
        }
        else if (distanceToCharacter <= 5)
        {
            // Move towards the player character if they are within 5 blocks
            transform.position += (transform.position - playerCharacter.transform.position).normalized * moveSpeed * Time.deltaTime;
            Debug.Log("Enemy moving towards player character!");
        }
        else
        {
            // Move right 5 blocks in the first turn, and left 5 blocks in the next turn
            if (hasMovedThisTurn)
            {
                transform.position += Vector3.left * 5;
                Debug.Log("Enemy moving left!");
            }
            else
            {
                transform.position += Vector3.right * 5;
                Debug.Log("Enemy moving right!");
            }
        }

        // Mark this turn as having been moved
        hasMovedThisTurn = true;
    }

    public void StartTurn()
    {
        hasMovedThisTurn = false;
        PerformAction();
    }


    // displaying enemy info if this enemy is clicked
    // click again to hide info

    private void start()
    {
        playerScript = playerCharacter.transform.Find("Character").gameObject.GetComponent<PlayerController>();

        if (playerScript == null)
        {
            Debug.LogError("No character found.");
        }

    }

    public void EndTurn()
    {
        // Reset the hasMovedThisTurn flag at the end of each turn
        hasMovedThisTurn = false;

        // Output a message indicating the end of the enemy's turn
        Debug.Log("Enemy turn ended.");
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
