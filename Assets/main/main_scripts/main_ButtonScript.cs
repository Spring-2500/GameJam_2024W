using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickA()
    {
        SceneManager.LoadScene("main_Morita01");
    }

    public void OnClickB()
    {
        SceneManager.LoadScene("main_start");
    }
}
