using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private GridObject gridObject;
    private int gridX;
    private Vector2Int playerPosition;
    public WallBehavior wallBehavior;
    public SmoothBehavior smoothBehavior;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        playerPosition = gridObject.gridPosition;
        wallBehavior = FindObjectOfType<WallBehavior>();
        smoothBehavior = FindObjectOfType<SmoothBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerPosition.y--;
            if (playerPosition == wallBehavior.wallPosition)
            {
                playerPosition = gridObject.gridPosition;
            }
            else if (playerPosition == smoothBehavior.smoothPosition)
            {
                smoothBehavior.toUp = true;
                if (smoothBehavior.canMove)
                {
                    gridObject.gridPosition.y--;
                    playerPosition = gridObject.gridPosition;
                    smoothBehavior.canMove = false;
                }
                else
                {
                    playerPosition = gridObject.gridPosition;
                }
            }
            else
            {
                gridObject.gridPosition.y--;
                playerPosition = gridObject.gridPosition;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerPosition.x--;
            if (playerPosition == wallBehavior.wallPosition)
            {
                playerPosition = gridObject.gridPosition;
            }
            else if (playerPosition == smoothBehavior.smoothPosition)
            {
                smoothBehavior.toLeft = true;
                if (smoothBehavior.canMove)
                {
                    gridObject.gridPosition.x--;
                    playerPosition = gridObject.gridPosition;
                    smoothBehavior.canMove = false;
                }
                else
                {
                    playerPosition = gridObject.gridPosition;
                }
            }
            else
            {
                gridObject.gridPosition.x--;
                playerPosition = gridObject.gridPosition;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerPosition.y++;
            if (playerPosition == wallBehavior.wallPosition)
            {
                playerPosition = gridObject.gridPosition;
            }
            else if (playerPosition == smoothBehavior.smoothPosition)
            {
                smoothBehavior.toDown = true;
                if (smoothBehavior.canMove)
                {
                    gridObject.gridPosition.y++;
                    playerPosition = gridObject.gridPosition;
                    smoothBehavior.canMove = false;
                }
                else
                {
                    playerPosition = gridObject.gridPosition;
                }
            }
            else
            {
                gridObject.gridPosition.y++;
                playerPosition = gridObject.gridPosition;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerPosition.x++;
            if (playerPosition == wallBehavior.wallPosition)
            {
                playerPosition = gridObject.gridPosition;
            }
            else if (playerPosition == smoothBehavior.smoothPosition)
            {
                smoothBehavior.toRight = true;
                if (smoothBehavior.canMove)
                {
                    gridObject.gridPosition.x++;
                    playerPosition = gridObject.gridPosition;
                    smoothBehavior.canMove = false;
                }
                else
                {
                    playerPosition = gridObject.gridPosition;
                }
            }
            else
            {
                gridObject.gridPosition.x++;
                playerPosition = gridObject.gridPosition;
            }
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
