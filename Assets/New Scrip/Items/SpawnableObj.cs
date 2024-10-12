using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObj : MonoBehaviour
{
    [SerializeField] GameObject spawnobj;

    [SerializeField] [Range(0f, 1f)] float probablitiy;

    public void Spawn()
    {
        if(Random.value < probablitiy)
        {
            GameObject go = Instantiate(spawnobj, transform.position, Quaternion.identity);

        }

    }


}
