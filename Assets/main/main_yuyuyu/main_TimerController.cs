using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main_TimerController : MonoBehaviour
{
    public Text Timetext;
    float time;
    [SerializeField] float time_minutu = 60f;

    public Text Start_text;
    float start_time;
    [SerializeField] float start_time_minutu = 3f;

    // Start is called before the first frame update
    void Start()
    {
        start_time = start_time_minutu;
        time = time_minutu;
    }

    IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(start_time_minutu);

        time -= Time.deltaTime;
        Timetext.text = time.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        if (start_time >= 0)
        {
            start_time -= Time.deltaTime;
            Start_text.text = start_time.ToString("F1");
        }
        if (start_time < 0)
        {
            Destroy(Start_text);
        }

        time -= Time.deltaTime;
        Timetext.text = time.ToString("F1");
    }
}
