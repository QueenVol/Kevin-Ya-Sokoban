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
    public ClingyBehavior clingyBehavior;
    public Vector2Int thePosition;
    public StickyBehavior stickyBehavior;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        smoothPosition = gridObject.gridPosition;
        wallBehavior = FindObjectOfType<WallBehavior>();
        playerBehavior = FindObjectOfType<PlayerBehavior>();
        clingyBehavior = FindObjectOfType<ClingyBehavior>();
        stickyBehavior = FindObjectOfType<StickyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        thePosition = gridObject.gridPosition;
        if (toUp)
        {
            smoothPosition.y--;
            if (smoothPosition == wallBehavior.wallPosition || smoothPosition.y < 1 || smoothPosition == clingyBehavior.clingyPosition)
            {
                canMove = false;
                smoothPosition = gridObject.gridPosition;
                playerBehavior.playerPosition = playerBehavior.thePosition;
            }
            else
            {
                gridObject.gridPosition = smoothPosition;
                canMove = true;
                if (stickyBehavior.moveWithSmooth)
                {
                    stickyBehavior.stickyPosition.y--;
                }
            }
            toUp = false;
        }
        if (toLeft)
        {
            smoothPosition.x--;
            if (smoothPosition == wallBehavior.wallPosition || smoothPosition.x < 1 || smoothPosition == clingyBehavior.clingyPosition)
            {
                canMove = false;
                smoothPosition = gridObject.gridPosition;
                playerBehavior.playerPosition = playerBehavior.thePosition;
            }
            else
            {
                canMove = true;
                gridObject.gridPosition = smoothPosition;
                if (stickyBehavior.moveWithSmooth)
                {
                    stickyBehavior.stickyPosition.x--;
                }
            }
            toLeft = false;
        }
        if (toDown)
        {
            smoothPosition.y++;
            if (smoothPosition == wallBehavior.wallPosition || smoothPosition.y > GridMaker.reference.dimensions.y || smoothPosition == clingyBehavior.clingyPosition)
            {
                canMove = false;
                smoothPosition = gridObject.gridPosition;
                playerBehavior.playerPosition = playerBehavior.thePosition;
            }
            else
            {
                canMove = true;
                gridObject.gridPosition = smoothPosition;
                if (stickyBehavior.moveWithSmooth)
                {
                    stickyBehavior.stickyPosition.y++;
                }
            }
            toDown = false;
        }
        if (toRight)
        {
            smoothPosition.x++;
            if (smoothPosition == wallBehavior.wallPosition || smoothPosition.x > GridMaker.reference.dimensions.x || smoothPosition == clingyBehavior.clingyPosition)
            {
                canMove = false;
                smoothPosition = gridObject.gridPosition;
                playerBehavior.playerPosition = playerBehavior.thePosition;
            }
            else
            {
                canMove = true;
                gridObject.gridPosition = smoothPosition;
                if (stickyBehavior.moveWithSmooth)
                {
                    stickyBehavior.stickyPosition.x++;
                }
            }
            toRight = false;
        }
    }
}
