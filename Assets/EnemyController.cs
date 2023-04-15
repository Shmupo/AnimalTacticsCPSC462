using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject character; // The player character
    public float moveSpeed = 1.0f; // The speed at which the enemy moves
    public float attackRange = 2.0f; // The distance at which the enemy attacks
    public int health = 1; // The health of the enemy
    public int attackDamage = 3; // The amount of damage the enemy deals

    private bool hasMovedThisTurn = false; // To keep track of whether the enemy has moved already this turn

    void Update()
    {
        if (!hasMovedThisTurn)
        {
            // Check if the player character is within attack range
            float distanceToCharacter = Vector3.Distance(transform.position, character.transform.position);
            if (distanceToCharacter <= attackRange)
            {
                // Attack the player character
                character.GetComponent<PlayerController>().TakeDamage(attackDamage);
                Debug.Log("Enemy attacked player character!");

                // End the enemy's turn after attacking
                EndTurn();
            }
            else if (distanceToCharacter <= 5)
            {
                // Move towards the player character if they are within 5 blocks
                transform.position += (character.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
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
