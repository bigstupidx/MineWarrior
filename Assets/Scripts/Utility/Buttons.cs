using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Buttons : MonoBehaviour 
{
    public GameObject changeEffect;

	public void LoadLevel(string levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator changeScene(int levelIndex)
    {
        Instantiate(changeEffect);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(levelIndex);
    }
}