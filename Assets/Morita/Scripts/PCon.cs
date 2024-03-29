using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCon : MonoBehaviour
{
    [SerializeField] float speed = 0.4f; //プレイヤーの目に進む速度
    [SerializeField] float rightSpeed = 0.18f; //右に移動する速度
    [SerializeField] float leftSpeed = -0.18f; //左に移動する速度
    [SerializeField] float jumpPower = 6.5f; //ジャンプの高さ
    [SerializeField] float moveStopTime = 1; //オブジェクトに衝突したときプレイヤーが止まる秒数
    [SerializeField] float startTime = 3.0f; //スタート時のカウントダウン
    private bool isJumping; //無限ジャンプ防止の変数
    [SerializeField] GameObject speedEffect; //SpeedEffectを入れる
    [SerializeField] string goalSceneName; //ゴールシーンの名前、使わなくてもよい
    Rigidbody rb; //Rigidbodyを格納する変数

    private int hitCount = 0;
    private bool moveStart = false; //スタート時プレイヤーを動かなくする変数

    public Generator[] generete; //オブジェクトを生成するGeneratorを格納する配列
    public RollingGenerator[] rollingGenerate;


    //入力されるキーを取得する変数
    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"right", false },
        {"left", false },
    };

    private void Start()
    {
        //フレームレート固定
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        rb = GetComponent<Rigidbody>(); //Rigidbodyを取得
        isJumping = true; //最初はジャンプできるようにする

        speedEffect.SetActive(false); //SpeedEffectは最初表示しない

        //CountDownが開始する
        StartCoroutine(CountDown());
    }
    private void Update()
    {
        //入力されたキーを取得
         move["right"] = Input.GetKey(KeyCode.D);
         move["left"] = Input.GetKey(KeyCode.A);

       /* if (moveStart)
        {
            if (Input.GetKey(KeyCode.D)) transform.Translate(rightSpeed, 0, 0);

            if (Input.GetKey(KeyCode.A)) transform.Translate(leftSpeed, 0, 0);
        }*/
        
        //スペースキーを取得しジャンプする。空中ジャンプはできない
        if (Input.GetKeyDown(KeyCode.Space) && isJumping) Jump();
    }

    private void FixedUpdate()
    {
        //入力されたキーに応じてプレイヤーが移動
        if (moveStart)
        {
           if (move["right"]) transform.Translate(rightSpeed, 0, 0); //速度rightSpeedで右に移動
            if (move["left"]) transform.Translate(leftSpeed, 0, 0); //速度leftSpeedで左に移動

            //プレイヤーが自動的に前に進む
            transform.position += Vector3.forward * speed;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //当たり判定の回数を表示(デバッグ用)
        hitCount++;
        Debug.Log(hitCount);

        //地面にGroundのタグをつけるとジャンプできる
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }

        //飛んでくるオブジェクトにObstacleのタグをつけるとStop()が呼ばれる。衝突したオブジェクトが消える
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(Stop());

            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Goalタグが付いているコライダーに触れるとGoal()が呼ばれる
        if(other.CompareTag("Goal"))
        {
            Goal();
        }
    }

    //ジャンプ
    private void Jump()
    {
        isJumping = false;
        rb.velocity = new Vector3(0, jumpPower, 0);
    }

    //プレイヤーをmoveStopTime秒止める
    IEnumerator Stop()
    {
       for(int i = 0;i < generete.Length; i++) generete[i].GenerateStop();
       for (int i = 0; i < rollingGenerate.Length; i++) rollingGenerate[i].GenerateStop();
        

        

        speed = 0.0f;

        speedEffect.SetActive(false);

        Debug.Log("止まった");

        yield return new WaitForSeconds(moveStopTime);

        for (int i = 0; i < generete.Length; i++) generete[i].GenerateStart();
        for (int i = 0; i < rollingGenerate.Length; i++) rollingGenerate[i].GenerateStart();

        speed = 0.4f;

        speedEffect.SetActive(true);
    }

    //ゴールシーンに遷移
    private void Goal()
    {
        Debug.Log("Goal");
        //SceneManager.LoadScene(goalSceneName);
    }

    //最初のカウントダウン
    IEnumerator CountDown()
    {
        moveStart = false;

        yield return new WaitForSeconds(startTime);

        moveStart = true;

        speedEffect.SetActive(true); //カウントダウン終了後SpeedEffectを表示
    }

}
