using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationMovement : MonoBehaviour
{
    public bool canmousemove = true;
    private CharacterController controller;
    public float speedY = 1f;
    public float speedX = 1f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        MouseMovement();
    }

    public void MouseMovement()
    {
        if (canmousemove == false) { return; }
        yaw += speedX * Input.GetAxis("Mouse X");
        pitch -= speedY * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -20f, 28f);
        transform.eulerAngles = new Vector3(0, yaw, 0);
    }
}