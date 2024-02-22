using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    [Header("�I�u�W�F�N�g�����Ɋւ��邱��")]
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
    [SerializeField] float startTime = 3.0f; //�X�N���v�g�G���[���|���̂ŃC���X�y�N�^�[�ҏW�ɕύX���܂���

    [Header("�I�u�W�F�N�g���ǂ̊O�ɏo�������Ƃ��̏���")]
    [SerializeField] float wallPosLeft; //���̕ǂ�x���W + 1.0���炢�������
    [SerializeField] float wallPosRight; //�E�̕ǂ�x���W + 1,0���炢�����

    [Header("�I�u�W�F�N�g�̉�]")]
    [SerializeField] float xRotation;
    [SerializeField] float yRotation;
    [SerializeField] float zRotation;

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
        yield return new WaitForSeconds(startTime); // ���̕b����PCon��startTime�ɍ��킹��B����3.0�b��ɃQ�[���X�^�[�g�ł����͂�
                                               //�J�E���g�_�E���^�C�}�[�͌�ō쐬

        while (true)
        {
            if (createObj)
            {
                yield return new WaitForSeconds(interval);

                obj = Random.Range(0, objects.Length);

                if (randomAngle) yAngle = Random.Range(minyAngle, maxyAngle);


                Quaternion angle = Quaternion.Euler(0, yAngle, zAngle);

                GameObject o = Instantiate(objects[obj], transform.position, angle);

                if (transform.position.x < wallPosLeft || transform.position.x > wallPosRight)
                {
                    //�ǂ̊O�ɐ������ꂽ�I�u�W�F�N�g��������x�폜����
                    OutsideWall(o);
                }
                else
                {
                    //�I�u�W�F�N�g���΂�
                    Force(o);
                }
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
        Debug.Log("�W�F�l���[�^�[���~�܂���");
   }

    public void GenerateStart()
    {
        createObj = true;
        Debug.Log("�W�F�l���[�^�[���ĊJ����");
    }


    private void OnTriggerEnter(Collider other)
    {
        //�S�[���O�̃I�u�W�F�N�g�̐�������߂�
        if(other.CompareTag("PreGoal"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OutsideWall(GameObject o)
    {
        Destroy(o);
    }
}
