using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [SerializeField]
    private Slider sensitivitySlider;

    [SerializeField]
    private Slider FOVSlider;

    public void ChangeSensitivity()
    {
        //Change the mouse sensitivity based on the value from the slider
        MouseLook.sensitivity = sensitivitySlider.value;
    }

    public void ChangeFOV()
    {
        //Change the main cameras fov based on the value from the slider
        Camera.main.fieldOfView = FOVSlider.value;
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("StartMenuScene");
    }
}
