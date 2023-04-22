using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoryCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void checkVictory()
    {
        //if # of enemy units == 0 create a victory screen
        //questions to ask, how do i count the number of units?
        //like what object name does each unit go under?
    }

    // Update is called once per frame
    void checkDefeat()
    {
        //if # of Ally units == 0 create a defeat screen.
    }

    //so in the actual code we do checkDefeat first, and if checkDefeat is false(aka not defeated yet) then we move onto checkVictory.

}
