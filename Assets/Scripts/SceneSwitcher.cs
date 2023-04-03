using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void S_SwitchToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void S_SwitchToSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void S_SwitchToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void S_SwitchToClassPicker()
    {
        SceneManager.LoadScene("ClassPicker");
    }
}
