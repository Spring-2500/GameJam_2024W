using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    [Header("オブジェクト生成に関すること")]
    [SerializeField] float interval = 1.0f;
    [SerializeField] float yAngle;
    [SerializeField] float zAngle;
    [SerializeField] float speed;
    [SerializeField] bool randomAngle;
    [SerializeField] bool randomSpeed;
    [SerializeField] float minyAngle;
    [SerializeField] float maxyAngle;
    [SerializeField] int minSpeed;
    [SerializeField] int maxSpeed;

    [Header("オブジェクトの回転")]
    [SerializeField] float xRotation;
    [SerializeField] float yRotation;
    [SerializeField] float zRotation;

    Rigidbody rb;

    private int obj;
    private bool createObj = true;
    IEnumerator enumerator = null;

    [Header("オブジェクト生成をしない（テスト用）")]
    [SerializeField] bool testGeneretor;
    

    private void Start()
    {
        if (testGeneretor)
        {
            enumerator = GenerateObject();
            StartCoroutine(enumerator);
        }

    }

    IEnumerator GenerateObject()
    {
        while (true)
        {
            if (createObj)
            {
                yield return new WaitForSeconds(interval);

                obj = Random.Range(0, objects.Length);

                if (randomAngle) yAngle = Random.Range(minyAngle, maxyAngle);

                Quaternion angle = Quaternion.Euler(0, yAngle, zAngle);

                GameObject o = Instantiate(objects[obj], transform.position, angle);

                Force(o);
            }

            else
            {
                yield return null;
            }
        }
    }

    private void Force(GameObject o)
    {

        if(randomSpeed) speed = Random.Range(minSpeed, maxSpeed);

        o.GetComponent<Rigidbody>().AddForce(o.transform.forward * speed, ForceMode.Impulse);

        o.GetComponent<Rigidbody>().AddTorque(new Vector3(xRotation, yRotation, zRotation));

    }

   public void GenerateStop()
   {
        createObj = false;
        Debug.Log("ジェネレーターが止まった");
   }

    public void GenerateStart()
    {
        createObj = true;
        Debug.Log("ジェネレーターが再開した");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Goal"))
        {
            StopCoroutine(enumerator);
        }
    }
}
