using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //variables
    bool menuActive;
    public Canvas pauseMenuCanvas;


    // Start is called before the first frame update
    void Start()
    {
        menuActive = false;
        Debug.Log(menuActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuActive == false)
        {
            pauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && menuActive == true)
        {
            exitMenu();
        }
        //Debug.Log(menuActive);
    }

    void pauseMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuCanvas.gameObject.SetActive(true);
        menuActive = true;
        Debug.Log("Paused");
    }

    void exitMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuCanvas.gameObject.SetActive(false);
        menuActive = false;
        Debug.Log("Play");
    }
}
