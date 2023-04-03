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

    public void SwitchToTestGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
