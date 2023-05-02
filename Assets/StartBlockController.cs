using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ##### INFO #####
// This block will control the character when pressed
// It will link to the object titled "Character" by itself on start.
// "Character" must be the name of a sibling object

public class StartBlockController : MonoBehaviour
{
    private List<string> actionStack = new List<string>();
    // this is assigned in the DragBlockController script
    public GameObject childBlock = null;
    public GameObject playerCharacter;
    private PlayerController playerScript = null;


    // The name of the block is used to identify it : "MoveRightBlock" will move the character right
    private void ReadInstructions()
    {
        actionStack.Clear();
        if (childBlock != null) {
            GameObject targetBlock = childBlock;
            while (targetBlock != null)
            {
                var block = targetBlock.GetComponent<DragBlockCode>();
                // store instruction here
                actionStack.Add(block.blockAction);
                targetBlock = block.childBlock;
            }
        }
    }

    // This is essentially the "start round" button
    public void OnMouseUp()
    {
        ReadInstructions();
        ExecuteBlockCode();
        // Enemy turn starts here
        //...
    }

    // iterate through actionStack
    // use DoAction in PlayerControllerScript
    private void ExecuteBlockCode()
    {
        if (actionStack != null)
        {
            StartCoroutine(playerScript.ActivatePlayer(actionStack));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScript = playerCharacter.transform.Find("Character").gameObject.GetComponent<PlayerController>();

        if (playerScript == null ) 
        {
            Debug.LogError("No character found.");
        }
    }
}
