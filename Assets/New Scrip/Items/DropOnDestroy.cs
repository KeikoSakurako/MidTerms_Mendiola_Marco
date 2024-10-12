using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{

    [SerializeField] GameObject dropItemPreFab;
    [SerializeField] [Range(0f, 1f)] float dropchance = 1f;

    bool isquit = false;

    private void OnApplicationQuit()
    {
        isquit = true;        
    }

    public void CheckDrop()
    {
        if (isquit) { return; }

        if (Random.value < dropchance)
        {
            Transform t = Instantiate(dropItemPreFab).transform;
            t.position = transform.position;
        }

    }


}
