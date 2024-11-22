using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vehicle vehicle;
    public AudioSource engineSound;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            vehicle.Gas();
            engineSound.pitch = Random.Range(1f, 1.5f);

        }
        if(Input.GetKey(KeyCode.S)) vehicle.Brake();
        vehicle.Turn(Input.GetAxis("Horizontal"));
    }
}
