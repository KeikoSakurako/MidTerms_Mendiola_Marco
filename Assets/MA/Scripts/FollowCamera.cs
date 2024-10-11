using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damp;//how the camera catch up in the player

    public Transform target;

    private Vector3 vel = Vector3.zero;

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector3 targetpos = target.position + offset;
        targetpos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetpos, ref vel, damp);

    }



}
