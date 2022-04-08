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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSensitivity()
    {
        MouseLook.sensitivity = sensitivitySlider.value;

        //PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);
        //MouseLook.sensitivity = PlayerPrefs.GetFloat("Sensitivity");
    }

    public void ChangeFOV()
    {
        Camera.main.fieldOfView = FOVSlider.value;
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("StartMenuScene");
    }
}
