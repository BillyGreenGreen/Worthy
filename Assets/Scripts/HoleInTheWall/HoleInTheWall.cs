using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class HoleInTheWall : MonoBehaviour
{
    private static System.Random rng = new System.Random();
    public Image[] buyableAbilities;
    
    private List<Ability> LOCAL_buyable_abilities = new List<Ability>();
    // Start is called before the first frame update
    void Start()
    {
        //testing, will need to get rid of currency and class selected when you need to
        GameManager.instance.GM_currency = 1000000;
        GameManager.instance.GM_class_selected = "Elementalist";
        GameManager.instance.LoadClassAbilities();

        UpdateCurrencyText();

        Reroll(false);
    }

    public void BuyAbility(int cost, string abilityName, int orderNumberInUI, Sprite abilityIcon){
        if (GameManager.instance.GM_currency - cost >= 0){
            GameManager.instance.GM_currency -= cost;
            UpdateCurrencyText();
            string goName = "BuyAbility" + orderNumberInUI.ToString();
            Debug.Log(goName);
            GameObject.Find(goName).GetComponent<Button>().interactable = false;
            GameObject.Find(goName).GetComponentInChildren<TextMeshProUGUI>().text = "";
            AddToInventory(abilityIcon);
            //put into inventory and remmove from appropriate lists
            List<Ability> l = GameManager.instance.GM_buyable_abilities;
            foreach (var ability in l){
                if (ability.name == abilityName){
                    GameManager.instance.GM_buyable_abilities.Remove(ability);
                    GameManager.instance.GM_bought_abilities.Add(ability);
                }
            }
            
        }
        
    }

    void AddToInventory(Sprite abilityIcon){
        List<Transform> children = GameObject.Find("AbilityGrid").GetComponentsInChildren<Transform>().ToList();
        foreach (Transform child in children){
            if (child.gameObject.GetComponent<Image>() != null && child.gameObject.GetComponent<Image>().enabled == false){
                child.gameObject.GetComponent<Image>().enabled = true;
                child.gameObject.GetComponent<Image>().sprite = abilityIcon;
                child.gameObject.name = abilityIcon.name.Substring(0, abilityIcon.name.Length-6);
                break;
            }
            Debug.Log(child.gameObject.name);
        }
        foreach(var ability in GameManager.instance.GM_bought_abilities){

        }
    }

    public void Reroll(bool buttonClick){
        if (buttonClick){
            GameManager.instance.GM_currency -= 2000;
            UpdateCurrencyText();
        }
        LOCAL_buyable_abilities = GameManager.instance.GM_buyable_abilities.OrderBy(x => rng.Next()).Take(3).ToList();
        
        int count = 0;
        foreach (var ability in LOCAL_buyable_abilities){
            Debug.Log(ability.icon);
            buyableAbilities[count].sprite = ability.icon;

            if (count == 0){
                buyableAbilities[count].GetComponent<Button>().onClick.RemoveAllListeners();
                buyableAbilities[count].GetComponent<Button>().onClick.AddListener(delegate { BuyAbility(ability.baseCost, ability.name, 1, ability.icon); });
                buyableAbilities[count].GetComponent<Button>().interactable = true;
                buyableAbilities[count].GetComponentInChildren<TextMeshProUGUI>().text = ability.baseCost.ToString();
            }
            else if (count == 1){
                buyableAbilities[count].GetComponent<Button>().onClick.RemoveAllListeners();
                buyableAbilities[count].GetComponent<Button>().onClick.AddListener(delegate { BuyAbility(ability.baseCost, ability.name, 2, ability.icon); });
                buyableAbilities[count].GetComponent<Button>().interactable = true;
                buyableAbilities[count].GetComponentInChildren<TextMeshProUGUI>().text = ability.baseCost.ToString();
            }
            else if (count == 2){
                buyableAbilities[count].GetComponent<Button>().onClick.RemoveAllListeners();
                buyableAbilities[count].GetComponent<Button>().onClick.AddListener(delegate { BuyAbility(ability.baseCost, ability.name, 3, ability.icon); });
                buyableAbilities[count].GetComponent<Button>().interactable = true;
                buyableAbilities[count].GetComponentInChildren<TextMeshProUGUI>().text = ability.baseCost.ToString();
            }
            
            count++;
        }
    }

    void UpdateCurrencyText(){
        GameObject.Find("CurrencyText").GetComponent<TextMeshProUGUI>().text = GameManager.instance.GM_currency.ToString();
    }
}
