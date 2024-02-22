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
    [SerializeField] float startTime = 3.0f; //スクリプトエラーが怖いのでインスペクター編集に変更しました

    [Header("オブジェクトが壁の外に出現したときの処理")]
    [SerializeField] float wallPosLeft; //左の壁のx座標 + 1.0ぐらいをを入力
    [SerializeField] float wallPosRight; //右の壁のx座標 + 1,0ぐらいを入力

    [Header("オブジェクトの回転")]
    [SerializeField] float xRotation;
    [SerializeField] float yRotation;
    [SerializeField] float zRotation;

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
        yield return new WaitForSeconds(startTime); // この秒数はPConのstartTimeに合わせる。多分3.0秒後にゲームスタートでいいはず
                                               //カウントダウンタイマーは後で作成

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
                    //壁の外に生成されたオブジェクトをある程度削除する
                    OutsideWall(o);
                }
                else
                {
                    //オブジェクトを飛ばす
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
        Debug.Log("ジェネレーターが止まった");
   }

    public void GenerateStart()
    {
        createObj = true;
        Debug.Log("ジェネレーターが再開した");
    }


    private void OnTriggerEnter(Collider other)
    {
        //ゴール前のオブジェクトの生成をやめる
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
