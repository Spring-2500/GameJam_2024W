using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obuject")//�^�O(object)�����Ă�I�u�W�F�N�g�ɐG�ꂽ�Ƃ��ɑ��x�O
        {
             rb.velocity = Vector3.zero;
        }
    }
}