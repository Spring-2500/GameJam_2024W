using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main_TimerController : MonoBehaviour
{
    public Text Timetext;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        Timetext.text = time.ToString("F1");
    }
}
