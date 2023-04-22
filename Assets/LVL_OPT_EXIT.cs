using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVL_OPT_EXIT : MonoBehaviour
{
<<<<<<< Updated upstream
   public void LevelSelection()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }//currently doesnt levelselect but simply starts at the next scene
=======
    public void LvlSelect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
>>>>>>> Stashed changes

    public void QuitGame()
    {
        Application.Quit();
    }
}
