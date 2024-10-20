using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private GridObject gridObject;
    private int gridX;
    public Vector2Int playerPosition;
    public Vector2Int thePosition;
    public WallBehavior wallBehavior;
    public SmoothBehavior smoothBehavior;
    public StickyBehavior stickyBehavior;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        playerPosition = gridObject.gridPosition;
        wallBehavior = FindObjectOfType<WallBehavior>();
        smoothBehavior = FindObjectOfType<SmoothBehavior>();
        stickyBehavior = FindObjectOfType<StickyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerPosition);
        thePosition = gridObject.gridPosition;
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerPosition.y--;
            if (stickyBehavior.moveWithPlayer)
            {
                stickyBehavior.stickyPosition.y--;
            }
            if (playerPosition == wallBehavior.wallPosition)
            {
                playerPosition = gridObject.gridPosition;
                stickyBehavior.stickyPosition.y++;
            }
            else if (playerPosition == smoothBehavior.smoothPosition)
            {
                smoothBehavior.toUp = true;
            }
            else
            {
                if (stickyBehavior.stickyPosition.y < 1)
                {
                    playerPosition = gridObject.gridPosition;
                }
                else
                {
                    gridObject.gridPosition = playerPosition;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerPosition.x--;
            if (stickyBehavior.moveWithPlayer)
            {
                stickyBehavior.stickyPosition.x--;
            }
            if (playerPosition == wallBehavior.wallPosition)
            {
                playerPosition = gridObject.gridPosition;
                stickyBehavior.stickyPosition.x++;
            }
            else if (playerPosition == smoothBehavior.smoothPosition)
            {
                smoothBehavior.toLeft = true;
            }
            else
            {
                if (stickyBehavior.stickyPosition.x < 1)
                {
                    playerPosition = gridObject.gridPosition;
                }
                else
                {
                    gridObject.gridPosition = playerPosition;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerPosition.y++;
            if (stickyBehavior.moveWithPlayer)
            {
                stickyBehavior.stickyPosition.y++;
            }
            if (playerPosition == wallBehavior.wallPosition)
            {
                playerPosition = gridObject.gridPosition;
                stickyBehavior.stickyPosition.y--;
            }
            else if (playerPosition == smoothBehavior.smoothPosition)
            {
                smoothBehavior.toDown = true;
            }
            else
            {
                if (stickyBehavior.stickyPosition.y > GridMaker.reference.dimensions.y)
                {
                    playerPosition = gridObject.gridPosition;
                }
                else
                {
                    gridObject.gridPosition = playerPosition;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerPosition.x++;
            if (stickyBehavior.moveWithPlayer)
            {
                stickyBehavior.stickyPosition.x++;
            }
            if (playerPosition == wallBehavior.wallPosition)
            {
                playerPosition = gridObject.gridPosition;
                stickyBehavior.stickyPosition.x--;
            }
            else if (playerPosition == smoothBehavior.smoothPosition)
            {
                smoothBehavior.toRight = true;
            }
            else
            {
                if (stickyBehavior.stickyPosition.x > GridMaker.reference.dimensions.x)
                {
                    playerPosition = gridObject.gridPosition;
                }
                else
                {
                    gridObject.gridPosition = playerPosition;
                }
            }
        }

        if (gridObject.gridPosition.x < 1)
        {
            gridObject.gridPosition.x = 1;
            playerPosition = gridObject.gridPosition;
        }
        if (gridObject.gridPosition.x > GridMaker.reference.dimensions.x)
        {
            gridObject.gridPosition.x = gridObject.gridPosition.x - 1;
            playerPosition = gridObject.gridPosition;
        }
        if (gridObject.gridPosition.y < 1)
        {
            gridObject.gridPosition.y = 1;
            playerPosition = gridObject.gridPosition;
        }
        if (gridObject.gridPosition.y > GridMaker.reference.dimensions.y)
        {
            gridObject.gridPosition.y = gridObject.gridPosition.y - 1;
            playerPosition = gridObject.gridPosition;
        }

        if (smoothBehavior.canMove)
        {
            gridObject.gridPosition = playerPosition;
            smoothBehavior.canMove = false;
        }
    }
}
