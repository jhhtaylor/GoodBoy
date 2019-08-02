using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object


    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    public bool useOffsetValues;

    public float rotateSpeed;

    public Transform pivot;
    // Use this for initialization
    void Start()
    {
        //if(!useOffsetValues)
        //{
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = player.transform.position - transform.position;
        //}

        pivot.transform.position = player.transform.position;
        pivot.transform.parent = player.transform;
        //can't see cursor
        Cursor.lockState = CursorLockMode.Locked;

    }


    void LateUpdate()
    {
        //get the x position of the mouse and rotate the player
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.transform.Rotate(0, horizontal, 0);
        //get the y position of the mouse and rotate the pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.transform.Rotate(-vertical, 0, 0);

        //move the camera based on the current rotation of the target and the original offset
        float desiredYAngle = player.transform.eulerAngles.y;
        float desiredXAngle = pivot.transform.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = player.transform.position - (rotation * offset);

        //make camera not go below ground
        if (transform.position.y < player.transform.position.y)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y/*- .5f*/, transform.position.z);
        }

        //look at player
        transform.LookAt(player.transform);

    }

    //void LateUpdate()
    //{
    //    transform.position = player.transform.position + offset;
    //}
}