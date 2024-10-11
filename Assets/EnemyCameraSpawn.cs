using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraSpawn : MonoBehaviour
{
    [SerializeField] GameObject spawnee;
    [SerializeField] float sizeX = 1f;
    [SerializeField] float sizeY = 1f;
    [SerializeField] float spawnCooldown = 1f;

    private float spawnTime;
    private void Start()
    {
        spawnTime = spawnCooldown;
    }

    private void Update()
    {
        if(spawnTime > 0)
        {
            spawnTime = Time.deltaTime;

        }

        if(spawnTime <= 0)
        {
            Spawn();
            spawnTime = spawnCooldown;

        }

    }

    public void Spawn()
    {
        //float xPos = Random.Range(-sizeX, sizeX) + transform.position.x;
        //float yPos = Random.Range(-sizeY, sizeY) + transform.position.y;
        //Vector3 spawnPosition = new Vector3(xPos, yPos, 0);
        //Instantiate(spawnee, spawnPosition, Quaternion.identity);

        float xPos = (Random.value - 0.5f) * 2 * sizeX + gameObject.transform.position.x;
        float yPos = (Random.value - 0.5f) * 2 * sizeY + gameObject.transform.position.y;

        var spawn = Instantiate(spawnee);
        spawn.transform.position = new Vector3(xPos,yPos,0);

    }


}
