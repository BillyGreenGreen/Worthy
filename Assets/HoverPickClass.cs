using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPickClass : MonoBehaviour
{
    public void HoverMage(SpriteRenderer sr)
    {
        sr.color = new Color(255, 255, 255, 10);
    }

    public void UnHoverMage(SpriteRenderer sr)
    {
        sr.color = new Color(255, 255, 255, 0);
    }
}
