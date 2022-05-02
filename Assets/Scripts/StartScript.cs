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
        SceneManager.LoadScene("Level 2Easy");
    }

    public void LoadDayHard()
    {
        SceneManager.LoadScene("Level2DayHard");
    }

    public void LoadNight()
    {
        SceneManager.LoadScene("Level2NightEasy");
    }

    public void LoadNightHard()
    {
        SceneManager.LoadScene("Level2NightHard");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
