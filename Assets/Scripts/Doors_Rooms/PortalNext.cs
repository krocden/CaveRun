using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalNext : MonoBehaviour {

    // Temporary reference to the current scene.
    Scene currentScene;     
    string currentSceneName;

    private void Start()
    {
        // Retrieve the name of this scene.
        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Only trigger if player contacts portal
        if(collision.tag == "Player")
        {
             // Change level depending on current level
            if (currentSceneName == "Level01")
            {
                SceneManager.LoadScene("SecondLevel");
            }
            else if (currentSceneName == "SecondLevel")
            {
                SceneManager.LoadScene("ThirdLevel");
            }
            else if (currentSceneName == "ThirdLevel")
            {
                SceneManager.LoadScene("EndScene");
            }
        }
       
    }
}
