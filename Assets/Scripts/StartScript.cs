using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Application.Quit();
        }
    }

    public void LoadShootingRange()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadDay()
    {
        SceneManager.LoadScene("Level 2(APT)");
    }

    public void LoadNight()
    {
        SceneManager.LoadScene("Level2(Night)");
    }

    public void LoadNightHard()
    {
        SceneManager.LoadScene("Level2(NightAndHard)");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
