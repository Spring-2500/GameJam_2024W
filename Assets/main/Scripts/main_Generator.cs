using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_Generator : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    [Header("�I�u�W�F�N�g�����Ɋւ��邱��")]
    [SerializeField] float interval = 1.0f;
    [SerializeField] float xAngle;
    [SerializeField] float yAngle;
    [SerializeField] float zAngle;
    [SerializeField] float speed;
    [SerializeField] bool randomAngle;
    [SerializeField] bool randomSpeed;

    [Header("�I�u�W�F�N�g�̉�]")]
    [SerializeField] float xRotation;
    [SerializeField] float yRotation;
    [SerializeField] float zRotation;

    Rigidbody rb;

    private int obj;
    private bool createObj = true;
    IEnumerator enumerator = null;

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

                if (randomAngle) yAngle = Random.Range(-8.0f, 8.0f);

                Quaternion angle = Quaternion.Euler(xAngle, yAngle, zAngle);

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

        if(randomSpeed) speed = Random.Range(-23, -25);

        o.GetComponent<Rigidbody>().AddForce(o.transform.forward * speed, ForceMode.Impulse);

        o.GetComponent<Rigidbody>().AddTorque(new Vector3(xRotation, yRotation, zRotation));

    }

   public void GenerateStop()
   {
        createObj = false;
        Debug.Log("�W�F�l���[�^�[���~�܂���");
   }

    public void GenerateStart()
    {
        createObj = true;
        Debug.Log("�W�F�l���[�^�[���ĊJ����");
    }

}
