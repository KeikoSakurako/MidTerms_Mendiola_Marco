using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StageEventType
{
    SpawnEnemy,
    SpawnObject


}


[Serializable]
public class StageEvent
{
    public StageEventType eventType;

    public float time;
    public string message;

    public EnemyData enemytospawn;
    public GameObject objspawn;

    public int count;

    public bool isRepeatedEvent;
    public float repeatsec;
    public int repeatCount;



}


[CreateAssetMenu]
public class StageData : ScriptableObject
{
    public List<StageEvent> stageEvent;



}
