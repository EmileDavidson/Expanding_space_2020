using UnityEngine;

public class GravityObjecten : MonoBehaviour
{
    public bool done = false;
    public Rigidbody rb;
    public float distanceToGround;
    public RotationScript rotScript;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        distanceToGround = gameObject.GetComponent<Collider>().bounds.extents.y;
    }

    private void Update()
    {
        if (rotScript.canMove)
        {
            if (IsGrounded())
            {
                done = true;
            }
            else
            {
                done = false;
            }
        }
    }

    public bool IsGrounded()
    {
        distanceToGround = gameObject.GetComponent<Collider>().bounds.extents.y;
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }
}