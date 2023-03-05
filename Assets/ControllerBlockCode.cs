using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlock
{
    public Vector3 attatchPoint;
    public Vector3 dockPoint;
    public CodeBlock top_block;
    public CodeBlock bottom_block = null;

    // defines the action to be carried out
    private void CharacterAction()
    {

    }

    // attatch another block to this piece
    public void AttatchBlock()
    {
        
    }

    // attatch this piece to another object
    public void AttatchSelfTo()
    {
        
    }

    // run the block
    public CodeBlock ExecuteBlock()
    {

        if (bottom_block != null)
        {
            return bottom_block;
        }
        else { return null; }
    }

}


public class BlockCodeController : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }
}
