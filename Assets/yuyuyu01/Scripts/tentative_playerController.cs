using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentative_playerController : MonoBehaviour
{
    public AudioClip A_SE;
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "tentative_object")
        {
            this.aud.PlayOneShot(this.A_SE);
            Debug.Log("オブジェクトに当たった");
        }
    }
}
