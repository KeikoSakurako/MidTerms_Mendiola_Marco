using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageProgression : MonoBehaviour
{

    StageManager stagetimer;

    private void Awake()
    {
        stagetimer = GetComponent<StageManager>();   
    }

    [SerializeField] float progresstimerate = 30f;
    [SerializeField] float progresspersplit = 0.2f;

    public float Progess
    {
        get
        {
            return 1f + stagetimer.elapsedTime / progresstimerate * progresspersplit;
        }
    }


}
