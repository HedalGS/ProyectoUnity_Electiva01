using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerometer : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.acceleration;

        // Actualizar los ejes para que coincidan con la orientacion del dispositivo
        tilt = Quaternion.Euler(90, 0, 0) * tilt;

        // Mover el objeto
        rb.AddForce(tilt * speed);
    }
}
