using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform
    public Vector3 offset = new Vector3(21.92452589f, 1.35306835f, -3.60224581f); // Calculated offset
    public float smoothSpeed = 0.125f;  // Speed of the camera's smoothing

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired position based on the player's position and the offset
            Vector3 desiredPosition = player.position + offset;

            // Smoothly interpolate between the camera's current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;

            // Optionally, make the camera look at the player
            transform.LookAt(player);
        }
    }
}
