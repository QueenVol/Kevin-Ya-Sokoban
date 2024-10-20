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
    public ClingyBehavior clingyBehavior;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        playerPosition = gridObject.gridPosition;
        wallBehavior = FindObjectOfType<WallBehavior>();
        smoothBehavior = FindObjectOfType<SmoothBehavior>();
        stickyBehavior = FindObjectOfType<StickyBehavior>();
        clingyBehavior = FindObjectOfType<ClingyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerPosition);
        thePosition = gridObject.gridPosition;
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerPosition.y--;
            if (stickyBehavior.moveWithPlayer)
            {
                if (stickyBehavior.up != wallBehavior.wallPosition)
                {
                    if (stickyBehavior.moveWithSmooth && stickyBehavior.stickyPosition.x == smoothBehavior.smoothPosition.x && stickyBehavior.stickyPosition.y > smoothBehavior.smoothPosition.y)
                    {
                        smoothBehavior.toUp = true;
                    }
                    else
                    {
                        stickyBehavior.stickyPosition.y--;
                    }
                }
                else if (stickyBehavior.up == wallBehavior.wallPosition && playerPosition.x == stickyBehavior.stickyPosition.x)
                {
                    playerPosition = gridObject.gridPosition;
                }
            }
            if (playerPosition == wallBehavior.wallPosition || playerPosition == clingyBehavior.clingyPosition)
            {
                playerPosition = gridObject.gridPosition;
                if (stickyBehavior.moveWithPlayer)
                {
                    stickyBehavior.stickyPosition.y++;
                }
            }
            else if (playerPosition == smoothBehavior.smoothPosition)
            {
                smoothBehavior.toUp = true;
            }
            else if (thePosition == clingyBehavior.up)
            {
                clingyBehavior.toUp = true;
                gridObject.gridPosition = playerPosition;
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
            //Debug.Log(clingyBehavior.toUp);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerPosition.x--;
            if (stickyBehavior.moveWithPlayer)
            {
                if (stickyBehavior.left != wallBehavior.wallPosition)
                {
                    if (stickyBehavior.moveWithSmooth && stickyBehavior.stickyPosition.y == smoothBehavior.smoothPosition.y && stickyBehavior.stickyPosition.x > smoothBehavior.smoothPosition.x)
                    {
                        smoothBehavior.toLeft = true;
                    }
                    else
                    {
                        stickyBehavior.stickyPosition.x--;
                    }
                }
                else if (stickyBehavior.left == wallBehavior.wallPosition && playerPosition.y == stickyBehavior.stickyPosition.y)
                {
                    playerPosition = gridObject.gridPosition;
                }
            }
            if (playerPosition == wallBehavior.wallPosition || playerPosition == clingyBehavior.clingyPosition)
            {
                playerPosition = gridObject.gridPosition;
                if (stickyBehavior.moveWithPlayer)
                {
                    stickyBehavior.stickyPosition.x++;
                }
            }
            else if (playerPosition == smoothBehavior.smoothPosition)
            {
                smoothBehavior.toLeft = true;
            }
            else if (thePosition == clingyBehavior.left)
            {
                clingyBehavior.toLeft = true;
                gridObject.gridPosition = playerPosition;
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
                if (stickyBehavior.down != wallBehavior.wallPosition)
                {
                    if (stickyBehavior.moveWithSmooth && stickyBehavior.stickyPosition.x == smoothBehavior.smoothPosition.x && stickyBehavior.stickyPosition.y < smoothBehavior.smoothPosition.y)
                    {
                        smoothBehavior.toDown = true;
                    }
                    else
                    {
                        stickyBehavior.stickyPosition.y++;
                    }
                }
                else if (stickyBehavior.down == wallBehavior.wallPosition && playerPosition.x == stickyBehavior.stickyPosition.x)
                {
                    playerPosition = gridObject.gridPosition;
                }
            }
            if (playerPosition == wallBehavior.wallPosition || playerPosition == clingyBehavior.clingyPosition)
            {
                playerPosition = gridObject.gridPosition;
                if (stickyBehavior.moveWithPlayer)
                {
                    stickyBehavior.stickyPosition.y--;
                }
            }
            else if (playerPosition == smoothBehavior.smoothPosition)
            {
                smoothBehavior.toDown = true;
            }
            else if (thePosition == clingyBehavior.down)
            {
                clingyBehavior.toDown = true;
                gridObject.gridPosition = playerPosition;
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
                if (stickyBehavior.right != wallBehavior.wallPosition)
                {
                    if (stickyBehavior.moveWithSmooth && stickyBehavior.stickyPosition.y == smoothBehavior.smoothPosition.y && stickyBehavior.stickyPosition.x < smoothBehavior.smoothPosition.x)
                    {
                        smoothBehavior.toRight = true;
                    }
                    else
                    {
                        stickyBehavior.stickyPosition.x++;
                    }
                }
                else if (stickyBehavior.right == wallBehavior.wallPosition && playerPosition.y == stickyBehavior.stickyPosition.y)
                {
                    playerPosition = gridObject.gridPosition;
                }
            }
            if (playerPosition == wallBehavior.wallPosition || playerPosition == clingyBehavior.clingyPosition)
            {
                playerPosition = gridObject.gridPosition;
                if (stickyBehavior.moveWithPlayer)
                {
                    stickyBehavior.stickyPosition.x--;
                }
            }
            else if (playerPosition == smoothBehavior.smoothPosition)
            {
                smoothBehavior.toRight = true;
            }
            else if (thePosition == clingyBehavior.right)
            {
                clingyBehavior.toRight = true;
                gridObject.gridPosition = playerPosition;
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
            if (stickyBehavior.moveWithPlayer)
            {
                stickyBehavior.stickyPosition.x++;
            }
            if (clingyBehavior.withPlayer)
            {
                clingyBehavior.canMove = false;
            }
        }
        if (gridObject.gridPosition.x > GridMaker.reference.dimensions.x)
        {
            gridObject.gridPosition.x = gridObject.gridPosition.x - 1;
            playerPosition = gridObject.gridPosition;
            if (stickyBehavior.moveWithPlayer)
            {
                stickyBehavior.stickyPosition.x--;
            }
            if (clingyBehavior.withPlayer)
            {
                clingyBehavior.canMove = false;
            }
        }
        if (gridObject.gridPosition.y < 1)
        {
            gridObject.gridPosition.y = 1;
            playerPosition = gridObject.gridPosition;
            if (stickyBehavior.moveWithPlayer)
            {
                stickyBehavior.stickyPosition.y++;
            }
            if (clingyBehavior.withPlayer)
            {
                clingyBehavior.canMove = false;
            }
        }
        if (gridObject.gridPosition.y > GridMaker.reference.dimensions.y)
        {
            gridObject.gridPosition.y = gridObject.gridPosition.y - 1;
            playerPosition = gridObject.gridPosition;
            if (stickyBehavior.moveWithPlayer)
            {
                stickyBehavior.stickyPosition.y--;
            }
            if (clingyBehavior.withPlayer)
            {
                clingyBehavior.canMove = false;
            }
        }

        if (smoothBehavior.canMove)
        {
            gridObject.gridPosition = playerPosition;
            smoothBehavior.canMove = false;
        }
    }
}