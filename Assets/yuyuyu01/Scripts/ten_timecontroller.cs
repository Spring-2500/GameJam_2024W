using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ten_timecontroller : MonoBehaviour
{

    public Text Start_text;
    float start_time;
    [SerializeField] float start_time_minutu = 3f;

    // Start is called before the first frame update
    void Start()
    {
        start_time = start_time_minutu;
    }

    // Update is called once per frame
    void Update()
    {
        if(start_time >= 0)
        {
            start_time -= Time.deltaTime;
            Start_text.text = start_time.ToString("F1");
        }
        if(start_time < 0)
        {
            Destroy(Start_text);
        }
    }
}
