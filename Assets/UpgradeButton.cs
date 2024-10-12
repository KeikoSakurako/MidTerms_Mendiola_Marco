using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;
    
    public void Set(UpgradeData upgradedata)
    {
        icon.sprite = upgradedata.upgradeIcon;
    }

    internal void Clean()
    {
        icon.sprite = null;
    }


}
