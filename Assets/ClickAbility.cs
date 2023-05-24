using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAbility : MonoBehaviour, IPointerDownHandler
{
    private Canvas canvas;
    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
        GameManager.instance.upgradeMenuOpen = true;
        canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        GameObject panel = Instantiate(Resources.Load<GameObject>("HoleInTheWall/Upgrade"), new Vector3(0,0,0), Quaternion.identity);
        panel.transform.parent = GameObject.Find("UpgradePanel").transform;
        panel.transform.localScale = new Vector3(1,1,1);
        panel.transform.localPosition = new Vector3(0,0,22);
        panel.transform.Find("Abilities").Find("0,0").GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        //need to add other icons maybe with just a number on themm and a price next to them or under them cutting off the line, then when clicked we update the player pref
        //and then use ability.UpdateAbility() within the bought abilities and also hotbar abilities to add it to the game then donezo



        /*foreach(var ability in GameManager.instance.GM_bought_abilities){
            if (ability.name == gameObject.name){
                PlayerPrefs.SetString(ability.name + "_MorphLevel", "1,1");
                ability.UpdateAbility();
            }
        }*/
    }
}
