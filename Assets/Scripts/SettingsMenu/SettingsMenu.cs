using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public TextMeshProUGUI[] keybindsGUI;
    private Dictionary<string, KeyCode> keyBinds = new Dictionary<string, KeyCode>();
    private GameObject currentKey;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("ability1"))
        {
            keybindsGUI[0].text = PlayerPrefs.GetString("ability1");
        }
        if (PlayerPrefs.HasKey("ability2"))
        {
            keybindsGUI[1].text = PlayerPrefs.GetString("ability2");
        }
        if (PlayerPrefs.HasKey("ability3"))
        {
            keybindsGUI[2].text = PlayerPrefs.GetString("ability3");
        }
        if (PlayerPrefs.HasKey("ability4"))
        {
            keybindsGUI[3].text = PlayerPrefs.GetString("ability4");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey || e.isMouse)
            {

                keyBinds[currentKey.name] = e.keyCode;
                if (currentKey.transform.name == "Ability1")
                {
                    PlayerPrefs.SetString("ability1", e.keyCode.ToString());
                    PlayerPrefs.Save();
                }
                else if (currentKey.transform.name == "Ability2")
                {
                    PlayerPrefs.SetString("ability2", e.keyCode.ToString());
                    PlayerPrefs.Save();
                }
                else if (currentKey.transform.name == "Ability3")
                {
                    PlayerPrefs.SetString("ability3", e.keyCode.ToString());
                    PlayerPrefs.Save();
                }

                else if (currentKey.transform.name == "Ability4")
                {
                    PlayerPrefs.SetString("ability4", e.keyCode.ToString());
                    PlayerPrefs.Save();
                }

                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }
}
