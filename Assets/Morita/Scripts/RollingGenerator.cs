using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    [Header("オブジェクト生成に関すること")]
    [SerializeField] float interval = 1.0f;
    [SerializeField] float xAngle;
    [SerializeField] float yAngle;
    [SerializeField] float zAngle;

    [Header("オブジェクトの回転")]
    [SerializeField] float xRotation;
    [SerializeField] float yRotation;
    [SerializeField] float zRotation;
    [SerializeField] float playerStartPosX;

    private int obj;
    private bool createObj = true;
    IEnumerator enumerator = null;

    [Header("オブジェクト生成をしない（テスト用）")]
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
        yield return new WaitForSeconds(3.0f); // この秒数はPConのstartTimeに合わせる。多分3.0秒後にゲームスタートでいいはず
                                               //カウントダウンタイマーは後で作成

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
        Debug.Log("ジェネレーターが止まった");
    }

    public void GenerateStart()
    {
        createObj = true;
        Debug.Log("ジェネレーターが再開した");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            StopCoroutine(enumerator);
        }
    }

}
