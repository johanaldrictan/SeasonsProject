using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private int speed = 1;
    private float TimeToLive = 0;
    private AudioSource audioSource;
    public AudioClip[] bugHitSounds;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //move bullet

        TimeToLive += Time.deltaTime;
        if (TimeToLive > 3f)
            //gameObject.SetActive(false);
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            audioSource.clip = bugHitSounds[Random.Range(0, bugHitSounds.Length - 1)];
            audioSource.Play();
            Destroy(this.gameObject);
            collider.GetComponent<Enemy>().Health--;
        }
    }
}
