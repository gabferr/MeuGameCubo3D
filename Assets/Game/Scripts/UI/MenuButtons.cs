using System;
using UnityEngine;


namespace Game
{ 
public class MenuButtons : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;
    public LoadSceneHelper loadScene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; 
        pausePanel.SetActive(true); 
    }
        public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; 
    }
    public void Respawn()
    {
        loadScene.LoadScene(1);
    }
}
}