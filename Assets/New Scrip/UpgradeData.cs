using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UpgradeType
{
    WeaponUpgrade,
    ItemUpgrade,
    WeaponUnlock,
    ItemUnlock


}


[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradetype;
    public string upgradename;
    public Sprite upgradeIcon;

    public WeaponData weapondata;
    public WeaponStats weaponUpgradeStats;


}
