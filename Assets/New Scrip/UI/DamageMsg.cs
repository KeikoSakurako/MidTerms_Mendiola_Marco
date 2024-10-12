using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMsg : MonoBehaviour
{
    [SerializeField] float timeleft = 1f;
    float ttl = 1f;

    private void OnEnable()
    {
        ttl = timeleft;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;

        if(ttl <0)
        {
            gameObject.SetActive(false);
        }

    }



}
