using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    [SerializeField] List<Image> potionSlotsUnder = new List<Image>();
    [SerializeField] List<ParticleSystem> particles;

    private void Start() {
        foreach (ParticleSystem ps in particles){
            ps.Stop();
        }
    }

    [System.Obsolete]
    private void Update() {
        int count = 0;
        foreach (Potion potion in GameManager.instance.GM_hotbar_potions.Values){
            if (Input.GetKeyDown(potion.keyBind) && !potion.potionIsBeingUsed){
                Debug.Log(potion._name);
                potion.potionIsBeingUsed = true;
                potion.ActivatePotion();
                potionSlotsUnder[count].sprite = Resources.Load<Sprite>("Potions/PotionUnderUsing");
                if (potion._name.Contains("Worthy")){
                    particles[count].startColor = ConvertColorTo01(217, 170, 0);
                }
                else if (potion._name.Contains("Speed")){
                    particles[count].startColor = ConvertColorTo01(2, 149, 181);
                }
                else if (potion._name.Contains("Evasion")){
                    particles[count].startColor = ConvertColorTo01(4, 162, 5);
                }
                else if (potion._name.Contains("Power")){
                    particles[count].startColor = ConvertColorTo01(152, 1, 9);
                }
                particles[count].Play();
            }
            else if (potion.potionIsBeingUsed){
                potion.timeRemaining -= Time.deltaTime;
                if (potion.timeRemaining <= 0f){
                    potion.RemovePotion();
                    potionSlotsUnder[count].sprite = Resources.Load<Sprite>("Potions/PotionUnder");
                    particles[count].Stop();
                }
            }
            count++;
        }
    }

    private Color ConvertColorTo01 (int r, int g, int b){
        return new Color(r/255.0f, g/255.0f, b/255.0f);
    }
}