using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialPopup : MonoBehaviour
{
    public Text healthText;
    public GameObject menuPanel;
    public Text messageText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        // make the tutorial panel visible
        menuPanel.SetActive(true);
        messageText.text = "Press start to begin";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
