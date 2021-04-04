using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Hp : MonoBehaviour
{
    private Text hpText;
    private int playerHP = 3;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        hpText = GetComponent<Text>();
        playerHP = player.GetHP();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP : " + player.GetHP();

        hpText.text = player.GetHP().ToString(); //둘 중 하나
        hpText.text = "Hp : " + player.GetHP(); //둘 중 하나
    }
}
