using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPostion = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPostion, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
