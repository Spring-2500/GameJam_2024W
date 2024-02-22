using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main_resultScript : MonoBehaviour
{
    public Text Scoretext;
    float score;
    public Text Tikoku;
    public Text Clear;

    // Start is called before the first frame update
    void Start()
    {
        score = main_TimerController.send_time;
        Scoretext.text = score.ToString("F1");
        if(score >= 0)
        {
            Scoretext.enabled = true;
            Tikoku.enabled = false;
            Clear.enabled = true;
        }
        if (score < 0)
        {
            Scoretext.enabled = true;
            Tikoku.enabled = true;
            Clear.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
