using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Time : MonoBehaviour
{
    public Text timeText;
    private float timer = 0f;
    private int secondTimer = 0;
    private bool isPlaying = true;

    public void OffTimer()
    {
        isPlaying = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;
            if(Mathf.Floor(timer) > secondTimer)
            {
                secondTimer += 1;
                timeText.text = "버틴 시간 : " + secondTimer + "초";
            }
        }
    }
}
