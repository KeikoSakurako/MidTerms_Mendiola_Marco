using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelMag : MonoBehaviour
{
    [SerializeField] GameObject LvlupPanel;
    public bool ispause;

    [SerializeField] List<UpgradeButton> upgradebuttons;

    private void Start()
    {
        HideButtons();
    }

    public void Onlvlpanel(List<UpgradeData> upgradedatas)
    {
        Clean();
        LvlupPanel.SetActive(true);
        

        for(int i = 0; i < upgradedatas.Count; i++)
        {
            upgradebuttons[i].gameObject.SetActive(true);
            upgradebuttons[i].Set(upgradedatas[i]);
        }

        Time.timeScale = 0;
        ispause = true;

    }

    public void Clean()
    {
        for(int i = 0; i < upgradebuttons.Count; i++)
        {
            upgradebuttons[i].Clean();
        }
    }


    public void Upgrade(int pressbuttonID)
    {
        GameManager.instance.player.GetComponent<LevelManager>().Upgrade(pressbuttonID);
        //Debug.Log("Player press" + pressbuttonID.ToString());
        
        Offlvlpanel();
    }


    public void Offlvlpanel()
    {
        HideButtons();

        LvlupPanel.SetActive(false);
        Time.timeScale = 1;
        ispause = true;
    }

    private void HideButtons()
    {
        for (int i = 0; i < upgradebuttons.Count; i++)
        {
            upgradebuttons[i].gameObject.SetActive(false);
        }
    }

}
