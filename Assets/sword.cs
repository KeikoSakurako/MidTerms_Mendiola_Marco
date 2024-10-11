using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Getting to dmg the player
        EnemyController enm = collision.GetComponent<EnemyController>();
        if (enm != null)
        {
            enm.DamageEnemy(3);
           
        }




    }




}
