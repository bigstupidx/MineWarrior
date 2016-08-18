using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour 
{
    [SerializeField]
    GameObject coinEffect;

    GameObject coinGUI;

    int coins;

    void Awake()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinGUI = GameObject.Find("coinText");
    }
	void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coins = PlayerPrefs.GetInt("Coins");
            coins += 10;
            PlayerPrefs.SetInt("Coins", coins);
            coinGUI.GetComponent<ShowCoins>().Refresh();
            
            Destroy(this.gameObject);
            Destroy(Instantiate(coinEffect, transform.position, transform.rotation), 2f);            
        }
    }
}