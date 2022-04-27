using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    Canvas pauseMenuCanvas;

    [SerializeField]
    Canvas settingsMenuCanvas;

    [SerializeField]
    Canvas crossHairCanvas;

    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   

    // Update is called once per frame
    void Update()
    {

      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsMenuCanvas.enabled == true)
            {
                pauseMenuCanvas.enabled = true;
                settingsMenuCanvas.enabled = false;
            }
            if (crossHairCanvas.enabled == true)
            {
                settingsMenuCanvas.enabled = false;
                crossHairCanvas.enabled = false;

            }

            if (isPaused)
            {
                Resume();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Pause();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseMenuCanvas.enabled = true;

    }

    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuCanvas.enabled = false;

    }

    public void QuitGame()
    {
        
    }

   
}
