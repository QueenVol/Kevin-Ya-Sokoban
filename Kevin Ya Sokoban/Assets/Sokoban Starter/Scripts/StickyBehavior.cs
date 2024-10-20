using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBehavior : MonoBehaviour
{
    private GridObject gridObject;
    public Vector2Int stickyPosition;
    public Vector2Int up;
    public Vector2Int left;
    public Vector2Int down;
    public Vector2Int right;
    public PlayerBehavior playerBehavior;
    public bool moveWithPlayer;
    public WallBehavior wallBehavior;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        stickyPosition = gridObject.gridPosition;
        playerBehavior = FindObjectOfType<PlayerBehavior>();
        wallBehavior = FindObjectOfType<WallBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(stickyPosition);
        up = stickyPosition;
        up.y = stickyPosition.y - 1;
        left = stickyPosition;
        left.x = stickyPosition.x - 1;
        down = stickyPosition;
        down.y = stickyPosition.y + 1;
        right = stickyPosition;
        right.x = stickyPosition.x + 1;

        if (up == playerBehavior.thePosition || left == playerBehavior.thePosition || down == playerBehavior.thePosition || right == playerBehavior.thePosition)
        {
            moveWithPlayer = true;
        }
        else
        {
            moveWithPlayer = false;
        }

        gridObject.gridPosition = stickyPosition;

        if (gridObject.gridPosition.x < 1)
        {
            gridObject.gridPosition.x = 1;
            stickyPosition = gridObject.gridPosition;
        }
        if (gridObject.gridPosition.x > GridMaker.reference.dimensions.x)
        {
            gridObject.gridPosition.x = gridObject.gridPosition.x - 1;
            stickyPosition = gridObject.gridPosition;
        }
        if (gridObject.gridPosition.y < 1)
        {
            gridObject.gridPosition.y = 1;
            stickyPosition = gridObject.gridPosition;
        }
        if (gridObject.gridPosition.y > GridMaker.reference.dimensions.y)
        {
            gridObject.gridPosition.y = gridObject.gridPosition.y - 1;
            stickyPosition = gridObject.gridPosition;
        }
    }
}
