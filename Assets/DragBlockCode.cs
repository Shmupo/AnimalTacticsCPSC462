using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ##### INFO #####
// Script for code blocks.
// Add this as a component of the sprite.
// Sprites need to be tagged as "BlockCode" in order for this code to snap onto other blocks
// Sprite must have a Box Collider 2D in order to be dragged
// blockAction is to be defined in the editor, check playercontroller for valid names

// TODO : Show preview of where this piece will end up if it can snap to another block.

public class DragBlockCode : MonoBehaviour
{
    private bool isDragging;
    // for referencing block connected on top
    public GameObject parentBlock;
    // for referencing block connectd on bottom
    public GameObject childBlock;
    // what the block will do
    public string blockAction;

    private float snapDistanceX = 0.5f;
    private float snapDistanceY = 1f;
    // How much to move down the block when snapping
    private Vector3 blockAttatchOffset = new Vector3 (0f, -1.25f, 0f);
    // For attatching below
    private Vector2 extendY = new Vector2 (0f, 1f);

    public void OnMouseDown()
    {
        isDragging = true;
        
        if (parentBlock != null) 
        {
            Debug.Log(parentBlock);
            UnassignParent(parentBlock);
        }
    }

    public void OnMouseUp()
    {
        isDragging = false;

        GameObject[] blockList = GameObject.FindGameObjectsWithTag("BlockCode");

        foreach (GameObject block in blockList)
        {
            if (block == gameObject) { continue; }

            if (SnapToBottom(block))
            {
                AssignParent(block);
                break;
            }
        }
    }

    // also drags child blocks
    public void Drag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePos);

        if(childBlock != null)
        {
            childBlock.transform.Translate(mousePos);
        }
    }

    // snap this block to the bottom of another
    // return true if snapped
    private bool SnapToBottom(GameObject block)
    {
        // check collision with another block
        float distanceX = Mathf.Abs(transform.position.x - block.transform.position.x);
        float distanceY = Mathf.Abs(transform.position.y - block.transform.position.y + 1.0f);

        if (distanceX < snapDistanceX && distanceY < snapDistanceY)
        {
            transform.position = block.transform.position + blockAttatchOffset;
            if (block.name == "MainStartBlock")
            {
                transform.position += new Vector3(0f, 0.1f, 0f);

                if (childBlock != null)
                {
                    childBlock.transform.position = transform.position - new Vector3(0f, 1.25f, .0f);
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    // Links both child(this object) and parent
    private void AssignParent(GameObject parent)
    {
        if (parent == null) {
            Debug.LogError("Parent is null");
            return;
        }
        parentBlock = parent;
        var dragBlockCode = parentBlock.GetComponent<DragBlockCode>();
        if (dragBlockCode != null)
        {
            dragBlockCode.childBlock = gameObject;
            return;
        }

        var startBlockController = parentBlock.GetComponent<StartBlockController>();
        if (startBlockController != null)
        {
            startBlockController.childBlock = gameObject;
            return;
        }

        Debug.LogError("No child component found in parent.");
    }

    // remove parent/child links relating to the parent
    private void UnassignParent(GameObject parent)
    {
        if (parent != null)
        {
            var childComponent = parent.GetComponent<DragBlockCode>();
            if (childComponent != null)
            {
                childComponent.childBlock = null;
            }
            else
            {
                parent.GetComponent<StartBlockController>().childBlock = null;
            }
            parentBlock = null;
        }
        else
        {
            Debug.LogError("Parent already null.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Drag();
        }
    }
}
