using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int speed = 5;
    private int seasonAttribute;
    private float TimeToLive = 0;
    public int damage = 0;

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
        this.GetComponent<Rigidbody2D>().velocity = (this.transform.up * speed);

        TimeToLive += Time.deltaTime;
        if (TimeToLive >= 1.8f)
            //gameObject.SetActive(false);
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            //BIG CHANGE HERE
            //int enemyHealth = collider.GetComponent<Enemy>().Health--;
            collider.GetComponent<Enemy>().Health -= damage;
            collider.GetComponent<Enemy>().GetComponentInChildren<EnemyHealth>().DecreaseHealth(damage);
            int enemyHealth = collider.GetComponent<Enemy>().Health;
            if (seasonAttribute == 3)
            {
                //Debug.Log("slowed");
                collider.GetComponent<Enemy>().SetSlow();
            }
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

    public void SetDamage(int dmg)
    {
        damage = dmg;
    }
    public void SetSeasonAttribute(int attr)
    {
        seasonAttribute = attr;
    }
}
