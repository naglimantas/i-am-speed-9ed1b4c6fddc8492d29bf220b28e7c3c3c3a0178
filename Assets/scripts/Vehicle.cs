using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Vehicle : MonoBehaviour
{ 
    public float accelaration;
    public float decelaration;
    public float maxSpeed;
    public float maxReverseSpeed;
    public float speed;
    public float turnSpeed;
    public float speedRatio;
    public float fakeSpeed;
    public AnimationCurve enginePitchCurve;
    public TMP_Text speedNumber;

    public AudioSource engineSound;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Gas()
    {
        speed += accelaration * Time.deltaTime;
        if(speed > maxSpeed) speed = maxSpeed;
    }

    public void Brake()
    {
        speed -= decelaration * Time.deltaTime;
        if (speed < -maxSpeed) speed = -maxSpeed;
    }
    private void Update()
    {
        speedRatio = speed / maxSpeed;
        engineSound.pitch = enginePitchCurve.Evaluate(speedRatio);

        speed *= decelaration;

        //gas
        var y = rb.velocity.y;
        rb.velocity = transform.forward * speed;
        rb.velocity = new Vector3(rb.velocity.x, y, rb.velocity.z);

        fakeSpeed = speed * 10;
        speedNumber.SetText(fakeSpeed.ToString());
    }

    public void Turn(float side)
    {
        rb.angularVelocity = new Vector3(0, side * turnSpeed * Mathf.Deg2Rad,0);
    }
}