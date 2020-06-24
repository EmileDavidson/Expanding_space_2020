using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauzeGame : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject gameObject;
    public GameObject PauseScreen;

    private void Start()
    {
        PauseGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            PauseScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log(gameIsPaused);
            Debug.Log(Cursor.visible);
            Debug.Log(Cursor.lockState);
        }
        else
        {
            Time.timeScale = 1f;
            PauseScreen.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log(gameIsPaused);
            Debug.Log(Cursor.visible);
            Debug.Log(Cursor.lockState);
        }
    }
}