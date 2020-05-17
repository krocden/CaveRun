using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconScript : MonoBehaviour {

    public GameObject[] iconList;

	void Start () {

        print("Start");
        ChoseIcon();       

	}

    private void ChoseIcon()
    {
        for (int i = 0; i < iconList.Length; i++)
        {
            iconList[i].gameObject.SetActive(false);
        }
            for (int i = 0; i < iconList.Length; i++)
            {
                if (iconList[i].name == CharacterSelection.playerClass)
                {
                    print(iconList[i].name);
                    iconList[i].gameObject.SetActive(true);
                }
            }
    }

}
