using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HoverPickClass : MonoBehaviour
{
    public void HoverMage(Image img)
    {
        img.color = new Color(255, 255, 255, 0.04f);
    }

    public void UnHoverMage(Image img)
    {
        img.color = new Color(255, 255, 255, 0);
    }

    public void ShowMageSelection(){
        GameObject.Find("MageSelection").transform.position = new Vector3(0, 0, 0);
    }

    public void HideMageSelection(){
        GameObject.Find("MageSelection").transform.position = new Vector3(0, -1700, 0);
    }

    public void SwitchToMageMap(string subClass){
        GameManager.instance.GM_class_selected = subClass;
        SceneManager.LoadScene("MageMap");
    }
}
