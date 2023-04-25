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
        GameManager.instance.GM_currency = 1000000;
        GameManager.instance.GM_class_selected = "Elementalist";
        GameManager.instance.LoadClassAbilities();

        GameObject.Find("CurrencyText").GetComponent<TextMeshProUGUI>().text = GameManager.instance.GM_currency.ToString();

        LOCAL_buyable_abilities = GameManager.instance.GM_buyable_abilities.OrderBy(x => rng.Next()).Take(3).ToList();
        
        int count = 0;
        foreach (var ability in LOCAL_buyable_abilities){
            Debug.Log(ability.icon);
            buyableAbilities[count].sprite = ability.icon;
            buyableAbilities[count].GetComponent<Button>().onClick.AddListener(delegate { BuyAbility(ability.baseCost, ability.name); });
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyAbility(int cost, string abilityName){
        GameManager.instance.GM_currency -= cost;
        GameObject.Find("CurrencyText").GetComponent<TextMeshProUGUI>().text = GameManager.instance.GM_currency.ToString();
        //put into invetory and remmove from appropriate lists
    }
}
