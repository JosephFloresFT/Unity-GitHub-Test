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
    public Button resumeButton;
    public Button mainMenuButton;
    private ThirdPersonCamera cam;
    public Canvas loadingScreen;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menuActive = false;
        Debug.Log(menuActive);
        cam = GameObject.Find("Main Camera").GetComponent<ThirdPersonCamera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuActive == false)
            {
                pauseMenu();
            }
        }

        if (menuActive)
        {
            resumeButton.onClick.AddListener(exitMenu);
            mainMenuButton.onClick.AddListener(loadTitleScreen);
        }
    }

    void pauseMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuCanvas.gameObject.SetActive(true);
        menuActive = true;
        Debug.Log("Paused");
        cam.enabled = false;
    }

    void exitMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuCanvas.gameObject.SetActive(false);
        menuActive = false;
        Debug.Log("Play");
        cam.enabled = true;
    }

    void loadTitleScreen()
    {
        loadingScreen.gameObject.SetActive(true);
        SceneManager.LoadScene("TitleScreen");
    }
}
