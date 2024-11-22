using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class VehicleCamera : MonoBehaviour
{
    [Range(0, 0.1f)]public float posStep;
    public Vector3 offset;
    public Transform target;
    public Camera cam;
    public Vehicle targets;


    void LateUpdate()
    {
        cam.fieldOfView = Mathf.Lerp(50f, 100f, targets.speedRatio);
        //var targetPos = target.position + transform.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, target.position, posStep);
        transform.forward = target.forward;

    }
}
