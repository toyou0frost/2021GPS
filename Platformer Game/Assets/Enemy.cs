using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    bool isDie = false;
    float dieTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie)
        {
            dieTimer += Time.deltaTime;
            if (dieTimer >= 2.1)
            {
                Sound.instance.HitSound();
                Destroy(gameObject);
            }
        }
    }

    public void Die()
    {
        anim.SetBool("isDie", true);
        isDie = true;
    }
}
