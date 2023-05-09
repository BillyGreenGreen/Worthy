using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverInventoryWithAbility : MonoBehaviour
{
    [SerializeField] private Image clearSlotGraphic;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "InventoryGrid"){
            GameManager.instance.canDropAbilityInInventory = true;
            clearSlotGraphic.enabled = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.name == "InventoryGrid"){
            GameManager.instance.canDropAbilityInInventory = false;
            clearSlotGraphic.enabled = false;
        }
    }
}
