using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnGroup
{
    public EnemyData enemyData;
    public int count;

    public float repeattimer;
    public float timebetrepeat;
    public int repeatcount;


    public EnemySpawnGroup(EnemyData enemyData, int count)
    {
        this.enemyData = enemyData;
        this.count = count;

    }

    public void SetRepeatSpawn(float timebetspawn, int repeatCount)
    {
        this.timebetrepeat = timebetspawn;
        this.repeatcount = repeatCount;
        repeattimer = timebetrepeat;

    }

}


public class EnemyManager : MonoBehaviour
{
    [SerializeField] StageProgression stageprogress;
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawntimer;
    GameObject player;

    List<EnemySpawnGroup> enemiesSpawngrplist;
    List<EnemySpawnGroup> repeatSpawnlist;
    //[SerializeField] GameObject enemyAnim;

    private void Start()
    {
        player = GameManager.instance.player.gameObject;   
    }

    private void Update()
    {
        ProcessSpawn();
        ProcessRepeatSpawnGrp();
    }


    public void ProcessSpawn()
    {
        if (enemiesSpawngrplist == null) { return; }

        if(enemiesSpawngrplist.Count > 0)
        {
            SpawnEnemy(enemiesSpawngrplist[0].enemyData);
            enemiesSpawngrplist[0].count -= 1;

            if(enemiesSpawngrplist[0].count <= 0)
            {
                enemiesSpawngrplist.RemoveAt(0);
            }

        }

    }

    private void ProcessRepeatSpawnGrp()
    {
        if (repeatSpawnlist == null) { return; }

        for (int i = repeatSpawnlist.Count - 1; i >= 0; i--)
        {
            repeatSpawnlist[i].repeattimer -= Time.deltaTime;

            if (repeatSpawnlist[i].repeattimer < 0)
            {
                repeatSpawnlist[i].repeattimer = repeatSpawnlist[i].timebetrepeat;
                AddGroupSpawn(repeatSpawnlist[i].enemyData, repeatSpawnlist[i].count);
                repeatSpawnlist[i].repeatcount -= 1;

                if(repeatSpawnlist[i].repeatcount <= 0)
                {
                    repeatSpawnlist.RemoveAt(i);
                }


            }


        }


    }

    public void AddGroupSpawn(EnemyData enemytospawn, int count)
    {
        EnemySpawnGroup newGroupSpawn = new EnemySpawnGroup(enemytospawn, count);

        if (enemiesSpawngrplist == null) { enemiesSpawngrplist = new List<EnemySpawnGroup>(); }

        enemiesSpawngrplist.Add(newGroupSpawn);

    }


    public void SpawnEnemy(EnemyData enemytoSpawn)
    {
        Vector3 position = GenerateRandomPosition();
        position += player.transform.position;

        //Spawning the main Object
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;

        EnemyDeltaControl newEnemyCons = newEnemy.GetComponent<EnemyDeltaControl>();
        newEnemyCons.GetTarget();
        newEnemyCons.SetStats(enemytoSpawn.stats);
        newEnemyCons.UpdateStatsProgress(stageprogress.Progess);

        //newEnemy.GetComponent<EnemyDeltaControl>().GetTarget();
        newEnemy.transform.parent = transform;

        //Spawning a sprite
        GameObject spriteObject = Instantiate(enemytoSpawn.enemyAnim);
        spriteObject.transform.parent = newEnemy.transform;
        spriteObject.transform.localPosition = Vector3.zero;

    }

    public Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else 
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }


        position.z = 0;

        return position;

    }

    public void AddRepeatSpawn(StageEvent stageEvent)
    {
        EnemySpawnGroup repeatspawngroup = new EnemySpawnGroup(stageEvent.enemytospawn, stageEvent.count);
        repeatspawngroup.SetRepeatSpawn(stageEvent.repeatsec, stageEvent.repeatCount);

        if(repeatSpawnlist == null)
        {
            repeatSpawnlist = new List<EnemySpawnGroup>();
        }

        repeatSpawnlist.Add(repeatspawngroup);

    }

}
