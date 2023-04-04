using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverSubClass : MonoBehaviour
{

    public GameObject rightClass;
    public GameObject leftClass;
    // Start is called before the first frame update
    void Start()
    {
        rightClass.GetComponent<Image>().color = new Color(0, 0, 0, 0.66f);
        leftClass.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    public void Hover(Image image){
        image.color = new Color(0, 0, 0, 0);
    }

    public void UnHover(Image image){
        image.color = new Color(0, 0, 0, 0.66f);
    }
}
