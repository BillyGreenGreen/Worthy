using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverMenuButton : MonoBehaviour
{
    public int startingFontSize = 50;
    public int endingFontSize = 70;

    float lerp1 = 0f;
    float lerp2 = 0f;
    bool hover = false;
    TextMeshProUGUI buttonText;
    bool firstTime = true;
    private void Update()
    {
        if (!firstTime)
        {
            if (hover)
            {
                EaseIn();
                lerp2 = 0f;
            }
            else
            {
                EaseOut();
                lerp1 = 0f;
            }
        }
        
    }

    void EaseIn()
    {
        lerp1 += Time.deltaTime / 0.1f;
        buttonText.fontSize = (int)Mathf.Lerp(startingFontSize, endingFontSize, lerp1);
    }

    void EaseOut()
    {
        lerp2 += Time.deltaTime / 0.1f;
        buttonText.fontSize = (int)Mathf.Lerp(endingFontSize, startingFontSize, lerp2);
    }
    public void OnHoverTextEnlarge(TextMeshProUGUI text)
    {
        if (firstTime)
        {
            firstTime = false;
        }
        hover = true;
        buttonText = text;
    }

    public void OnHoverTextDecrease(TextMeshProUGUI text)
    {
        hover = false;
        buttonText = text;
    }
}
