using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBehavior : MonoBehaviour
{
    private GridObject gridObject;
    public Vector2Int stickyPosition;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        stickyPosition = gridObject.gridPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
