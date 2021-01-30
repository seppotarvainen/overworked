using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraScript : MonoBehaviour
{

    public Transform target;
    public float speed = 0.0125f;
    public Vector3 offset;
    private Vector3 shakeOffset;

    void FixedUpdate()
    {
        if (target != null) {
            Vector3 desiredPos = target.position + offset;
            Vector3 scaledPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
            Vector3 smoothPos = Vector3.Lerp(scaledPos, desiredPos, speed);
            transform.position = smoothPos + shakeOffset;
        }
    }
}
