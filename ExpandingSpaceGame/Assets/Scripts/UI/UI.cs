using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public int sceneIndex;
    public Text ui_Text;

    //When the mouse hovers over the GameObject, it turns to this color (red)
    private Color m_MouseOverColor = Color.gray;

    //This stores the GameObject’s original color
    private Color m_OriginalColor;

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    private MeshRenderer m_Renderer;

    private void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        m_OriginalColor = m_Renderer.material.color;
        ui_Text.enabled = false;
    }

    private void OnMouseOver()
    {
        // Change the color of the GameObject to red when the mouse is over GameObject
        m_Renderer.material.color = m_MouseOverColor;
        ui_Text.enabled = true;
    }

    private void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        m_Renderer.material.color = m_OriginalColor;
        ui_Text.enabled = false;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}