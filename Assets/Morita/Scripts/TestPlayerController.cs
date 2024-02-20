using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A)) transform.Translate(-0.2f, 0, 0);

        if (Input.GetKey(KeyCode.D)) transform.Translate(0.2f, 0, 0);
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * speed;

    }
}
