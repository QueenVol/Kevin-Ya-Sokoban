using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    private GridObject gridObject;
    public Vector2Int wallPosition;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        wallPosition = gridObject.gridPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
