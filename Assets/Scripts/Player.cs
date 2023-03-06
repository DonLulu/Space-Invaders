using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    public Projectile laserPrefab;
    private Projectile laser;
    public int scoreInt;
    public TMP_Text score;
    public int highScoreInt;
    public TMP_Text highScore;
    
    public bool laserActive { get; set; }

    private void Update()
    {
        score.text = String.Format("{0:0000}", scoreInt);  
        highScore.text = String.Format("{0:0000}", highScoreInt);  
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            position.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            position.x += speed * Time.deltaTime;
        }
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x-0.5f);
        transform.position = position;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
        
        if (laserActive)
        {
            if (laser.destroyed)
            {
                laserActive = false;
            }
        }
    }

    private void Shoot()
    {
        if (!laserActive)
        {
            laserActive = true;
            laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        }
    }

    private void GameOver()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Missile" || other.CompareTag("Invader"))
        {
            GameOver();
        }
    }

}
