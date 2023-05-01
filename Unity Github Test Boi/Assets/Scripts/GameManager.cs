using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //variables
    bool gameActive;
    public Button startButton;
    public Button quitButton;
    public Canvas mainCanvas;
    public bool activeMenu;
    public GameObject pauseMenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(quitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        mainCanvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        activeMenu = false;
    }

    void quitGame()
    {
        Debug.Log("We Just Quit the Game");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {/*
        if (Input.GetKeyDown(KeyCode.Escape) && activeMenu == false)
        {
            pauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && activeMenu == true)
        {
            exitMenu();
        }*/
    }
}
