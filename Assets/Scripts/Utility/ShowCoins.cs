using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowCoins : MonoBehaviour 
{
    Text text;
    int coins;

    void Awake()
    {
        text = GetComponent<Text>();
        coins = PlayerPrefs.GetInt("Coins");
        Refresh();
    }

    public void Refresh()
    {
        coins = PlayerPrefs.GetInt("Coins");
        text.text = coins.ToString();
    }
}