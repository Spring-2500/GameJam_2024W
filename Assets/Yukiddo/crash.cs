using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private Vector3 accelaration;//�����x
    float MaxSpeed = 100;
    float Speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed = rb.velocity.magnitude;
        if(Speed< MaxSpeed)
        {
            rb.AddForce(accelaration, ForceMode.Acceleration);
        }
        Debug.Log(Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "object")//�^�O(object)�����Ă�I�u�W�F�N�g�ɐG�ꂽ�Ƃ��ɑ��x�O
        {
             rb.velocity = Vector3.zero;
        }
    }
}