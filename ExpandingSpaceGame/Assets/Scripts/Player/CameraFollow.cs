using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraFollowSpeed = 120f;
    public GameObject cameraFollowObject;
    private Vector3 followPos;
    public float clampAngle = 80f;
    public float inputSensitivity = 150f;
    public GameObject cameraObject;
    public GameObject playerObject;
    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotY = 0f;
    private float rotX = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotY = rotation.y;
        rotX = rotation.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //we need to setup the rotation of the sticks here
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0);
        transform.rotation = localRotation;

        //gameObject.transform.eulerAngles = new Vector3(cameraObject.transform.eulerAngles.x, rotY, cameraObject.transform.eulerAngles.x);
    }

    private void LateUpdate()
    {
        CameraUpdater();
    }

    public void CameraUpdater()
    {
        //set target object
        Transform target = cameraFollowObject.transform;
        //move towards gameobject that is the target

        float step = cameraFollowSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}