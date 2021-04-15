using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalPoint; 
    public int stagePoint;
    public int stageIndex;
    public int health = 3;
    public Player player;
    public GameObject[] stages;

    public Image[] UIhealth;
    public Text UIPoint;
    public Text UIStage;
    public GameObject UIRestarBtn;

    void Update()
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }

    // Start is called before the first frame update
    public void NextStage()
    {
        if((stageIndex < stages.Length -1))
        {
            stages[stageIndex].SetActive(false);
            stageIndex++;
            stages[stageIndex].SetActive(true);
            PlayerReposition();

            UIStage.text = "STAGE" + (stageIndex + 1); 
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log("게임클리어");
            UIRestarBtn.SetActive(true);
        }
        totalPoint += stagePoint;
        stagePoint = 0;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    /*
    public void HealthDown()
    {
        if(health > 0)
        {
            health--;
        }
        else
        {
            player.OnDie();
        }
    }
    */

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("asd");
        if (collision.gameObject.tag == "Player")
        {
            health--;

            collision.attachedRigidbody.velocity = Vector2.zero;
            collision.transform.position = new Vector3(-19, -1, -1);
        }
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(-19, -1, -1);
        player.VelocityZero();
    }

}
