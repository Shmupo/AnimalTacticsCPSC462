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
        else
        {
            // Move towards the player character if they are within 5 blocks
            transform.position += (transform.position - playerCharacter.transform.position).normalized * moveSpeed * Time.deltaTime;
            Debug.Log("Enemy moving towards player character!");
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
