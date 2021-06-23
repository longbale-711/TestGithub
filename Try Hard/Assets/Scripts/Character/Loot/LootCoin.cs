using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootCoin : MonoBehaviour
{
    public Text countcoin;
    public static int n = 0;
    // Update is called once per frame
    void Update()
    {
        countcoin.text = "" + n ;
    }
}
