using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*public class main_PCon : MonoBehaviour
{
    [SerializeField] float speed = 0.4f;
    [SerializeField] float rightSpeed = 0.13f;
    [SerializeField] float leftSpeed = -0.13f;
    [SerializeField] float jumpPower = 6.5f;
    [SerializeField] float moveStopTime = 1;
    private bool isJumping;
    [SerializeField] string goalSceneName;
    Rigidbody rb;

    private int hitCount = 0;

    public Generator[] generete;

    //�ǉ��i����j
    public AudioClip A_SE;
    AudioSource aud;

    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"right", false },
        {"left", false },
    };

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = true;

        //�ǉ��i����j
        this.aud = GetComponent<AudioSource>();

    }
    private void Update()
    {
        move["right"] = Input.GetKey(KeyCode.D);
        move["left"] = Input.GetKey(KeyCode.A);

        if (Input.GetKeyDown(KeyCode.Space) && isJumping) Jump();
    }

    private void FixedUpdate()
    {
        if (move["right"]) transform.Translate(rightSpeed, 0, 0);
        if (move["left"]) transform.Translate(leftSpeed, 0, 0);
        transform.position += Vector3.forward * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        hitCount++;
        Debug.Log(hitCount);

        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }

        if(collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(Stop());

            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Goal"))
        {
            Goal();
        }
    }

    private void Jump()
    {
        isJumping = false;
        rb.velocity = new Vector3(0, jumpPower, 0);
    }

    IEnumerator Stop()
    {
       for(int i = 0;i < generete.Length; i++) generete[i].GenerateStop();

        speed = 0.0f;

        Debug.Log("�~�܂���");

        //�ǉ��i����j
        this.aud.PlayOneShot(this.A_SE);

        yield return new WaitForSeconds(moveStopTime);

        for (int i = 0; i < generete.Length; i++) generete[i].GenerateStart();

        speed = 0.4f;
    }

    private void Goal()
    {
        //�V�[�����ύX�i����j
        SceneManager.LoadScene("main_EndScene");
    }
}*/


/*
public class main_PCon : MonoBehaviour
{
    [SerializeField] float speed = 0.4f; //�v���C���[�̖ڂɐi�ޑ��x
    [SerializeField] float rightSpeed = 0.13f; //�E�Ɉړ����鑬�x
    [SerializeField] float leftSpeed = -0.13f; //���Ɉړ����鑬�x
    [SerializeField] float jumpPower = 6.5f; //�W�����v�̍���
    [SerializeField] float moveStopTime = 1; //�I�u�W�F�N�g�ɏՓ˂����Ƃ��v���C���[���~�܂�b��
    [SerializeField] float startTime = 3.0f; //�X�^�[�g���̃J�E���g�_�E��
    private bool isJumping; //�����W�����v�h�~�̕ϐ�
    [SerializeField] string goalSceneName; //�S�[���V�[���̖��O�A�g��Ȃ��Ă��悢
    Rigidbody rb; //Rigidbody���i�[����ϐ�

    //�ǉ��i����j
    public AudioClip A_SE;
    AudioSource aud;

    private int hitCount = 0;
    private bool moveStart = false; //�X�^�[�g���v���C���[�𓮂��Ȃ�����ϐ�

    public Generator[] generete; //�I�u�W�F�N�g�𐶐�����Generator���i�[����z��

    //���͂����L�[���擾����ϐ�
    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"right", false },
        {"left", false },
    };

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //Rigidbody���擾
        isJumping = true; //�ŏ��̓W�����v�ł���悤�ɂ���

        //CountDown���J�n����
        StartCoroutine(CountDown());

        //�ǉ��i����j
        this.aud = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //���͂��ꂽ�L�[���擾
        move["right"] = Input.GetKey(KeyCode.D);
        move["left"] = Input.GetKey(KeyCode.A);

        //�X�y�[�X�L�[���擾���W�����v����B�󒆃W�����v�͂ł��Ȃ�
        if (Input.GetKeyDown(KeyCode.Space) && isJumping) Jump();
    }

    private void FixedUpdate()
    {
        //���͂��ꂽ�L�[�ɉ����ăv���C���[���ړ�
        if (moveStart)
        {
            if (move["right"]) transform.Translate(rightSpeed, 0, 0); //���xrightSpeed�ŉE�Ɉړ�
            if (move["left"]) transform.Translate(leftSpeed, 0, 0); //���xleftSpeed�ō��Ɉړ�

            //�v���C���[�������I�ɑO�ɐi��
            transform.position += Vector3.forward * speed;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //�����蔻��̉񐔂�\��(�f�o�b�O�p)
        hitCount++;
        Debug.Log(hitCount);

        //�n�ʂ�Ground�̃^�O������ƃW�����v�ł���
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }

        //���ł���I�u�W�F�N�g��Obstacle�̃^�O�������Stop()���Ă΂��B�Փ˂����I�u�W�F�N�g��������
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(Stop());

            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Goal�^�O���t���Ă���R���C�_�[�ɐG����Goal()���Ă΂��
        if (other.CompareTag("Goal"))
        {
            Goal();
        }
    }

    //�W�����v
    private void Jump()
    {
        isJumping = false;
        rb.velocity = new Vector3(0, jumpPower, 0);
    }

    //�v���C���[��moveStopTime�b�~�߂�
    IEnumerator Stop()
    {
        for (int i = 0; i < generete.Length; i++) generete[i].GenerateStop();

        speed = 0.0f;

        //�ǉ��i����j
        this.aud.PlayOneShot(this.A_SE);

        Debug.Log("�~�܂���");

        yield return new WaitForSeconds(moveStopTime);

        for (int i = 0; i < generete.Length; i++) generete[i].GenerateStart();

        speed = 0.4f;
    }

    //�S�[���V�[���ɑJ��
    private void Goal()
    {
        //�V�[�����ύX�i����j
        Debug.Log("main_EndScene");
        SceneManager.LoadScene(goalSceneName);
    }

    //�ŏ��̃J�E���g�_�E��
    IEnumerator CountDown()
    {
        moveStart = false;

        yield return new WaitForSeconds(startTime);

        moveStart = true;
    }

}
*/

/*
public class main_PCon : MonoBehaviour
{
    [SerializeField] float speed = 0.4f; //�v���C���[�̖ڂɐi�ޑ��x
    [SerializeField] float rightSpeed = 0.13f; //�E�Ɉړ����鑬�x
    [SerializeField] float leftSpeed = -0.13f; //���Ɉړ����鑬�x
    [SerializeField] float jumpPower = 6.5f; //�W�����v�̍���
    [SerializeField] float moveStopTime = 1; //�I�u�W�F�N�g�ɏՓ˂����Ƃ��v���C���[���~�܂�b��
    [SerializeField] float startTime = 3.0f; //�X�^�[�g���̃J�E���g�_�E��
    private bool isJumping; //�����W�����v�h�~�̕ϐ�
    [SerializeField] GameObject speedEffect; //SpeedEffect������
    [SerializeField] string goalSceneName; //�S�[���V�[���̖��O�A�g��Ȃ��Ă��悢
    Rigidbody rb; //Rigidbody���i�[����ϐ�

    private int hitCount = 0;
    private bool moveStart = false; //�X�^�[�g���v���C���[�𓮂��Ȃ�����ϐ�

    public main_Generator[] generete; //�I�u�W�F�N�g�𐶐�����Generator���i�[����z��

    //���͂����L�[���擾����ϐ�
    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"right", false },
        {"left", false },
    };

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //Rigidbody���擾
        isJumping = true; //�ŏ��̓W�����v�ł���悤�ɂ���

        speedEffect.SetActive(false); //SpeedEffect�͍ŏ��\�����Ȃ�

        //CountDown���J�n����
        StartCoroutine(CountDown());
    }
    private void Update()
    {
        //���͂��ꂽ�L�[���擾
        move["right"] = Input.GetKey(KeyCode.D);
        move["left"] = Input.GetKey(KeyCode.A);

        //�X�y�[�X�L�[���擾���W�����v����B�󒆃W�����v�͂ł��Ȃ�
        if (Input.GetKeyDown(KeyCode.Space) && isJumping) Jump();
    }

    private void FixedUpdate()
    {
        //���͂��ꂽ�L�[�ɉ����ăv���C���[���ړ�
        if (moveStart)
        {
            if (move["right"]) transform.Translate(rightSpeed, 0, 0); //���xrightSpeed�ŉE�Ɉړ�
            if (move["left"]) transform.Translate(leftSpeed, 0, 0); //���xleftSpeed�ō��Ɉړ�

            //�v���C���[�������I�ɑO�ɐi��
            transform.position += Vector3.forward * speed;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //�����蔻��̉񐔂�\��(�f�o�b�O�p)
        hitCount++;
        Debug.Log(hitCount);

        //�n�ʂ�Ground�̃^�O������ƃW�����v�ł���
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }

        //���ł���I�u�W�F�N�g��Obstacle�̃^�O�������Stop()���Ă΂��B�Փ˂����I�u�W�F�N�g��������
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(Stop());

            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Goal�^�O���t���Ă���R���C�_�[�ɐG����Goal()���Ă΂��
        if (other.CompareTag("Goal"))
        {
            Goal();
        }
    }

    //�W�����v
    private void Jump()
    {
        isJumping = false;
        rb.velocity = new Vector3(0, jumpPower, 0);
    }

    //�v���C���[��moveStopTime�b�~�߂�
    IEnumerator Stop()
    {
        for (int i = 0; i < generete.Length; i++) generete[i].GenerateStop();

        speed = 0.0f;

        speedEffect.SetActive(false);

        Debug.Log("�~�܂���");

        yield return new WaitForSeconds(moveStopTime);

        for (int i = 0; i < generete.Length; i++) generete[i].GenerateStart();

        speed = 0.4f;

        speedEffect.SetActive(true);
    }

    //�S�[���V�[���ɑJ��
    private void Goal()
    {
        Debug.Log("Goal");
        //SceneManager.LoadScene(goalSceneName);
    }

    //�ŏ��̃J�E���g�_�E��
    IEnumerator CountDown()
    {
        moveStart = false;

        yield return new WaitForSeconds(startTime);

        moveStart = true;

        speedEffect.SetActive(true); //�J�E���g�_�E���I����SpeedEffect��\��
    }

}
*/


public class main_PCon : MonoBehaviour
{
    [SerializeField] float speed = 0.4f; //�v���C���[�̖ڂɐi�ޑ��x
    [SerializeField] float rightSpeed = 0.13f; //�E�Ɉړ����鑬�x
    [SerializeField] float leftSpeed = -0.13f; //���Ɉړ����鑬�x
    [SerializeField] float jumpPower = 6.5f; //�W�����v�̍���
    [SerializeField] float moveStopTime = 1; //�I�u�W�F�N�g�ɏՓ˂����Ƃ��v���C���[���~�܂�b��
    [SerializeField] float startTime = 3.0f; //�X�^�[�g���̃J�E���g�_�E��
    private bool isJumping; //�����W�����v�h�~�̕ϐ�
    [SerializeField] GameObject speedEffect; //SpeedEffect������
    [SerializeField] string goalSceneName; //�S�[���V�[���̖��O�A�g��Ȃ��Ă��悢
    Rigidbody rb; //Rigidbody���i�[����ϐ�

    private int hitCount = 0;
    private bool moveStart = false; //�X�^�[�g���v���C���[�𓮂��Ȃ�����ϐ�

    public main_Generator[] generete; //�I�u�W�F�N�g�𐶐�����Generator���i�[����z��
    public main_RollingGenerator[] rollingGenerate;


    //���͂����L�[���擾����ϐ�
    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"right", false },
        {"left", false },
    };

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //Rigidbody���擾
        isJumping = true; //�ŏ��̓W�����v�ł���悤�ɂ���

        speedEffect.SetActive(false); //SpeedEffect�͍ŏ��\�����Ȃ�

        //CountDown���J�n����
        StartCoroutine(CountDown());
    }
    private void Update()
    {
        //���͂��ꂽ�L�[���擾
        move["right"] = Input.GetKey(KeyCode.D);
        move["left"] = Input.GetKey(KeyCode.A);

        //�X�y�[�X�L�[���擾���W�����v����B�󒆃W�����v�͂ł��Ȃ�
        if (Input.GetKeyDown(KeyCode.Space) && isJumping) Jump();
    }

    private void FixedUpdate()
    {
        //���͂��ꂽ�L�[�ɉ����ăv���C���[���ړ�
        if (moveStart)
        {
            if (move["right"]) transform.Translate(rightSpeed, 0, 0); //���xrightSpeed�ŉE�Ɉړ�
            if (move["left"]) transform.Translate(leftSpeed, 0, 0); //���xleftSpeed�ō��Ɉړ�

            //�v���C���[�������I�ɑO�ɐi��
            transform.position += Vector3.forward * speed;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //�����蔻��̉񐔂�\��(�f�o�b�O�p)
        hitCount++;
        Debug.Log(hitCount);

        //�n�ʂ�Ground�̃^�O������ƃW�����v�ł���
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }

        //���ł���I�u�W�F�N�g��Obstacle�̃^�O�������Stop()���Ă΂��B�Փ˂����I�u�W�F�N�g��������
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(Stop());

            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Goal�^�O���t���Ă���R���C�_�[�ɐG����Goal()���Ă΂��
        if (other.CompareTag("Goal"))
        {
            Goal();
        }
    }

    //�W�����v
    private void Jump()
    {
        isJumping = false;
        rb.velocity = new Vector3(0, jumpPower, 0);
    }

    //�v���C���[��moveStopTime�b�~�߂�
    IEnumerator Stop()
    {
        for (int i = 0; i < generete.Length; i++) generete[i].GenerateStop();
        for (int i = 0; i < rollingGenerate.Length; i++) rollingGenerate[i].GenerateStop();




        speed = 0.0f;

        speedEffect.SetActive(false);

        Debug.Log("�~�܂���");

        yield return new WaitForSeconds(moveStopTime);

        for (int i = 0; i < generete.Length; i++) generete[i].GenerateStart();
        for (int i = 0; i < rollingGenerate.Length; i++) rollingGenerate[i].GenerateStart();

        speed = 0.4f;

        speedEffect.SetActive(true);
    }

    //�S�[���V�[���ɑJ��
    private void Goal()
    {
        Debug.Log("Goal");
        //SceneManager.LoadScene(goalSceneName);
    }

    //�ŏ��̃J�E���g�_�E��
    IEnumerator CountDown()
    {
        moveStart = false;

        yield return new WaitForSeconds(startTime);

        moveStart = true;

        speedEffect.SetActive(true); //�J�E���g�_�E���I����SpeedEffect��\��
    }

}
