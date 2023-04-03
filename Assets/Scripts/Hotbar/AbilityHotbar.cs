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
            count++;
        }

        count = 0;
        foreach (Ability ability in availiableAbilities.Values){
            Debug.Log(ability.icon);
            abilityIcons[count].sprite = ability.icon.sprite;
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
        GameObject[] duplicates = GameObject.FindGameObjectsWithTag("AbilityGrid");
        if (duplicates.Length > 0){
            foreach(GameObject go in duplicates){
                Destroy(go);
            }
        }
        string abilityStuff = "Ability" + (abilitySlotNumber + 1);
        Vector2 pos = new Vector2(0, 0);
        GameObject abilityGrid = Instantiate(abilityGrid_PF);
        abilityGrid.transform.SetParent(GameObject.Find(abilityStuff).transform, false);
        abilityGrid.transform.position = transform.position + new Vector3(0, GetComponent<RectTransform>().rect.height, 0);

        foreach (var ability in GameManager.instance.GM_abilities.Values)
        {
            //GameObject icon = Instantiate(ability.icon.sprite);
            //icon.transform.SetParent(popup.transform.GetChild(0), false);
        }
        Vector2 v2 = new Vector2(0, 1053);
        abilityGrid.transform.position = v2;
        Debug.Log("CHEESE");
    }

}

