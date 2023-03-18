using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ##### INFO #####
// This block will control the character when pressed
// It will link to the object titled "Character" by itself on start.
// "Character" must be the name of a sibling object

public class StartBlockController : MonoBehaviour
{
    // name is the name of the action, value is how much movement or attack
    // default for value is 1
    private class Action<T1, T2>
    {
        public string name;
        public int value = 1;

        public Action(string name, int value)
        {
            this.name = name;
            this.value = value;
        }

        public Action(string name)
        {
            this.name = name;
        }
    }

    private List<Action<string, int>> actionStack = new List<Action<string, int>>();
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
                actionStack.Add(new Action<string, int>(block.blockAction, 1));
                targetBlock = block.childBlock;
            }
        }
    }

    public void OnMouseUp()
    {
        ReadInstructions();
        ExecuteBlockCode();
        // debugging
        Debug.Log(actionStack);
    }

    // iterate through actionStack
    // use DoAction in PlayerControllerScript
    private void ExecuteBlockCode()
    {
        if (actionStack != null)
        {
            foreach (Action<string, int> charAction in actionStack)
            {
                playerScript.DoAction(charAction.name, charAction.value);
            }
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
