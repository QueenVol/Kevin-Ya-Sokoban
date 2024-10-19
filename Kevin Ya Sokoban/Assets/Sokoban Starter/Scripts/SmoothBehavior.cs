using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothBehavior : MonoBehaviour
{
    private GridObject gridObject;
    public Vector2Int smoothPosition;
    public bool toRight = false;
    public bool toLeft = false;
    public bool toUp = false;
    public bool toDown = false;
    public bool canMove;
    public WallBehavior wallBehavior;
    public PlayerBehavior playerBehavior;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        smoothPosition = gridObject.gridPosition;
        wallBehavior = FindObjectOfType<WallBehavior>();
        playerBehavior = FindObjectOfType<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toUp)
        {
            smoothPosition.y--;
            if (smoothPosition == wallBehavior.wallPosition || smoothPosition.y < 1)
            {
                canMove = false;
                smoothPosition = gridObject.gridPosition;
                playerBehavior.playerPosition = playerBehavior.thePosition;
            }
            else
            {
                gridObject.gridPosition = smoothPosition;
                canMove = true;
            }
            toUp = false;
        }
        if (toLeft)
        {
            smoothPosition.x--;
            if (smoothPosition == wallBehavior.wallPosition || smoothPosition.x < 1)
            {
                canMove = false;
                smoothPosition = gridObject.gridPosition;
                playerBehavior.playerPosition = playerBehavior.thePosition;
            }
            else
            {
                canMove = true;
                gridObject.gridPosition = smoothPosition;
            }
            toLeft = false;
        }
        if (toDown)
        {
            smoothPosition.y++;
            if (smoothPosition == wallBehavior.wallPosition || smoothPosition.y > GridMaker.reference.dimensions.y)
            {
                canMove = false;
                smoothPosition = gridObject.gridPosition;
                playerBehavior.playerPosition = playerBehavior.thePosition;
            }
            else
            {
                canMove = true;
                gridObject.gridPosition = smoothPosition;
            }
            toDown = false;
        }
        if (toRight)
        {
            smoothPosition.x++;
            if (smoothPosition == wallBehavior.wallPosition || smoothPosition.x > GridMaker.reference.dimensions.x)
            {
                canMove = false;
                smoothPosition = gridObject.gridPosition;
                playerBehavior.playerPosition = playerBehavior.thePosition;
            }
            else
            {
                canMove = true;
                gridObject.gridPosition = smoothPosition;
            }
            toRight = false;
        }
    }
}
