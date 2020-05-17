using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    // Variables for character selection
    private GameObject[] characterList;
    private int index;
    public Text classText;

    //variable used to spawn the player in spawner.cs
    public static string playerClass;
    

    private void Start()
    {
              
        // PlayerPrefs is used to save variable into memory
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];

        //Fill array
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        //toggle off characters
        foreach (GameObject go in characterList)
            go.SetActive(false);

        //toggle on first character
        if (characterList[index])
            characterList[index].SetActive(true);

        checkClass();
    }

    //method to display the name of the class
    public void checkClass()
    {
        for (int i = 0; i < characterList.Length; i++)
        {
            if (index == i)
                classText.text = characterList[index].name;
        }

    }

    public void ToggleLeft()
    {
        //toggle off current model
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }

        //toggle on new model
        characterList[index].SetActive(true);

        //update class text
        checkClass();
    }

    public void ToggleRight()
    {
        //toggle off current model
        characterList[index].SetActive(false);

        index++;
        if (index > characterList.Length-1)
        {
            index = 0;
        }

        //toggle on new model
        characterList[index].SetActive(true);

        //update class text
        checkClass();
    }
    // Method to select character
    public void SelectButton()
    {
        for (int i = 0; i < transform.childCount;i++)
        {
            if (i == index)
            {
                //sets the current class in the playerprefs
                PlayerPrefs.SetString("PlayerClass", characterList[i].name);
                playerClass = characterList[i].name;
                Debug.Log("Player Class is: "+ PlayerPrefs.GetString("PlayerClass"));
            }
        }

        PlayerPrefs.SetInt("CharacterSelected", index);
        PlayerPrefs.SetString("PlayerClass", playerClass);
        SceneManager.LoadScene("Level01");
    }
}
