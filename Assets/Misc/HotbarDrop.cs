using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class HotbarDrop : MonoBehaviour, IDropHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject hotbar;
    [SerializeField] private GameObject draggableHotbarAbility;

    [SerializeField] private List<GameObject> hotbarAbilities;
    [SerializeField] private Collider2D draggableCollider;
    [SerializeField] private Collider2D inventoryCollider;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private GameObject draggedGameObject;
    private bool notDraggable;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnDrop(PointerEventData eventData){
        
        GameObject slotFrom = eventData.pointerDrag;
        Debug.Log("CHEESE" + slotFrom.name);
        
        if (gameObject.GetComponent<Image>().sprite.name == "circle"){ //if there is an empty space
            Debug.Log("EMPTTY SPACE");
            if (slotFrom.name.Contains("Ability")){
                //we are swapping abilities on the hotbar into empty space
                foreach(KeyValuePair<int, Ability> ability in GameManager.instance.GM_hotbar_abilities){
                    if (gameObject.name.EndsWith(ability.Key.ToString())){
                        ability.Value.name = draggableHotbarAbility.name;
                        ability.Value.UpdateAbility();
                        gameObject.GetComponent<Image>().sprite = ability.Value.icon;
                        slotFrom.GetComponent<Image>().sprite = Resources.Load<Sprite>("Abilities/circle");
                        //Resources.Load<Sprite>("Abilities/" + dropped.name + "_500px")
                        //Destroy(dropped);
                        break;
                    }
                }

                //Update where the ability came from on hotbar
                foreach(KeyValuePair<int, Ability> ability in GameManager.instance.GM_hotbar_abilities){
                    if (slotFrom.name.EndsWith(ability.Key.ToString())){
                        ability.Value.name = "NoAbility";
                        ability.Value.UpdateAbility();
                    }
                }
            }
            else{ //if dragging from anywhere else into empty slot
                int slotToSwitch = -1;
                foreach(KeyValuePair<int, Ability> ability in GameManager.instance.GM_hotbar_abilities){
                    if (gameObject.name.EndsWith(ability.Key.ToString())){
                        ability.Value.name = slotFrom.name;
                        ability.Value.UpdateAbility();
                        foreach (GameObject go in hotbarAbilities){
                            if (go.GetComponent<Image>().sprite == ability.Value.icon){
                                go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Abilities/circle");
                                slotToSwitch = Convert.ToInt32(go.name.Substring(go.name.Length-1));
                            }
                        }
                        gameObject.GetComponent<Image>().sprite = ability.Value.icon;
                        //Resources.Load<Sprite>("Abilities/" + dropped.name + "_500px")
                        //Destroy(dropped);
                        break;
                    }
                }

                foreach(KeyValuePair<int, Ability> ability in GameManager.instance.GM_hotbar_abilities){
                    if (slotToSwitch == ability.Key){
                        ability.Value.name = "NoAbility";
                        ability.Value.UpdateAbility();
                    }
                }
            }
            
        }
        else{
            Debug.Log("NOT EMPTY SPACE");
            if (slotFrom.name.Contains("Ability")){
                string abilityNameToSwitch = "";
                //we are swapping abilities on the hotbar into empty space
                foreach(KeyValuePair<int, Ability> ability in GameManager.instance.GM_hotbar_abilities){
                    if (gameObject.name.EndsWith(ability.Key.ToString())){
                        ability.Value.name = draggableHotbarAbility.name;
                        ability.Value.UpdateAbility();
                        abilityNameToSwitch = gameObject.GetComponent<Image>().sprite.name.Substring(0, gameObject.GetComponent<Image>().sprite.name.Length-6);
                        slotFrom.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;//change dragged from slot icon
                        gameObject.GetComponent<Image>().sprite = ability.Value.icon;
                        //Resources.Load<Sprite>("Abilities/" + dropped.name + "_500px")
                        //Destroy(dropped);
                        break;
                    }
                }

                //Update where the ability came from on hotbar
                foreach(KeyValuePair<int, Ability> ability in GameManager.instance.GM_hotbar_abilities){
                    if (slotFrom.name.EndsWith(ability.Key.ToString())){
                        ability.Value.name = abilityNameToSwitch;
                        ability.Value.UpdateAbility();
                    }
                }
            }
            else{ //if dragging from anywhere else into non empty slot
                
                foreach(KeyValuePair<int, Ability> ability in GameManager.instance.GM_hotbar_abilities){
                    if (gameObject.name.EndsWith(ability.Key.ToString())){
                        ability.Value.name = slotFrom.name;
                        ability.Value.UpdateAbility();
                        foreach (GameObject go in hotbarAbilities){
                            if (go.GetComponent<Image>().sprite == ability.Value.icon){
                                go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Abilities/circle");
                            }
                        }
                        gameObject.GetComponent<Image>().sprite = ability.Value.icon;
                        //Resources.Load<Sprite>("Abilities/" + dropped.name + "_500px")
                        //Destroy(dropped);
                        break;
                    }
                }

                


            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData){
        canvasGroup.alpha = .6f;
        draggableHotbarAbility.transform.SetParent(transform.root);
        draggableHotbarAbility.transform.SetAsLastSibling();
        draggableHotbarAbility.transform.position = gameObject.transform.position;

        
    }

    public void OnEndDrag(PointerEventData eventData){
        if (GameManager.instance.canDropAbilityInInventory){
            GameObject slotFrom = eventData.pointerDrag;
            Debug.Log("CHEESE" + slotFrom.name);
            foreach(KeyValuePair<int, Ability> ability in GameManager.instance.GM_hotbar_abilities){
                if (gameObject.name.EndsWith(ability.Key.ToString())){
                    ability.Value.name = "NoAbility";
                    ability.Value.UpdateAbility();
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Abilities/circle");
                }
            }
        }
        notDraggable = false;
        canvasGroup.alpha = 1f;
        draggableHotbarAbility.transform.position = new Vector3(40000, 40000, 50);
        //Debug.Log("END DRAG");
    }

    public void OnDrag(PointerEventData eventData){
        if (!notDraggable){
            draggableHotbarAbility.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
            //Debug.Log(draggableHotbarAbility.transform.position);
            
        }
    }
    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
        if (gameObject.GetComponent<Image>().sprite.name != "circle"){ //for some reason when instatiateing the gameobject and we remove commpooinents it does it but thinks its dragging the old gameobject
            draggableHotbarAbility.name = gameObject.GetComponent<Image>().sprite.name.Substring(0, gameObject.GetComponent<Image>().sprite.name.Length-6);
            draggableHotbarAbility.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            //draggedGameObject.transform.SetParent(canvas.transform);
            draggableHotbarAbility.GetComponent<CanvasGroup>().blocksRaycasts = false;

            //draggedGameObject = Instantiate(dragObject, gameObject.transform.position, Quaternion.identity);
            /*draggedGameObject.transform.SetParent(canvas.transform);
            draggedGameObject.transform.localScale = gameObject.transform.localScale;
            draggedGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
            draggedGameObject.name = draggedGameObject.GetComponent<Image>().sprite.name.Substring(0, draggedGameObject.GetComponent<Image>().sprite.name.Length-6);
            draggedGameObject.AddComponent<DragDrop>();
            draggedGameObject.GetComponent<DragDrop>().canvas = transform.root.GetComponent<Canvas>();*/
        }
        else{
            notDraggable = true;
        }
        
    }

}
