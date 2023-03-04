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
    private bool isDragging = false;
    private Vector3 dragStartPosition;

    void OnMouseDown()
    {
        isDragging = true;
        dragStartPosition = transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Called every frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + dragStartPosition;
        }
    }
}
