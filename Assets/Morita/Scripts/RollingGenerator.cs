using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    [Header("�I�u�W�F�N�g�����Ɋւ��邱��")]
    [SerializeField] float interval = 1.0f;
    [SerializeField] float xAngle;
    [SerializeField] float yAngle;
    [SerializeField] float zAngle;

    [Header("�I�u�W�F�N�g�̉�]")]
    [SerializeField] float xRotation;
    [SerializeField] float yRotation;
    [SerializeField] float zRotation;
    [SerializeField] float playerStartPosX;

    private int obj;
    private bool createObj = true;
    IEnumerator enumerator = null;

    [Header("�I�u�W�F�N�g���������Ȃ��i�e�X�g�p�j")]
    [SerializeField] bool testGeneretor = false;


    private void Start()
    {
        if (!testGeneretor)
        {
            enumerator = GenerateObject();
            StartCoroutine(enumerator);
        }

    }

    IEnumerator GenerateObject()
    {
        yield return new WaitForSeconds(3.0f); // ���̕b����PCon��startTime�ɍ��킹��B����3.0�b��ɃQ�[���X�^�[�g�ł����͂�
                                               //�J�E���g�_�E���^�C�}�[�͌�ō쐬

        while (true)
        {
            if (createObj)
            {
                yield return new WaitForSeconds(interval);


                GameObject o = Instantiate(objects[obj], new Vector3(playerStartPosX, transform.position.y, transform.position.z), Quaternion.Euler(xAngle, yAngle, zAngle));
           
                Rolling(o);
            }

            else
            {
                yield return null;
            }
        }
    }

    private void Rolling(GameObject o)
    {
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            StopCoroutine(enumerator);
        }
    }

}
