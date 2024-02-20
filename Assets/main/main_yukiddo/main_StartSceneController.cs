using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start()
    {
        //以下変更点
        //SceneManager.LoadScene("Test");
        SceneManager.LoadScene("main_Morita01");//移動するシーンの変更
    }
}
