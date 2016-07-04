using UnityEngine;
using System.Collections;

public class DeathScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Restart(){
		Application.LoadLevel("Level1");
	}
	public void MainMenu(){
		Application.LoadLevel("MainMenu");
	}
	public void Quit(){
		Application.Quit();
	}
}
