using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClingyBehavior : MonoBehaviour
{
    private GridObject gridObject;
    public Vector2Int clingyPosition;

    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        clingyPosition = gridObject.gridPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
