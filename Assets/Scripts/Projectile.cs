using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public bool destroyed = false;
    public ExplosionFX explosionFX;
    private GameObject playerGameObject;
    private Player player;

    public new BoxCollider2D collider { get; private set; }


    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        player = FindObjectOfType<Player>();
    }

    private void Hit()
    {
        Instantiate(explosionFX, transform.position, new Quaternion(0,0,180,0));
        Destroy(gameObject);
        destroyed = true;
    }
    
    private void HitNoFX()
    {
        Destroy(gameObject);
        destroyed = true;
    }

   
    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Hit();
        }
        else if (other.CompareTag("Bunker"))
        {
            Hit();
        }
        else if (other.gameObject.CompareTag("Invader"))
        {
            HitNoFX();
            player.scoreInt += 10;
        }
        else if (other.gameObject.CompareTag("Invader2"))
        {
            HitNoFX();
            player.scoreInt += 20;
        }
        else if (other.gameObject.CompareTag("Invader3"))
        {
            HitNoFX();
            player.scoreInt += 30;
        }
        else if (other.gameObject.CompareTag("Invader4"))
        {
            HitNoFX();
            player.scoreInt += 100;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            Hit();
        }
        else if (col.gameObject.CompareTag("Bunker"))
        {
            Hit();
        }
        else if (col.gameObject.CompareTag("Invader"))
        {
            Hit();
        }
    }
}
    

