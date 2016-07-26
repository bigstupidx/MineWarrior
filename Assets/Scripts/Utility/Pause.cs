using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour 
{
    [SerializeField]
    GameObject pausePanel;
    Camera2DFollow cam;

    void Awake()
    {
        cam = Camera.main.GetComponent<Camera2DFollow>();
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        cam.shakeTimer = -1f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}