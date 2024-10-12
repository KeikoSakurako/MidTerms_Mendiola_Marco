using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour, IPickUp
{
    [SerializeField] int healamount;
    public void OnPickUp(PlayerDetlaControl player)
    {
        player.Heal(healamount);
    }

    
}
