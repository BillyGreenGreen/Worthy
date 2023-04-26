using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class HotbarDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData){
        
        GameObject dropped = eventData.pointerDrag;
        Debug.Log(dropped.name);
        if (gameObject.GetComponent<Image>().sprite.name == "circle"){
            foreach(KeyValuePair<int, Ability> ability in GameManager.instance.GM_hotbar_abilities){
                if (gameObject.name.EndsWith(ability.Key.ToString())){
                    ability.Value.name = dropped.name;
                    ability.Value.UpdateAbility();
                    gameObject.GetComponent<Image>().sprite = ability.Value.icon;
                    //Resources.Load<Sprite>("Abilities/" + dropped.name + "_500px")
                    Destroy(dropped);
                    break;
                }
            }
        }
    }
}
