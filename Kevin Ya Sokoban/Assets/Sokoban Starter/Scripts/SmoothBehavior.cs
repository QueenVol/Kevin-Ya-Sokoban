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
    public bool canMove = false;
    public WallBehavior wallBehavior;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        smoothPosition = gridObject.gridPosition;
        wallBehavior = FindObjectOfType<WallBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toUp)
        {
            smoothPosition.y--;
            if (smoothPosition == wallBehavior.wallPosition)
            {
                smoothPosition = gridObject.gridPosition;
                canMove = false;
                toUp = false;
            }
            else
            {
                gridObject.gridPosition.y--;
                smoothPosition = gridObject.gridPosition;
                canMove = true;
                toUp = false;
            }
        }
        if (toLeft)
        {
            smoothPosition.x--;
            if (smoothPosition == wallBehavior.wallPosition)
            {
                smoothPosition = gridObject.gridPosition;
                canMove = false;
                toLeft = false;
            }
            else
            {
                gridObject.gridPosition.x--;
                smoothPosition = gridObject.gridPosition;
                canMove = true;
                toLeft = false;
            }
        }
        if (toDown)
        {
            smoothPosition.y++;
            if (smoothPosition == wallBehavior.wallPosition)
            {
                smoothPosition = gridObject.gridPosition;
                canMove = false;
                toDown = false;
            }
            else
            {
                gridObject.gridPosition.y++;
                smoothPosition = gridObject.gridPosition;
                canMove = true;
                toDown = false;
            }
        }
        if (toRight)
        {
            smoothPosition.x++;
            if (smoothPosition == wallBehavior.wallPosition)
            {
                smoothPosition = gridObject.gridPosition;
                canMove = false;
                toRight = false;
            }
            else
            {
                gridObject.gridPosition.x++;
                smoothPosition = gridObject.gridPosition;
                canMove = true;
                toRight = false;
            }
        }
    }
}
