using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour 
{
    public Scores sc;
    [SerializeField]
    GameObject coinEffect;

	void OnTriggerEnter2D(Collider2D coll)
    {
        sc.GetComponent<Scores>();

        if(coll.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Destroy(Instantiate(coinEffect, transform.position, transform.rotation), 1f);
            sc.scores += 10;
        }
    }
}