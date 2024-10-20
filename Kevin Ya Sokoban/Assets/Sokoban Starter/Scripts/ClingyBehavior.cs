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

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        clingyPosition = gridObject.gridPosition;
        playerBehavior = FindObjectOfType<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
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
            gridObject.gridPosition.y--;
            clingyPosition = gridObject.gridPosition;
            toUp = false;
        }
        if (toLeft)
        {
            gridObject.gridPosition.x--;
            clingyPosition = gridObject.gridPosition;
            toLeft = false;
        }
        if (toDown)
        {
            gridObject.gridPosition.y++;
            clingyPosition = gridObject.gridPosition;
            toDown = false;
        }
        if (toRight)
        {
            gridObject.gridPosition.x++;
            clingyPosition = gridObject.gridPosition;
            toRight = false;
        }
    }
}
