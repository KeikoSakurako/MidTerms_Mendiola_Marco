using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weapondata;

    public WeaponStats weaponstats;

    float timer;

    public void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            Atk();
            timer = weaponstats.timetoatk;
        }

    }

    public virtual void SetData(WeaponData wd)
    {
        weapondata = wd;
        //timetoatk = weapondata.stats.timetoatk;

        weaponstats = new WeaponStats(wd.stats.dmg, wd.stats.timetoatk,wd.stats.numofatk);

    }

    public abstract void Atk();

    public virtual void PostDamage(int damage, Vector3 targetPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), targetPosition);
    }
    
    internal void Upgrade(UpgradeData upgradeData)
    {
        weaponstats.Sum(upgradeData.weaponUpgradeStats);
    }


}
