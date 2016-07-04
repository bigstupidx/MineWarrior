using UnityEngine;
using System.Collections;

public class CharacterDAmagae : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			Player pl = col.GetComponent<Player>();
			pl.PlayerHealth -= 20;
			Debug.Log("Apply Enemy Damage");
		}
	}
}
