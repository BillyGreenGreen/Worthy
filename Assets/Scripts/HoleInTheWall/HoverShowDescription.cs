using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoverShowDescription : MonoBehaviour
{
    private Canvas canvas;
    private Sprite abilitySprite;
    private GameObject card;
    private float xOffset;
    private float yOffset;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        abilitySprite = gameObject.GetComponent<Image>().sprite;
        xOffset = 1.5f;
        yOffset = 2;
    }

    private void Update() {
        if (abilitySprite != null)
            abilitySprite = gameObject.GetComponent<Image>().sprite;
    }

    private void OnMouseEnter() {
        Debug.Log("ENETER");
        if (gameObject.name == "handwall"){ //just for popup on wall hand texture
            Vector3 mousePos = Input.mousePosition;
            //mousePos.x -= xOffset;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.y += 2;
            objectPos.z = 0;
            card = Instantiate(Resources.Load<GameObject>("HoleInTheWall/cardhoverPrefab"), objectPos, Quaternion.identity);
            card.transform.Find("Canvas").Find("AbilityDescription").GetComponent<TextMeshProUGUI>().text = "Yeah yeah, calm down\nI cant do art so this\nwill have to do for now...\nStop looking at it.";
        }
        else if (abilitySprite.name != "circle"){
            if (gameObject.CompareTag("InventoryIcons")){
                Vector3 mousePos = Input.mousePosition;
                //mousePos.x -= xOffset;
                Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                objectPos.x -= xOffset;
                objectPos.z = 0;
                card = Instantiate(Resources.Load<GameObject>("HoleInTheWall/cardhoverPrefab"), objectPos, Quaternion.identity);
                card.transform.Find("Canvas").Find("AbilityImage").GetComponent<Image>().sprite = abilitySprite;
                string abilityName = abilitySprite.name.Split("_")[1];
                abilityName = string.Concat(abilityName.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
                card.transform.Find("Canvas").Find("AbilityName").GetComponent<TextMeshProUGUI>().text = abilityName;
                string name = abilitySprite.name.Split("_")[0] + "_" + abilitySprite.name.Split("_")[1];
                Debug.Log(name);
                Ability a = new Ability(name);
                a.UpdateAbility();
                card.transform.Find("Canvas").Find("AbilityDescription").GetComponent<TextMeshProUGUI>().text = a.description;
            }
            else{
                Vector3 mousePos = Input.mousePosition;
                //mousePos.y += yOffset;
                Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                objectPos.y += yOffset;
                objectPos.z = 0;
                card = Instantiate(Resources.Load<GameObject>("HoleInTheWall/cardhoverPrefab"), objectPos, Quaternion.identity);
                card.transform.Find("Canvas").Find("AbilityImage").GetComponent<Image>().sprite = abilitySprite;
                string abilityName = abilitySprite.name.Split("_")[1];
                abilityName = string.Concat(abilityName.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
                card.transform.Find("Canvas").Find("AbilityName").GetComponent<TextMeshProUGUI>().text = abilityName;
                string name = abilitySprite.name.Split("_")[0] + "_" + abilitySprite.name.Split("_")[1];
                Debug.Log(name);
                Ability a = new Ability(name);
                a.UpdateAbility();
                card.transform.Find("Canvas").Find("AbilityDescription").GetComponent<TextMeshProUGUI>().text = a.description;
            }
        }
        
    }

    private void OnMouseOver() {
        if (abilitySprite == null){
            Vector3 mousePos = Input.mousePosition;
            //mousePos.y += yOffset;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.y += 2;
            objectPos.z = 0;
            card.transform.position = objectPos;
        }
        else if (abilitySprite.name != "circle"){
            if (gameObject.CompareTag("InventoryIcons")){
                Vector3 mousePos = Input.mousePosition;
                //mousePos.x -= xOffset;
                Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                objectPos.x -= xOffset;
                objectPos.z = 0;
                card.transform.position = objectPos;
            }
            else{
                Vector3 mousePos = Input.mousePosition;
                //mousePos.y += yOffset;
                Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                objectPos.y += yOffset;
                objectPos.z = 0;
                card.transform.position = objectPos;
            }
        }
    }

    private void OnMouseExit() {
        Destroy(card);
    }
}
