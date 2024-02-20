using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_PCon : MonoBehaviour
{
    [SerializeField] float speed = 0.4f;
    [SerializeField] float rightSpeed = 0.13f;
    [SerializeField] float leftSpeed = -0.13f;
    [SerializeField] float jumpPower = 6.5f;
    [SerializeField] float moveStopTime = 1;
    private bool isJumping;
    [SerializeField] string goalSceneName;
    Rigidbody rb;

    private int hitCount = 0;

    public Generator[] generete;

    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"right", false },
        {"left", false },
    };

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = true;
    }
    private void Update()
    {
        move["right"] = Input.GetKey(KeyCode.D);
        move["left"] = Input.GetKey(KeyCode.A);

        if (Input.GetKeyDown(KeyCode.Space) && isJumping) Jump();
    }

    private void FixedUpdate()
    {
        if (move["right"]) transform.Translate(rightSpeed, 0, 0);
        if (move["left"]) transform.Translate(leftSpeed, 0, 0);
        transform.position += Vector3.forward * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        hitCount++;
        Debug.Log(hitCount);

        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }

        if(collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(Stop());

            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Goal"))
        {
            Goal();
        }
    }

    private void Jump()
    {
        isJumping = false;
        rb.velocity = new Vector3(0, jumpPower, 0);
    }

    IEnumerator Stop()
    {
       for(int i = 0;i < generete.Length; i++) generete[i].GenerateStop();

        speed = 0.0f;

        Debug.Log("Ž~‚Ü‚Á‚½");

        yield return new WaitForSeconds(moveStopTime);

        for (int i = 0; i < generete.Length; i++) generete[i].GenerateStart();

        speed = 0.4f;
    }

    private void Goal()
    {
        SceneManager.LoadScene(goalSceneName);
    }
}
