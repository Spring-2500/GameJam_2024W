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
        if (Input.GetKey(KeyCode.D))//右移動
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.A))//左移動
        {
            rb.velocity = -transform.right * speed;
        }
        if (Input.GetKeyDown(KeyCode.Space))//ジャンプ
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

    //タグ(ground)が設定されているオブジェクトに触れたときにジャンプ関数をfalse にしている
    private void OnCollisionEnter(Collision collision)      
    {
        if(collision.gameObject.tag == "ground")
        {
            jumping = false;
        }
    }
}