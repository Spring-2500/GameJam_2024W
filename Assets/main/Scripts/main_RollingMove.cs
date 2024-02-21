using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//転がってくるオブジェクトにつける
public class main_RollingMove : MonoBehaviour
{
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;

    private void FixedUpdate()
    {

        float speed = Random.Range(minSpeed, maxSpeed);
        transform.position += Vector3.back * speed;
    }
}
