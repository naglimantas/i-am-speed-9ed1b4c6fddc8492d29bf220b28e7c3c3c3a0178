using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

// AI CAR
public class Brain : MonoBehaviour
{

    public Path path;
    Transform target;
    public float minTurnAngle = 1f;
    public float minTargetDistance = 1f;
    public float turnSensitivity;

    Vehicle vehicle;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
        target = path.GetClosestPoint(transform.position);
    }

    void Update()
    {
        vehicle.Gas();

        //get turn side
        float angle = Vector3.SignedAngle(transform.forward, target.position - transform.position, Vector3.up);
        if(angle < -minTurnAngle || angle > minTurnAngle)
        {
            float side = Mathf.Sign(angle);
            //kokiu stiprumu suks = power, abs = modulis
            float power = Mathf.Abs(angle) / turnSensitivity;
            vehicle.Turn(side * power);
        }


        //get next checkpoint
        var distance = Vector3.Distance(transform.position, target.position);
        if (distance < minTargetDistance)
        {
            target = path.GetNextPoint(target);
        }
    }
}