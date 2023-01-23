using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if game is ran the first time set defaults
        if (!PlayerPrefs.HasKey("MoveLeft"))
        {
            PlayerPrefs.SetString("MoveLeft", "A");
        }

        if (!PlayerPrefs.HasKey("MoveRight"))
        {
            PlayerPrefs.SetString("MoveRight", "D");
        }

        if (!PlayerPrefs.HasKey("MoveUp"))
        {
            PlayerPrefs.SetString("MoveUp", "W");
        }

        if (!PlayerPrefs.HasKey("MoveDown"))
        {
            PlayerPrefs.SetString("MoveDown", "S");
        }

        if (!PlayerPrefs.HasKey("ability1"))
        {
            PlayerPrefs.SetString("ability1", "Q");
        }

        if (!PlayerPrefs.HasKey("ability2"))
        {
            PlayerPrefs.SetString("ability2", "Space");
        }

        if (!PlayerPrefs.HasKey("ability3"))
        {
            PlayerPrefs.SetString("ability3", "F");
        }

        if (!PlayerPrefs.HasKey("ability4"))
        {
            PlayerPrefs.SetString("ability4", "R");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
