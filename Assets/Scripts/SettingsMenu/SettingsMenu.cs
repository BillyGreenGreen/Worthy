using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

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
        if (PlayerPrefs.HasKey("dash"))
        {
            keybindsGUI[4].text = PlayerPrefs.GetString("dash");
        }
        if (PlayerPrefs.HasKey("MoveUp"))
        {
            keybindsGUI[5].text = PlayerPrefs.GetString("MoveUp");
        }
        if (PlayerPrefs.HasKey("MoveDown"))
        {
            keybindsGUI[6].text = PlayerPrefs.GetString("MoveDown");
        }
        if (PlayerPrefs.HasKey("MoveRight"))
        {
            keybindsGUI[7].text = PlayerPrefs.GetString("MoveRight");
        }
        if (PlayerPrefs.HasKey("MoveLeft"))
        {
            keybindsGUI[8].text = PlayerPrefs.GetString("MoveLeft");
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
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = e.keyCode.ToString();
                }
                else if (currentKey.transform.name == "Ability2")
                {
                    PlayerPrefs.SetString("ability2", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = e.keyCode.ToString();
                }
                else if (currentKey.transform.name == "Ability3")
                {
                    PlayerPrefs.SetString("ability3", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = e.keyCode.ToString();
                }

                else if (currentKey.transform.name == "Ability4")
                {
                    PlayerPrefs.SetString("ability4", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = e.keyCode.ToString();
                }

                else if (currentKey.transform.name == "Dash")
                {
                    PlayerPrefs.SetString("dash", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = e.keyCode.ToString();
                }

                else if (currentKey.transform.name == "MoveUp")
                {
                    PlayerPrefs.SetString("MoveUp", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = e.keyCode.ToString();
                }

                else if (currentKey.transform.name == "MoveLeft")
                {
                    PlayerPrefs.SetString("MoveLeft", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = e.keyCode.ToString();
                }

                else if (currentKey.transform.name == "MoveRight")
                {
                    PlayerPrefs.SetString("MoveRight", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = e.keyCode.ToString();
                }

                else if (currentKey.transform.name == "MoveDown")
                {
                    PlayerPrefs.SetString("MoveDown", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = e.keyCode.ToString();
                }

                currentKey = null;
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        clicked.GetComponentInChildren<TextMeshProUGUI>().text = "Press a key...";
        currentKey = clicked;
    }

    public void TextColourBlack(TextMeshProUGUI text){
        text.color = Color.black;
    }

    public void TextColourWhite(TextMeshProUGUI text){
        text.color = Color.white;
    }
}
