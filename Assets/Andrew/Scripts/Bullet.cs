using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private int speed = 1;
    private float TimeToLive = 0;
    private AudioSource audioSource;
    public AudioClip[] bugHitSounds; 

    public AudioClip[] bugDeathSounds; //CHANGE HERE
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
            //BIG CHANGE HERE
            int enemyHealth = collider.GetComponent<Enemy>().Health--;
            if (enemyHealth > 0)
            {
                audioSource.clip = bugHitSounds[Random.Range(0, bugHitSounds.Length - 1)];
                audioSource.Play();
            }
            else
            {
                audioSource.clip = bugDeathSounds[Random.Range(0, bugDeathSounds.Length - 1)];
                audioSource.Play(); 
            }
            Destroy(this.gameObject);
        }
    }
}
