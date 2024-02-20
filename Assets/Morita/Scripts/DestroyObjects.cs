using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DestroyObjcts : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3.0f);
    }

}
