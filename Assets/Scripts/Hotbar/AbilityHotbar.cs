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

    public List<Image> abilityIcons;

    public List<TextMeshProUGUI> cooldownNumbers;

    public List<TextMeshProUGUI> chargesNumbers;
    public List<Image> cooldownRadialOverlays;
    
    private Dictionary<int, Ability> availiableAbilities = new Dictionary<int, Ability>();

    void Start(){

        //these abilities should be where they also go on the hotbar aswell as populating the popup menu
        availiableAbilities = GameManager.instance.GM_abilities;


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

    public void ChangeAbilityPopup(string abilitySlotNumber){

    }

}

