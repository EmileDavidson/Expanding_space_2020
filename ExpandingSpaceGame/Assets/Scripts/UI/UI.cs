using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public int sceneIndex;
    /*MENU*/
    public void NextScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}