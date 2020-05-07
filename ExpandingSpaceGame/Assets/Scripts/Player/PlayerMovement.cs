using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canmove = true;
    public float speed = 6f;
    public float gravity = 20f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    public float jumpspeed = 8f;
    public int maxDubbleJumps = 0;
    public int jumps;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        move();
    }

    public void move()
    {
        if (canmove == false) { return; }
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpspeed;
            }
            jumps = 0;
        }
        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;
            if (Input.GetKeyDown(KeyCode.Space) && jumps < maxDubbleJumps)
            {
                moveDirection.y = jumpspeed;
                jumps++;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}