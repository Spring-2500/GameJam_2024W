using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float speed = 10.0f;
    float jumpForce = 100.0f;
    bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))//�E�ړ�
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.A))//���ړ�
        {
            rb.velocity = -transform.right * speed;
        }
        if (Input.GetKeyDown(KeyCode.Space))//�W�����v
        {
            if(jumping == false)
            {
                Vector3 forceJ = new Vector3(0.0f,jumpForce,0.0f);
                rb.AddForce(forceJ,ForceMode.Force);
            }
            Debug.Log("space");
            jumping = true;
        }
    }

    //�^�O(ground)���ݒ肳��Ă���I�u�W�F�N�g�ɐG�ꂽ�Ƃ��ɃW�����v�֐���false �ɂ��Ă���
    private void OnCollisionEnter(Collision collision)      
    {
        if(collision.gameObject.tag == "ground")
        {
            jumping = false;
        }
    }
}