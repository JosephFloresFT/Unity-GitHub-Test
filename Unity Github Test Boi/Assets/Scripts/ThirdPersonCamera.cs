using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // the target object that the camera will follow
    public float distance = 5.0f; // the distance between the camera and the target
    public float height = 2.0f; // the height of the camera above the target
    public float rotationDamping = 3.0f; // how quickly the camera rotates
    public float heightDamping = 2.0f; // how quickly the camera moves up and down
    public float mouseSensitivity = 2.0f; // how quickly the camera responds to mouse movement

    private float currentRotationAngle = 0.0f;
    private float currentHeight = 0.0f;

    void Start()
    {
        // initialize the camera position and rotation
        currentRotationAngle = target.eulerAngles.y;
        currentHeight = target.position.y + height;
        transform.position = target.position - Quaternion.Euler(0, currentRotationAngle, 0) * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        transform.LookAt(target);
    }

    void LateUpdate()
    {
        // calculate the desired rotation angle based on the mouse movement
        currentRotationAngle += Input.GetAxis("Mouse X") * mouseSensitivity;

        // calculate the desired height based on the mouse movement
        currentHeight -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        currentHeight = Mathf.Clamp(currentHeight, target.position.y - height, target.position.y + height);

        // smoothly rotate the camera towards the desired angle
        //currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, target.eulerAngles.y, rotationDamping * Time.deltaTime);

        // smoothly move the camera towards the desired height
        //currentHeight = Mathf.Lerp(currentHeight, target.position.y + height, heightDamping * Time.deltaTime);

        // convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // set the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // always look at the target
        transform.LookAt(target);
    }
}
