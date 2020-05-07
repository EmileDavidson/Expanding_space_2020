using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public bool canmousemove = true;
    private CharacterController controller;
    public float speedY = 1f;
    public float speedX = 1f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public Transform camTransform;
    public float vertClampMin = 20f;
    public float vertClampMax = 28f;

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
        verticalmove();
    }

    public void MouseMovement()
    {
        if (canmousemove == false) { return; }
        yaw += speedX * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0, yaw, 0);
    }

    public void verticalmove()
    {
        if (canmousemove == false) { return; }
        pitch -= speedY * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, vertClampMin, vertClampMax);
        camTransform.localEulerAngles = new Vector3(pitch, 0, 0);
    }
}