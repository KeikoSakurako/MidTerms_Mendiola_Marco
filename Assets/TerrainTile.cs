using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tileposition;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<WorldScroll>().Add(gameObject, tileposition);
        //transform.position = new Vector3(-100, -100, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
