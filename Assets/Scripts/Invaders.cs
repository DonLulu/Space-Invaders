using UnityEngine;

public class Invaders : MonoBehaviour
{
    private float speed = 5f;
    //public GameObject missile;
    private bool GoingLeft;


    private void Start()
    {
    }

    /*private void MissileAttack()
    {
        int amountAlive = 1;

        // No missiles should spawn when no invaders are alive
        if (amountAlive == 0) {
            return;
        }

        foreach (Transform invader in transform)
        {
            // Any invaders that are killed cannot shoot missiles
            if (!invader.gameObject.activeInHierarchy) {
                continue;
            }

            // Random chance to spawn a missile based upon how many invaders are
            // alive (the more invaders alive the lower the chance)
            if (Random.value < (1f / (float)amountAlive))
            {
                //Instantiate(missile, invader.position, Quaternion.identity);
                break;
            }
        }
    }*/
    
    

    private void Update()
    {
        Vector3 position = transform.position;
        if (transform.position.x >= 2.25)
        {
            GoingLeft = true;
            position.y -= 1;
        }
        
        else if (transform.position.x <= -2.25)
        {
            GoingLeft = true;
            position.y -= 1;
        }
        
        while (GoingLeft)
        {
            position.x -= speed * Time.deltaTime;
        }
        while (!GoingLeft)
        {
            position.x += speed * Time.deltaTime;
        }
    }

    /*private void OnInvaderKilled(Invader invader)
    {
        invader.gameObject.SetActive(false);
        amountAlive--;
        speed+= 0.5f;
    }*/
}
