using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClingyBehavior : MonoBehaviour
{
    private GridObject gridObject;
    public Vector2Int clingyPosition;
    public bool toRight = false;
    public bool toLeft = false;
    public bool toUp = false;
    public bool toDown = false;
    public Vector2Int up;
    public Vector2Int left;
    public Vector2Int down;
    public Vector2Int right;
    public PlayerBehavior playerBehavior;
    public bool withPlayer;
    public bool canMove;
    public Vector2Int thePosition;
    public StickyBehavior stickyBehavior;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        clingyPosition = gridObject.gridPosition;
        playerBehavior = FindObjectOfType<PlayerBehavior>();
        stickyBehavior = FindObjectOfType<StickyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        thePosition = gridObject.gridPosition;

        up = clingyPosition;
        up.y = clingyPosition.y - 1;
        left = clingyPosition;
        left.x = clingyPosition.x - 1;
        down = clingyPosition;
        down.y = clingyPosition.y + 1;
        right = clingyPosition;
        right.x = clingyPosition.x + 1;
        if (toUp)
        {
            if (stickyBehavior.moveWithClingy)
            {
                stickyBehavior.stickyPosition.y--;
            }
            gridObject.gridPosition.y--;
            if (!canMove)
            {
                gridObject.gridPosition.y++;
                canMove = true;
            }
            clingyPosition = gridObject.gridPosition;
            toUp = false;
        }
        if (toLeft)
        {
            if (stickyBehavior.moveWithClingy)
            {
                stickyBehavior.stickyPosition.x--;
            }
            gridObject.gridPosition.x--;
            if (!canMove)
            {
                gridObject.gridPosition.x++;
                canMove = true;
            }
            clingyPosition = gridObject.gridPosition;
            toLeft = false;
        }
        if (toDown)
        {
            if (stickyBehavior.moveWithClingy)
            {
                stickyBehavior.stickyPosition.y++;
            }
            gridObject.gridPosition.y++;
            if (!canMove)
            {
                gridObject.gridPosition.y--;
                canMove = true;
            }
            clingyPosition = gridObject.gridPosition;
            toDown = false;
        }
        if (toRight)
        {
            if (stickyBehavior.moveWithClingy)
            {
                stickyBehavior.stickyPosition.x++;
            }
            gridObject.gridPosition.x++;
            if (!canMove)
            {
                gridObject.gridPosition.x--;
                canMove = true;
            }
            clingyPosition = gridObject.gridPosition;
            toRight = false;
        }

        if (playerBehavior.thePosition == up || playerBehavior.thePosition == down || playerBehavior.thePosition == left || playerBehavior.thePosition == right)
        {
            withPlayer = true;
        }
        else
        {
            withPlayer = false;
        }
    }
}
