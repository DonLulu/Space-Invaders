using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InvadersController : MonoBehaviour
{
    public float speed = 1f;
    public bool goingLeft;
    public bool goingDown;
    private float amountDown = 0.3f;
    private int invadersLeft = 45;
    public UIManager UIManager;
    public Missiles missile;
    private bool launched = true;

    public int InvadersLeft
    {
        get => invadersLeft;
        set => invadersLeft = value;
    }
    public Player player;

    private void Start()
    {
    }

    private void Update()
    {
        if (UIManager.HasGameStarted && launched)
        {
            StartCoroutine(waiter());
            launched = false;
        }
        player.InvadersLeft = invadersLeft;
        if (UIManager.HasGameStarted)
        {
            if (goingDown)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - amountDown);
                goingDown = false;
            }

            if (goingLeft)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }

            if (!goingLeft)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }
        }

        

    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        MissileAttack();
        StartCoroutine(waiter());
    }

    private void MissileAttack()
    {
        foreach (Transform invader in transform)
        {
            if (Random.value > invadersLeft /100)
            {
                Instantiate(missile, invader.position, Quaternion.identity);
                break;
            }
        }
    }

}