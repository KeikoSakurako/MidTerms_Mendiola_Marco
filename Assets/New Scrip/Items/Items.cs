using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Items : ScriptableObject
{

    public string nameitem;
    public int armor;


    public void Equip(PlayerDetlaControl player)
    {
        player.armor += armor;
    }

    public void UnEquip(PlayerDetlaControl player)
    {
        player.armor -= armor;
    }


}
