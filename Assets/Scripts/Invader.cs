using System;
using Unity.Mathematics;
using UnityEngine;

public class Invader : MonoBehaviour
{
    private bool goingLeft = false;
    public InvaderExplosionFX explosionFX;
    public GameObject invadersGameObject;
    public InvadersController controller;

    
    private void Hit()
    {
        Instantiate(explosionFX, transform.position, quaternion.identity, invadersGameObject.transform);
        controller.speed += 0.025f;
        controller.InvadersLeft--;
        Destroy(gameObject);
    }
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser")) {
            Hit();
        }
        else if (other.CompareTag("Bunker"))
        {
            other.gameObject.SetActive(false);
            Hit();
        }
        else if (other.CompareTag("BorderLeft"))
        {
            controller.goingLeft = false;
            controller.goingDown = true;
        }
        else if (other.CompareTag("BorderRight"))
        {
            controller.goingLeft = true;
            controller.goingDown = true;
        }
        
    }

}
