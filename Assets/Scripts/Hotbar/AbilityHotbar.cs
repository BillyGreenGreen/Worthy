using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;

public class AbilityHotbar : MonoBehaviour
{
    public List<Button> abilityClickButtons;
    public List<GameObject> popupAnchors;
    public List<TextMeshProUGUI> keybinds;
    public List<Image> abilityIcons;

    public List<TextMeshProUGUI> cooldownNumbers;

    public List<TextMeshProUGUI> chargesNumbers;
    public List<Image> cooldownRadialOverlays;

    public GameObject abilityGrid_PF;
    private int lastNum;
    
    private Dictionary<int, Ability> availiableAbilities = new Dictionary<int, Ability>();

    void Start(){

        //these abilities should be where they also go on the hotbar aswell as populating the popup menu
        availiableAbilities = GameManager.instance.GM_abilities;

        int count = 0;
        foreach (Ability ability in availiableAbilities.Values){
            if (ability.hotkey.ToString() == "Space"){
                keybinds[count].text = "Spc";
            }
            else{
                keybinds[count].text = ability.hotkey.ToString();
            }
            abilityIcons[count].sprite = ability.icon;
            count++;
        }
    }

    void Update(){
        int count = 0;
        foreach (Ability ability in availiableAbilities.Values){ 
            if (!ability.ready){
                cooldownNumbers[count].text = Math.Floor(ability.cooldownTimer).ToString();
                cooldownRadialOverlays[count].fillAmount = Mathf.Clamp01(ability.cooldownTimer / ability.cooldownTime);
            }
            else{
                cooldownNumbers[count].text = "";
            }
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
            lastNum = 5;
            return;
        }
        
        GameObject abilityGrid = Instantiate(abilityGrid_PF);
        abilityGrid.transform.SetParent(GameObject.Find(abilityStuff).transform, false);
        abilityGrid.transform.position = GameObject.Find(abilityStuff).transform.position + new Vector3(0, 2.2f, 0);

        List<string> abilitiesInPopup = new List<string>();
        foreach (var ability in GameManager.instance.GM_abilities.Values)
        {
            bool inPopup = false;
            foreach (var s in abilitiesInPopup){
                if (s.Contains(ability.name) || s.Contains("Ability")){
                    inPopup = true;
                }
            }
            if (!inPopup){
                GameObject newObj = new GameObject();
                newObj.tag = "AbilityGrid";
                Image newR = newObj.AddComponent<Image>();
                newR.sprite = ability.icon;
                newObj.AddComponent<LayoutElement>();
                GameObject icon = Instantiate(newObj);
                icon.transform.SetParent(abilityGrid.transform, false);
                abilitiesInPopup.Add(ability.name);
            }
        }
        foreach (var s in abilitiesInPopup){
            Debug.Log(s);
        }
        lastNum = abilitySlotNumber;
    }

}

