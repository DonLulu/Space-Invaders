using UnityEngine;

public class Missiles : MonoBehaviour
{
    public float speed = 3f;
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
        Instantiate(explosionFX, transform.position, new Quaternion(0,0,0,0));
        Destroy(gameObject);
    }
    
    private void HitNoFX()
    {
        Destroy(gameObject);
    }

   
    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BorderDown"))
        {
            Hit();
        }
        else if (other.CompareTag("Bunker"))
        {
            other.gameObject.SetActive(false);
            Hit();
        }
        else if (other.CompareTag("player"))
        {
            print("playerHit");
            HitNoFX();
            player.GameOverLose();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BorderDown"))
        {
            Hit();
        }
        else if (col.gameObject.CompareTag("Bunker"))
        {
            col.gameObject.SetActive(false);
            Hit();
        }
        else if (col.gameObject.CompareTag("Player"))
        {
            print("playerHit");
            HitNoFX();
            player.GameOverLose();
        }
    }
}