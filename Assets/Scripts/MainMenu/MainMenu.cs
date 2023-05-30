using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
            PlayerPrefs.SetString("ability2", "E");
        }

        if (!PlayerPrefs.HasKey("ability3"))
        {
            PlayerPrefs.SetString("ability3", "R");
        }

        if (!PlayerPrefs.HasKey("ability4"))
        {
            PlayerPrefs.SetString("ability4", "F");
        }

        if (!PlayerPrefs.HasKey("dash"))
        {
            PlayerPrefs.SetString("dash", "Space");
        }

        if (!PlayerPrefs.HasKey("Utility1"))
        {
            PlayerPrefs.SetString("Utility1", "1");
        }

        if (!PlayerPrefs.HasKey("Utility2"))
        {
            PlayerPrefs.SetString("Utility2", "2");
        }

        if (!PlayerPrefs.HasKey("Utility3"))
        {
            PlayerPrefs.SetString("Utility3", "3");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextColourChangeToNew(TextMeshProUGUI text){
        if (text.color == ConvertColorTo01(254, 230, 151)){
            text.color = ConvertColorTo01(221, 202, 139);
        }
        else{
            text.color = ConvertColorTo01(82, 82, 82);
        }
    }

    public void TextColourChangeToOld(TextMeshProUGUI text){
        if (text.color == ConvertColorTo01(221, 202, 139)){
            text.color = ConvertColorTo01(254, 230, 151);
        }
        else{
            text.color = ConvertColorTo01(115, 115, 115);
        }
    }

    private Color ConvertColorTo01 (int r, int g, int b){
        return new Color(r/255.0f, g/255.0f, b/255.0f);
    }
}
