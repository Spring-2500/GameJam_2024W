using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentative_objectManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -0.01f);
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("“–‚½‚Á‚½");
    }
}
