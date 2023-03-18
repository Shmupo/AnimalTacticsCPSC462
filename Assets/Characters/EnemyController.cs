using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject character; // The player character
    public float moveSpeed = 1.0f; // The speed at which the enemy moves
    public float attackRange = 2.0f; // The distance at which the enemy attacks

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
                Debug.Log("Attacking player character!");
            }
            else
            {
                // Move towards the player character if they are within 5 blocks
                if (distanceToCharacter <= 5)
                {
                    transform.position += (character.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
                }
                else
                {
                    // Move right 5 blocks in the first turn, and left 5 blocks in the next turn
                    if (hasMovedThisTurn)
                    {
                        transform.position += Vector3.left * 5;
                    }
                    else
                    {
                        transform.position += Vector3.right * 5;
                    }
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
    }
}
