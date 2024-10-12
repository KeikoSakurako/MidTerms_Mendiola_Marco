using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    public int dmg;
    public float timetoatk;
    public int numofatk;
    //public int hitstoatk;

    public WeaponStats(int dmg, float timetoatk, int numofatk)
    {
        this.dmg = dmg;
        this.timetoatk = timetoatk;
        this.numofatk = numofatk;
        //this.hitstoatk = hitstoatk;

    }

    internal void Sum(WeaponStats weaponUpgradestats)
    {
        this.dmg += weaponUpgradestats.dmg;
        this.timetoatk += weaponUpgradestats.timetoatk;
        this.numofatk += weaponUpgradestats.numofatk;

    }

}

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string weapon_name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;

    public List<UpgradeData> upgrades;


}
