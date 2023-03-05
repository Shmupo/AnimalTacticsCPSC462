using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBlockCode : MonoBehaviour
{
    private bool isDragging;

    private float snapDistance = 0.5f;
    // How much to move down the block when snapping
    private Vector3 blockAttatchOffset = new Vector3 (0f, -1.25f, 0f);

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }

        GameObject[] blockList = GameObject.FindGameObjectsWithTag("BlockCode");

        foreach (GameObject block in blockList)
        {
            if (block == gameObject) { continue; }

            float distance = Vector2.Distance(transform.position, block.transform.position);

            if (distance < snapDistance) 
            {
                transform.position = block.transform.position + blockAttatchOffset;
            }
        }
    }
}
