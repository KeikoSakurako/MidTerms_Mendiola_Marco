using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    [SerializeField] int level = 1;
    [SerializeField] int experience = 0;
    [SerializeField] EXPBar experiencebar;
    [SerializeField] UpgradePanelMag upgradelvl;


    [SerializeField] List<UpgradeData> upgrade;
    List<UpgradeData> selectedupgrade;

    [SerializeField] List<UpgradeData> acquiredupgrade;

    WeaponManager weaponmanager;

    private void Awake()
    {
        weaponmanager = GetComponent<WeaponManager>();
    }

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;

          

        }
    }

    internal void AddUpgradeListAvail(List<UpgradeData> upgradetoAdd)
    {
        this.upgrade.AddRange(upgradetoAdd);
    }


    private void Start()
    {
        experiencebar.UpdateExperience(experience, TO_LEVEL_UP);
        experiencebar.SetLvlText(level);
    }

    public void AddExperiencePts(int amount)
    {
        experience += amount;
        CheckUpLvl();
        experiencebar.UpdateExperience(experience, TO_LEVEL_UP);
    }


    public void Upgrade(int selectedID)
    {
        UpgradeData upgradedata = selectedupgrade[selectedID];

        if (acquiredupgrade == null) { acquiredupgrade = new List<UpgradeData>(); }

        switch(upgradedata.upgradetype)
        {
            case UpgradeType.ItemUnlock:
                break;
            case UpgradeType.ItemUpgrade:
                break;
            case UpgradeType.WeaponUnlock:
                weaponmanager.AddWeapon(upgradedata.weapondata);
                break;
            case UpgradeType.WeaponUpgrade:
                weaponmanager.UpgradeWeapon(upgradedata);
                break;

        }


        acquiredupgrade.Add(upgradedata);
        upgrade.Remove(upgradedata);

    }


    public void CheckUpLvl()
    {

        if(experience >= TO_LEVEL_UP)
        {
            LvlUp();
        }
    }

    private void LvlUp()
    {
        if (selectedupgrade == null) { selectedupgrade = new List<UpgradeData>(); }
        selectedupgrade.Clear();

        selectedupgrade.AddRange(GetUpgrades(3));
        upgradelvl.Onlvlpanel(selectedupgrade);


        experience -= TO_LEVEL_UP;
        level += 1;
        experiencebar.SetLvlText(level);
    }


    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradelist = new List<UpgradeData>();

        //If ran out of upgrade
        if(count > upgrade.Count)
        {
            count = upgrade.Count; 
        }


        //
        for (int i = 0; i < count; i++)
        {
            upgradelist.Add(upgrade[Random.Range(0, upgrade.Count)]);
        }

        return upgradelist;

    }



}
