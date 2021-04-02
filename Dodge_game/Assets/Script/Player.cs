using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp = 3;

    public int GetHP(){
        return hp;
    }

    public void SetHP(int HP){
        this.hp = hp;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp > 0)
        {
            float posX = 0, posY = 0;
            /*
            if (Input.GetKey(KeyCode.A))
            {
                posX -= 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                posX += 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                posY += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                posY -= 1;
            }
            */
            posX = Input.GetAxis("Horizontal");
            posY = Input.GetAxis("Vertical");

            Vector3 pos = gameObject.transform.position;
            pos.x += posX * Time.deltaTime * 5;
            pos.y += posY * Time.deltaTime * 5;

            if (pos.x < -8.3f)
            {
                pos.x = -8.3f;
            }
            else if (pos.x > 8.3f)
            {
                pos.x = 8.3f;
            } 
            if (pos.y < -4.7f)
            {
                pos.y = -4.7f;
            }
            else if (pos.y > 4.7f)
            {
                pos.y = 4.7f;
            }

            gameObject.transform.position = pos;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            hp -= 1;
            print(hp);
        }
    }

}
