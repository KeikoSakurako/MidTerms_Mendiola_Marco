using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventsMag : MonoBehaviour
{
    [SerializeField] StageData stageData;

    StageManager stageTime;
    int eventindex;

    //public EnemyDeltaCameraSpawn enemymag;
    public EnemyManager enemymag;

    private void Awake()
    {
        stageTime = GetComponent<StageManager>();
    }

    private void Update()
    {
        if (eventindex >= stageData.stageEvent.Count) { return; }
        
        if(stageTime.elapsedTime > stageData.stageEvent[eventindex].time)
        {

            switch(stageData.stageEvent[eventindex].eventType)
            {
                case StageEventType.SpawnEnemy:
                    SpawnEnemy();
                    break;

                case StageEventType.SpawnObject:
                    break;


            }

            Debug.Log(stageData.stageEvent[eventindex].message);

            eventindex += 1;

        }



    }

    private void SpawnEnemy()
    {
        StageEvent currentevent = stageData.stageEvent[eventindex];
        enemymag.AddGroupSpawn(currentevent.enemytospawn,currentevent.count);

        //if(currentevent.isRepeatedEvent == true)
        //{
        //    enemymag.AddRepeatSpawn(currentevent.enemytospawn,currentevent.count);
        //}
        

       
    }

}
