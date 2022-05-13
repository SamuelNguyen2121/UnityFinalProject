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
        Time.timeScale = 1;
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

                //Lock the cursor
                Cursor.lockState = CursorLockMode.Locked;

                //Make cursor invisible
                Cursor.visible = false;
            }
            else
            {
                Pause();
                //Un lock the cursor
                Cursor.lockState = CursorLockMode.None;

                //Make the cursor visible
                Cursor.visible = true;
            }
        }
    }
    public void Pause()
    {
        //Freeze the game
        Time.timeScale = 0;
        isPaused = true;
        pauseMenuCanvas.enabled = true;

    }

    public void Resume()
    {

        //Unfreeze the game 
        Time.timeScale = 1;
        isPaused = false;

        //Lock the cursos 
        Cursor.lockState = CursorLockMode.Locked;

        //Make the cursor invisible
        Cursor.visible = false;
        pauseMenuCanvas.enabled = false;

    }
}
