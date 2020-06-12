using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    public bool isFlying;
    public float particlePlayDistance = 0.2f;
    public ParticleSystem afterFallParticle;

    public Camera playerCam;
    public Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        isFlying = controller.isGrounded;
    }

    // Update is called once per frame
    private void Update()
    {
        //checkForLanding();
        rotate();
        move();
        animate();
    }

    public void move()
    {
        if (canMove == false) return;
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") / 2, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
            jumps = 0;
        }
        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") / 2, moveDirection.y, Input.GetAxis("Vertical"));
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
        transform.eulerAngles = new Vector3(0, playerCam.transform.rotation.eulerAngles.y, 0);
        //Vector3 Rot = new Vector3(this.transform.eulerAngles.x, playerCam.transform.eulerAngles.y, this.transform.eulerAngles.z);
        //this.transform.eulerAngles = Rot;
    }

    public void checkForLanding()
    {
        RaycastHit hit;
        Debug.DrawRay(this.transform.position + new Vector3(0, particlePlayDistance, 0), this.transform.TransformDirection(Vector3.down) * particlePlayDistance, Color.red);
        if (Physics.Raycast(this.transform.position + new Vector3(0, particlePlayDistance, 0), this.transform.TransformDirection(Vector3.down), out hit, particlePlayDistance))
        {
            if (hit.collider != null)
            {
                //de raycast raakt iets.. en is de speler dus bijna grounded
                if (isFlying == true)
                {
                    afterFallParticle.Play();
                }
                isFlying = false;
            }
        }
        else
        {
            isFlying = true;
        }

        //standaard uitvoeren:
    }

    public void animate()
    {
        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }
}