using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDetlaControl c = collision.GetComponent<PlayerDetlaControl>();
        if (c != null)
        {

            GetComponent<IPickUp>().OnPickUp(c);
            Destroy(gameObject);

        }

    }
}
