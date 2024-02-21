using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInstantiate : MonoBehaviour
{
    [SerializeField] GameObject o;

    private void Start()
    {
        for(int i = 0; i < 1000; i++)
        {
            Instantiate(o, new Vector3(5, 2, i * 10 - 500), Quaternion.identity);
        }
    }
}
