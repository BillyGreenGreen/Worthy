using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public TextMeshProUGUI[] keybindsGUI;
    public GameObject[] keybindsImageGUI;
    private Dictionary<string, KeyCode> keyBinds = new Dictionary<string, KeyCode>();
    private GameObject currentKey;

    private AudioSource music;
    private Slider slider;
    private TextMeshProUGUI percentageMusicVolumeText;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        music = GameObject.Find("Music").GetComponent<AudioSource>();
        percentageMusicVolumeText = GameObject.Find("Percentage").GetComponent<TextMeshProUGUI>();
        slider.value = music.volume;
        percentageMusicVolumeText.text = Mathf.Floor(slider.value * 100).ToString()  + "%";
        if (PlayerPrefs.HasKey("ability1"))
        {
            //keybindsGUI[0].text = PlayerPrefs.GetString("ability1");
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("ability1").ToUpper() + "-Key");
            keybindsImageGUI[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("ability1").ToUpper() + "-Key");
            keybindsImageGUI[0].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
        }
        if (PlayerPrefs.HasKey("ability2"))
        {
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("ability2").ToUpper() + "-Key");
            keybindsImageGUI[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("ability2").ToUpper() + "-Key");
            keybindsImageGUI[1].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
        }
        if (PlayerPrefs.HasKey("ability3"))
        {
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("ability3").ToUpper() + "-Key");
            keybindsImageGUI[2].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("ability3").ToUpper() + "-Key");
            keybindsImageGUI[2].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
        }
        if (PlayerPrefs.HasKey("ability4"))
        {
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("ability4").ToUpper() + "-Key");
            keybindsImageGUI[3].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("ability4").ToUpper() + "-Key");
            keybindsImageGUI[3].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
        }
        if (PlayerPrefs.HasKey("dash"))
        {
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("dash").ToUpper() + "-Key");
            keybindsImageGUI[4].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("dash").ToUpper() + "-Key");
            keybindsImageGUI[4].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
        }
        if (PlayerPrefs.HasKey("MoveUp"))
        {
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("MoveUp").ToUpper() + "-Key");
            keybindsImageGUI[5].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("MoveUp").ToUpper() + "-Key");
            keybindsImageGUI[5].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
        }
        if (PlayerPrefs.HasKey("MoveDown"))
        {
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("MoveDown").ToUpper() + "-Key");
            keybindsImageGUI[6].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("MoveDown").ToUpper() + "-Key");
            keybindsImageGUI[6].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
        }
        if (PlayerPrefs.HasKey("MoveRight"))
        {
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("MoveRight").ToUpper() + "-Key");
            keybindsImageGUI[7].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("MoveRight").ToUpper() + "-Key");
            keybindsImageGUI[7].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
        }
        if (PlayerPrefs.HasKey("MoveLeft"))
        {
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("MoveLeft").ToUpper() + "-Key");
            keybindsImageGUI[8].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("MoveLeft").ToUpper() + "-Key");
            keybindsImageGUI[8].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
        }
        if (PlayerPrefs.HasKey("Utility1"))
        {
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("Utility1").ToUpper() + "-Key");
            keybindsImageGUI[9].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("Utility1").ToUpper() + "-Key");
            keybindsImageGUI[9].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
        }
        if (PlayerPrefs.HasKey("Utility2"))
        {
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("Utility2").ToUpper() + "-Key");
            keybindsImageGUI[10].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("Utility2").ToUpper() + "-Key");
            keybindsImageGUI[10].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
        }
        if (PlayerPrefs.HasKey("Utility3"))
        {
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("Utility3").ToUpper() + "-Key");
            keybindsImageGUI[11].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + PlayerPrefs.GetString("Utility3").ToUpper() + "-Key");
            keybindsImageGUI[11].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
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
                    //currentKey.GetComponentInChildren<TextMeshProUGUI>().text = e.keyCode.ToString();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    currentKey.transform.Find("Key").GetComponent<Image>().enabled = true;
                    Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
                    //currentKey.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                }
                else if (currentKey.transform.name == "Ability2")
                {
                    PlayerPrefs.SetString("ability2", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    currentKey.transform.Find("Key").GetComponent<Image>().enabled = true;
                    Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
                }
                else if (currentKey.transform.name == "Ability3")
                {
                    PlayerPrefs.SetString("ability3", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    currentKey.transform.Find("Key").GetComponent<Image>().enabled = true;
                    Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
                }

                else if (currentKey.transform.name == "Ability4")
                {
                    PlayerPrefs.SetString("ability4", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    currentKey.transform.Find("Key").GetComponent<Image>().enabled = true;
                    Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
                }

                else if (currentKey.transform.name == "Dash")
                {
                    PlayerPrefs.SetString("dash", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    currentKey.transform.Find("Key").GetComponent<Image>().enabled = true;
                    Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
                }

                else if (currentKey.transform.name == "MoveUp")
                {
                    PlayerPrefs.SetString("MoveUp", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    currentKey.transform.Find("Key").GetComponent<Image>().enabled = true;
                    Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
                }

                else if (currentKey.transform.name == "MoveLeft")
                {
                    PlayerPrefs.SetString("MoveLeft", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    currentKey.transform.Find("Key").GetComponent<Image>().enabled = true;
                    Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
                }

                else if (currentKey.transform.name == "MoveRight")
                {
                    PlayerPrefs.SetString("MoveRight", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    currentKey.transform.Find("Key").GetComponent<Image>().enabled = true;
                    Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
                }

                else if (currentKey.transform.name == "MoveDown")
                {
                    PlayerPrefs.SetString("MoveDown", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    currentKey.transform.Find("Key").GetComponent<Image>().enabled = true;
                    Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
                }

                else if (currentKey.transform.name == "ExtraButton1")
                {
                    PlayerPrefs.SetString("Utility1", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    currentKey.transform.Find("Key").GetComponent<Image>().enabled = true;
                    Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
                }

                else if (currentKey.transform.name == "ExtraButton2")
                {
                    PlayerPrefs.SetString("Utility2", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    currentKey.transform.Find("Key").GetComponent<Image>().enabled = true;
                    Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
                }

                else if (currentKey.transform.name == "ExtraButton3")
                {
                    PlayerPrefs.SetString("Utility3", e.keyCode.ToString());
                    PlayerPrefs.Save();
                    currentKey.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    currentKey.transform.Find("Key").GetComponent<Image>().enabled = true;
                    Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + e.keyCode.ToString().ToUpper() + "-Key");
                    currentKey.transform.Find("Key").GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
                }

                currentKey = null;
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        clicked.GetComponentInChildren<TextMeshProUGUI>().text = "Press a key...";
        clicked.transform.Find("Key").GetComponent<Image>().enabled = false;
        currentKey = clicked;
    }

    public void TextColourBlack(TextMeshProUGUI text){
        text.color = Color.black;
    }

    public void TextColourWhite(TextMeshProUGUI text){
        text.color = Color.white;
    }

    public void ChangeMusicVolume(){
        
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
        percentageMusicVolumeText.text = Mathf.Floor(slider.value * 100).ToString() + "%";
    }

}
