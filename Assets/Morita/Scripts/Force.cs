using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Force : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody rb;

    [SerializeField] bool random;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if(random) speed = Random.Range(-45, -40);


        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

}
