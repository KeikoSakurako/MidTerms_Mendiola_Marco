using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int coinAquired;
    public Text coinCountText;

    public void AddCoin(int count)
    {
        coinAquired += count;
        coinCountText.text = "Coins: " + coinAquired.ToString();
    }



}
