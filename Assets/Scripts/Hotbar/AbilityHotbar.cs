using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;

public class AbilityHotbar : MonoBehaviour
{
    public List<Button> abilityClickButtons;
    public List<GameObject> popupAnchors;
    public List<Image> keybinds;
    public List<Image> utilityKeybinds;
    public List<Image> abilityIcons;
    public List<Image> utilityIcons;

    public List<TextMeshProUGUI> cooldownNumbers;

    public List<TextMeshProUGUI> chargesNumbers;
    public List<Image> cooldownRadialOverlays;

    public GameObject abilityGrid_PF;
    private int lastNum;
    
    private Dictionary<int, Ability> availiableAbilities = new Dictionary<int, Ability>();
    

    void Start(){

        //these abilities should be where they also go on the hotbar aswell as populating the popup menu
        //availiableAbilities = GameManager.instance.GM_abilities;
        availiableAbilities = GameManager.instance.GM_hotbar_abilities;

        int count = 0;
        foreach (Ability ability in availiableAbilities.Values){
            Debug.Log(PlayerPrefs.GetString("ability" + (count + 1)).ToUpper());
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + ability.hotkey.ToString().ToUpper() + "-Key");
            keybinds[count].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + ability.hotkey.ToString().ToUpper() + "-Key");
            keybinds[count].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
            abilityIcons[count].sprite = ability.icon;
            count++;
        }

        count = 0;
        foreach (Potion potion in GameManager.instance.GM_hotbar_potions.Values){
            Sprite toLoad = Resources.Load<Sprite>("Settings/KeyboardKeys/" + potion.keyBind.ToString().ToUpper() + "-Key");
            utilityKeybinds[count].GetComponent<Image>().sprite = Resources.Load<Sprite>("Settings/KeyboardKeys/" + potion.keyBind.ToString().ToUpper() + "-Key");
            utilityKeybinds[count].GetComponent<RectTransform>().sizeDelta = new Vector2(toLoad.texture.width / 10.24f, 50);
            utilityIcons[count].sprite = potion.icon;
            count++;
        }
    }

    void Update(){
        int count = 0;
        foreach (Ability ability in GameManager.instance.GM_hotbar_abilities.Values){ 
            if (!ability.ready){
                cooldownNumbers[count].text = Math.Floor(ability.cooldownTimer + 1).ToString();
                cooldownRadialOverlays[count].fillAmount = Mathf.Clamp01(ability.cooldownTimer / ability.cooldownTime);
            }
            else{
                cooldownRadialOverlays[count].fillAmount = 0;
                cooldownNumbers[count].text = "";
            }

            abilityIcons[count].sprite = ability.icon;

            count++;
        }
    }
    

    

    public void ChangeAbilityPopup(int abilitySlotNumber){
        string abilityStuff = "Ability" + (abilitySlotNumber + 1);
        GameObject[] duplicates = GameObject.FindGameObjectsWithTag("AbilityGrid");
        if (duplicates.Length > 0){
            foreach(GameObject go in duplicates){
                Destroy(go);
            }
        }
        if (lastNum == abilitySlotNumber){
            foreach(GameObject go in duplicates){
                Destroy(go);
            }
            lastNum = 5;
            return;
        }
        
        GameObject abilityGrid = Instantiate(abilityGrid_PF);
        abilityGrid.transform.SetParent(GameObject.Find(abilityStuff).transform, false);
        abilityGrid.transform.position = GameObject.Find(abilityStuff).transform.position + new Vector3(0, 2.2f, 0);

        List<string> abilitiesInPopup = new List<string>();
        foreach (var ability in GameManager.instance.GM_usable_abilities)
        {
            bool inPopup = false;
            
            foreach (var s in abilitiesInPopup){
                //Debug.Log(s);
                if (s.Contains(ability.name)){
                    inPopup = true;
                }
            }

            if (ability.name == "NoAbility"){
                inPopup = true;
            }
            if (!inPopup){
                GameObject newObj = new GameObject();
                newObj.tag = "AbilityGrid";
                Image newR = newObj.AddComponent<Image>();
                Button button = newObj.AddComponent<Button>();
                newR.sprite = ability.icon;
                newObj.AddComponent<LayoutElement>();
                GameObject icon = Instantiate(newObj);
                icon.GetComponent<Button>().onClick.AddListener(delegate { AbilityChange((abilitySlotNumber + 1), ability.name); });
                icon.transform.SetParent(abilityGrid.transform, false);
                abilitiesInPopup.Add(ability.name);
            }
        }
        lastNum = abilitySlotNumber;
    }

    public void AbilityChange(int slotToChange, string abilityName){
        Debug.Log("Before: " + GameManager.instance.GM_abilities[slotToChange].name);
        GameManager.instance.GM_abilities[slotToChange].name = abilityName;
        GameManager.instance.GM_abilities[slotToChange].UpdateAbility();
        Debug.Log("After: " + GameManager.instance.GM_abilities[slotToChange].name);

        GameObject[] duplicates = GameObject.FindGameObjectsWithTag("AbilityGrid");
        if (duplicates.Length > 0){
            foreach(GameObject go in duplicates){
                Destroy(go);
            }
        }
    }

}

