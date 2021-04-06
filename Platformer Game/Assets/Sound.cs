using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance = null;

    private AudioSource audioSource;

    public AudioClip background;
    public AudioClip hitSound;
    public AudioClip attackSound;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = background;

        audioSource.volume = 1.0f;
        audioSource.loop = true;
        audioSource.mute = false;

        audioSource.Play();
    }

    public void AttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }

    public void HitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
