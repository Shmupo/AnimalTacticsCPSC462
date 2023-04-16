using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ##### INFO #####
// User can drag off and generate new copies of this block
// Attach as component of block to be copied
// This block will not be dragged itself, but will create a copy of itself to be dragged

// assign blockPrefab in the editor

public class BlockButton : MonoBehaviour
{
    public GameObject blockPrefab;

    public void OnMouseDown()
    {
        GameObject newBlock = Instantiate(blockPrefab);
        newBlock.transform.SetParent(transform);
        var dragScript = newBlock.AddComponent<DragBlockCode>();
        dragScript.OnMouseDown();
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
