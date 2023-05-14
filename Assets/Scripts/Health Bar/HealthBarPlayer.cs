using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    public Player player;
    public Slider healthSlider;
    public Slider shieldSlider;

    private void Start() {
        healthSlider.maxValue = player.maxHealth;
        shieldSlider.maxValue = player.maxHealth;
    }

    public void SetHealth(int amount){
        healthSlider.value = amount;
    }
    public void SetShield(int amount){
        shieldSlider.value = amount;
    }
}
