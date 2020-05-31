using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public float speed = 4f;
    //public float rot = 0f;
    //public float rotSpeed = 80f;
    //public float gravity = 8f;

    //public Vector3 moveDirection = Vector3.zero;

    //public CharacterController controller;

    //private void Start()
    //{
    //    controller = this.GetComponent<CharacterController>();
    //}

    //private void Update()
    //{
    //    if (controller.isGrounded)
    //    {
    //        if (Input.GetKey(KeyCode.W))
    //        {
    //            moveDirection = new Vector3(0, 0, 1);
    //            moveDirection *= speed;
    //            moveDirection = transform.TransformDirection(moveDirection);
    //        }
    //    }
    //    rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
    //    transform.eulerAngles = new Vector3(0, rot, 0);

    //    moveDirection.y -= gravity;
    //    controller.Move(moveDirection * Time.deltaTime);
    //    moveDirection = Vector3.zero;
    //}

    public bool canMove = true;
    public float speed = 6f;
    public float gravity = 20f;

    public Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;

    public float jumpSpeed = 8f;
    public int maxDoubleJumps = 0;
    public int jumps;

    public float rot = 0f;
    public float rotSpeed = 150f;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        rotate();
        move();
    }

    public void move()
    {
        if (canMove == false) return;
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
            jumps = 0;
        }
        else
        {
            moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;
            if (Input.GetKeyDown(KeyCode.Space) && jumps < maxDoubleJumps)
            {
                moveDirection.y = jumpSpeed;
                jumps++;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void rotate()
    {
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
    }
}