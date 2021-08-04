using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouseGame : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject MainMenu;
    public GameObject Restart;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(gamePaused == false)
            {
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                MainMenu.SetActive(true);
                Restart.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
                MainMenu.SetActive(false);
                Restart.SetActive(false);
                Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
            }
        }
    }
}
