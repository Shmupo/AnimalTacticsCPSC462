using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlockController : MonoBehaviour
{
    // name is the name of the action, value is how much movement or attack
    // default for value is 1
    private class Action<T1, T2>
    {
        public string name;
        public int value = 1;

        public Action(string name, int action)
        {
            this.name = name;
            this.value = action;
        }

        public Action(string name)
        {
            this.name = name;
        }
    }

    private List<Action<string, int>> actionStack = new List<Action<string, int>>();

    // this is assigned in the DragBlockController script
    public GameObject childBlock = null;

    private void StoreInstructions()
    {
        if (childBlock != null) {
            GameObject targetBlock = childBlock;
            while (targetBlock != null)
            {
                DragBlockCode block = targetBlock.GetComponent<DragBlockCode>();
                // store instruction here

                targetBlock = block.childBlock;
            }
        }


        actionStack = null;
    }

    public void OnMouseUp()
    {
        
    }

    private void ExecuteBlockCode()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
