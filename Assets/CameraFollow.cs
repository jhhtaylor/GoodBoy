using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object


    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    public bool useOffsetValues;

    public float rotateSpeed;
    // Use this for initialization
    void Start()
    {
        //if(!useOffsetValues)
        //{
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = player.transform.position - transform.position ;
        //}

    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        //get the x position of the mouse and rotate the player
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        player.transform.Rotate(vertical, 0, 0);

        //move the camera based on the current rotation of the target and the original offset
        float desiredYAngle = player.transform.eulerAngles.y;
        float desiredXAngle = player.transform.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(0, desiredYAngle, 0);
        transform.position = player.transform.position - (rotation * offset);
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.position = player.transform.position - offset;
        transform.LookAt(player.transform);
        
    }

    //void LateUpdate()
    //{
    //    transform.position = player.transform.position + offset;
    //}
}