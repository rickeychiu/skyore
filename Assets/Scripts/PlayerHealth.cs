using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float maxInvTime;
    public float invTime;
    public SpriteRenderer sprite;
    public float colorChangeTime, invDelay;
    public float transparency;
    public int maxHealth;
    public int currentHealth;
    public Sprite dead;
    public float yOffset;
    public bool isDead;

    public Sprite[] hearts;
    public Image heartsIcon;

    public GameObject curtain;
    public ParticleSystem ps;
    public AudioManager am;

    void Start()
    {
        isDead = false;
        currentHealth = maxHealth;
    }

    void Update() 
    {
        if (invTime > 0) 
        {
            invTime -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        am.PlaySound(am.sfx[3]);
        CheckDead();

    }

    public void CheckDead() 
    {
        if (currentHealth <= 0 && !isDead) 
        {
            Death();
        }
        else if (!isDead) {
            invTime = maxInvTime;
            StartCoroutine(TakeDamageEffect());
            StartCoroutine(InvinicibilityTime());
            heartsIcon.sprite = hearts[currentHealth];
        }
    }

    public void Death()
    {
        isDead = true;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = dead;
        GameObject.Find("Main Camera").GetComponent<CameraMove>().speed = 0;
        heartsIcon.sprite = hearts[0];
        StartCoroutine(ReloadDelay());
        gameObject.GetComponent<PlayerDiamonds>().SaveDiamonds();
        ps.Play();
        am.PlaySound(am.sfx[2]);
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && (invTime <= 0))
        {
            TakeDamage(collision.gameObject.GetComponent<EnemyInfo>().PlayerDamage);
        }    
        else if (collision.gameObject.CompareTag("MainCamera") && !isDead)
        {
            Death();
        }
    }

    IEnumerator TakeDamageEffect()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(colorChangeTime);
        sprite.color = Color.white;
    }

    IEnumerator InvinicibilityTime()
    {
        while (invTime > 0) 
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, transparency);
            yield return new WaitForSeconds(invDelay);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
             yield return new WaitForSeconds(invDelay);
        }
       
    }

    IEnumerator ReloadDelay()
    {
        
        yield return new WaitForSeconds(2);
        curtain.SetActive(true);
        curtain.GetComponent<CurtainScript>().FadeTo();
    }
}
