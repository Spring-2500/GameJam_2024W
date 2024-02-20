using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] float interval = 1.0f;
    [SerializeField] float xAngle;
    [SerializeField] float yAngle;
    [SerializeField] float zAngle;
    [SerializeField] bool random;

    private int obj;
    

    private void Start()
    {
        StartCoroutine(GenerateObject());
    }

    IEnumerator GenerateObject()
    {
        while (true)
        {
            obj = Random.Range(0, objects.Length);

            Quaternion angle = Quaternion.Euler(xAngle, yAngle, zAngle);

            if(random) yAngle = Random.Range(-8.0f, 8.0f);

            Instantiate(objects[obj], transform.position, angle);

            yield return new WaitForSeconds(interval);
        }
    }

}
