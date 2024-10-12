using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    [SerializeField] Transform weaponObjectContain;
    [SerializeField] WeaponData startweapon;

    List<WeaponBase> weapons;

    private void Awake()
    {
        weapons = new List<WeaponBase>();
    }

    private void Start()
    {
        AddWeapon(startweapon);
    }

    public void AddWeapon(WeaponData weapondata)
    {
        GameObject weaponGameobject = Instantiate(weapondata.weaponBasePrefab, weaponObjectContain);

        WeaponBase weaponbase = weaponGameobject.GetComponent<WeaponBase>();
        weaponbase.SetData(weapondata);
        weapons.Add(weaponbase);


        //weaponGameobject.GetComponent<WeaponBase>().SetData(weapondata);

        LevelManager level = GetComponent<LevelManager>();
        if(level != null)
        {
            level.AddUpgradeListAvail(weapondata.upgrades);
        }

    }

    internal void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponBase weapontoupgrade = weapons.Find(wd => wd.weapondata == upgradeData.weapondata);

        weapontoupgrade.Upgrade(upgradeData);
    }


}
