using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour
{

    [SerializeField] Slider expbar;
    [SerializeField] Text levelText;

    public void UpdateExperience(int current, int target)
    {
        expbar.maxValue = target;
        expbar.value = current;



    }

    public void SetLvlText(int lvl)
    {
        levelText.text = "Level: " + lvl.ToString();
    }


}
