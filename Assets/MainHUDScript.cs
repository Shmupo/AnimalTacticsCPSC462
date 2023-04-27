using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Call Hide() and Display() from here for HUD visibility
// More HUD functionality in other scripts

public class MainHUDScript : MonoBehaviour
{
    // Set in the inspector
    public Canvas canvas;
    public PlayerStatWindow pScript;
    public EnemyStatWindow eScript;

    private GameObject currentPlayer;
    private GameObject currentEnemy;

    // do ChangeChar when applicable

    public void TogglePlayer(GameObject playerChar)
    {
        if(currentPlayer != playerChar)
        {
            currentPlayer = playerChar;
            pScript.ChangeChar(playerChar);
        }

        if(pScript.hiding == true)
        {
            pScript.Display();
        }
        else
        {
            pScript.Hide();
        }
    }

    public void ToggleEnemy(GameObject enemyChar)
    {
        if(currentEnemy != enemyChar)
        {
            currentEnemy = enemyChar;
            eScript.ChangeChar(enemyChar);
        }
        
        if(eScript.hiding == true)
        {
            eScript.Display();
        }
        else
        {
            eScript.Hide();
        }
    }
}
