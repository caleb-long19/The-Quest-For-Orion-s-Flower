using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour
{
    public Transform target; // Follow Target (Player)
    public float smoothing = 5.0f; // Float value speed for Camera smooting speed

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z); // Store Players X,Y,Z Position in newPos Variable
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f)); // transform Main Camera Position to newPos Variable and add Smoothing
    }
}
