using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�]�����Ă���I�u�W�F�N�g�ɂ���
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
