using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, IDamage
{

    public void TakeDamage(int dmg)
    {
        Destroy(gameObject);
        GetComponent<DropOnDestroy>().CheckDrop();

    }

}
