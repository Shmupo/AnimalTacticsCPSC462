using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/Characters/EnemyController.cs
    public GameObject character; // The player character
    public float moveSpeed = 1.0f; // The speed at which the enemy moves
=======
>>>>>>> Stashed changes:Assets/EnemyController.cs
    public float attackRange = 2.0f; // The distance at which the enemy attacks
    public int health = 1; // The health of the enemy
    public int attackDamage = 3; // The amount of damage the enemy deals

    private bool hasMovedThisTurn = false; // To keep track of whether the enemy has moved already this turn

    void Update()
    {
        if (!hasMovedThisTurn && !PlayerController.isPlayerTurn)
        {
            Debug.Log("Now it is the enemy's turn.");

            // Check if the player character is within attack range
<<<<<<< Updated upstream:Assets/Characters/EnemyController.cs
            float distanceToCharacter = Vector3.Distance(transform.position, character.transform.position);
=======
            float distanceToCharacter = Vector3.Distance(transform.position, playerCharacter.transform.position);
            Debug.Log("Distance between enemy and player: " + distanceToCharacter); // Log the distance

>>>>>>> Stashed changes:Assets/EnemyController.cs
            if (distanceToCharacter <= attackRange)
            {
                // Attack the player character
                character.GetComponent<PlayerController>().TakeDamage(attackDamage);
                Debug.Log("Enemy attacked player character!");

                // End the enemy's turn after attacking
                EndTurn();
            }
<<<<<<< Updated upstream:Assets/Characters/EnemyController.cs
            else if (distanceToCharacter <= 5)
            {
                // Move towards the player character if they are within 5 blocks
                transform.position += (character.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
                Debug.Log("Enemy moving towards player character!");
            }
=======
>>>>>>> Stashed changes:Assets/EnemyController.cs
            else
            {
                Debug.Log("Enemy didnt see player character");
                EndTurn();
            }

            // Mark this turn as having been moved
            hasMovedThisTurn = true;
        }
    }

<<<<<<< Updated upstream:Assets/Characters/EnemyController.cs
    public void EndTurn()
=======



    private void Start()
    {
        playerScript = playerCharacter.GetComponent<PlayerController>();

        if (playerScript == null)
        {
            Debug.LogError("No character found.");
        }
    }


   public void EndTurn()
>>>>>>> Stashed changes:Assets/EnemyController.cs
    {
        // Reset the hasMovedThisTurn flag at the end of each turn
        hasMovedThisTurn = false;

        // Switch back to the player's turn
        PlayerController.isPlayerTurn = true;

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
