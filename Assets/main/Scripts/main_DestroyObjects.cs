using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class main_DestroyObjects : MonoBehaviour
{
    /*private void Start()
    {
        Destroy(gameObject, 3.0f);
    }
    */
    [SerializeField] float destroyTime = 3.0f;
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
