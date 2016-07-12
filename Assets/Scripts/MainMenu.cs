using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void Play()
    {
        Application.LoadLevel("Level1");
    }
    public void LevelSelect()
    {
        Application.LoadLevel("LevelSelect");
    }
    public void Options()
    {
        Application.LoadLevel("Options");
    }
}
