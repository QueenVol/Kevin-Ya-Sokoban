using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private GridObject gridObject;
    private int gridX;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gridObject.gridPosition.y--;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            gridObject.gridPosition.x--;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gridObject.gridPosition.y++;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gridObject.gridPosition.x++;
        }
        if (gridObject.gridPosition.x < 1)
        {
            gridObject.gridPosition.x = 1;
        }
        if (gridObject.gridPosition.x > GridMaker.reference.dimensions.x)
        {
            gridObject.gridPosition.x = gridObject.gridPosition.x - 1;
        }
        if (gridObject.gridPosition.y < 1)
        {
            gridObject.gridPosition.y = 1;
        }
        if (gridObject.gridPosition.y > GridMaker.reference.dimensions.y)
        {
            gridObject.gridPosition.y = gridObject.gridPosition.y - 1;
        }
    }
}
