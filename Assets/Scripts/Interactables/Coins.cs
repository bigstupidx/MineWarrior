using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour 
{
    [SerializeField]
    GameObject coinEffect;

	void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Destroy(Instantiate(coinEffect, transform.position, transform.rotation), 2f);            
        }
    }
}