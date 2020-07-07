using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    Text ScoreText;
    float elapsedTime;
    bool stop;


    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
        ScoreText.text = "0";
        elapsedTime = 0;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop) {
            elapsedTime += Time.deltaTime;
            ScoreText.text = ((int)elapsedTime).ToString();
        }
        }

    public void stopTimer() {
        stop = true;
    }
}
