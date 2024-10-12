using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsPickUp : MonoBehaviour, IPickUp
{

    [SerializeField] int amount;

    public void OnPickUp(PlayerDetlaControl player)
    {
        player.lvl.AddExperiencePts(amount);
    }




}
