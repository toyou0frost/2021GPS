using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private Player player;
    private EnemySpawner spawner;
    private UI_Time timer;

    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<UI_Time>();
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetHP() <= 0)
        {
            gameOverUI.SetActive(true);
            spawner.OffSpawner();
            timer.OffTimer();
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene"); //씬 이름을 지정해줘서
                                               //나중에 씬 변경 등에도 사용
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //현재 씬 자체를 가져와서 재 로딩하는 동작
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
