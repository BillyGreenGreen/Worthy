using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugStuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("Map"));
        Debug.Log(GameObject.Find("MapManager"));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
