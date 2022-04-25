using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Application.Quit();
        }
    }

    public void LoadDay()
    {
        SceneManager.LoadScene("Level 2(APT)");
    }

    public void LoadNight()
    {
        SceneManager.LoadScene("Level2(Night)");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
