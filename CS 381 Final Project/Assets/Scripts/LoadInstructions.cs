using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInstructions : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        
    }

    public void loadInstructions()
    {
        SceneManager.LoadScene("InstructionMenu");
    }

    public void loadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void loadFirstLevel()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
