using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIScripts : MonoBehaviour {
    
    // Variables for Pause and Help menu
    public GameObject PauseMenuCanvas;
    public GameObject HelpMenuCanvas;
    public static bool isGamePaused;
    private bool isHelpMenu;

    // Variables to change the Text for the Score and the Mob Killed Count
    public Text ScoreText;
    public Text MobKilled;

    private void Start()
    {
        Resume();
        isGamePaused = false;
        isHelpMenu = false;        
    }

    // Pause the game on escape button
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            print("escape");
            if (isGamePaused == true)
            {
                Resume();
            }
            else if(isGamePaused == false)
            {
                print("pause");
                Pause();
            }
        }
        WriteScore();
    }

    // Method to quit application
    public void exitGame()
    {
        Application.Quit(); 
    }

    // Restart the game and set stats to default
    public void startGame()
    {
        SceneManager.LoadScene(1);
        PlayerStats.MobKilled = 0;
        PlayerStats.score = 0;
        Spell.minDamage = 3;
        Spell.maxDamage = 15;
    }

    // Method to pause the game with a overlay canvas
    public void Pause()
    {
        Time.timeScale = 0;
        PauseMenuCanvas.SetActive(true);
        isGamePaused = true;
    }

    // Resume the game
    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenuCanvas.SetActive(false);
        isGamePaused = false;        
    }

    // Method to go to next level (Cheat button when stuck)
    public void nextLVL()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            if (i == SceneManager.GetActiveScene().buildIndex)
            {
                SceneManager.LoadScene(i + 1);
                break;
            }
        }

        Resume();

    }

    // Gameover method
    public static void GameOver()
    {
        
        Destroy(GameObject.FindGameObjectWithTag("Music"));
        SceneManager.LoadScene("GameOver");
        
    }

    // Write score
    public void WriteScore()
    {
        ScoreText.text = "Score: "+ PlayerStats.score;
        MobKilled.text = "Mob killed: "+ PlayerStats.MobKilled;
    }

    // Main menu method
    public void MainMenu()
    {        
        
        print("Main Menu");
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.FindGameObjectWithTag("Music"));


    }

    // Canvas with help menu
    public void HelpMenu()
    {
        if (isHelpMenu == false)
        {
            HelpMenuCanvas.SetActive(true);
            isHelpMenu = true;
        }
        else if (isHelpMenu == true)
        {
            HelpMenuCanvas.SetActive(false);
            isHelpMenu = false;
        }
    }
}
