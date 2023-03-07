using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    public Projectile laserPrefab;
    private Projectile laser;
    public int scoreInt;
    public TMP_Text score;
    public int highScoreInt;
    public TMP_Text highScore;
    public int invadersLeft = 45;
    private bool gameOver = false;
    public UIManager UIManager;

    public bool GameOver
    {
        get => gameOver;
        set => gameOver = value;
    }

    public int InvadersLeft
    {
        get => invadersLeft;
        set => invadersLeft = value;
    }
    public bool laserActive { get; set; }

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScorePersistent"))
        {
            highScoreInt = PlayerPrefs.GetInt("HighScorePersistent");
            print(highScoreInt + "highScore");
        }
    }

    private void Update()
    {
        if (invadersLeft <= 0)
        {
            GameOverWin();
        }
        score.text = String.Format("{0:0000}", scoreInt);  
        highScore.text = String.Format("{0:0000}", highScoreInt);  
        Vector3 position = transform.position;
        if (UIManager.HasGameStarted)
        {

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                position.x -= speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                position.x += speed * Time.deltaTime;
            }

            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
            position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);
            transform.position = position;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
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

    private void GameOverWin()
    {
        if (scoreInt > highScoreInt)
        {
            highScoreInt = scoreInt;
            PlayerPrefs.SetInt("HighScorePersistent", highScoreInt);
        }

        UIManager.HasGameStarted = false;
        gameOver = true;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void GameOverLose()
    {
        if (scoreInt > highScoreInt)
        {
            highScoreInt = scoreInt;
            PlayerPrefs.SetInt("HighScorePersistent", highScoreInt);
        }

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        UIManager.HasGameStarted = false;
        gameOver = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Missile" || other.CompareTag("Invader")|| other.CompareTag("Invader2")|| other.CompareTag("Invader3"))
        {
            GameOverLose();
        }
    }

}
