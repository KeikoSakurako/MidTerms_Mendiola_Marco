using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Items> items;

    [SerializeField] Items armortest;

    PlayerDetlaControl player;
    
    private void Awake()
    {
        player = GetComponent<PlayerDetlaControl>();
    }

    private void Start()
    {
        Equip(armortest);
    }

    public void Equip(Items itemEquip)
    {
        if(items == null)
        {
            items = new List<Items>();

        }
        items.Add(itemEquip);
        itemEquip.Equip(player);

    }

    public void UnEquip(Items itemUnEquip)
    {

    }

}
