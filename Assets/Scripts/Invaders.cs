using UnityEngine;

public class Invaders : MonoBehaviour
{
    private float speed = 5f;
    //public GameObject missile;
    private bool GoingLeft;


    private void Start()
    {
    }

    
    
    

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
        
        if (GoingLeft)
        {
            position.x -= speed * Time.deltaTime;
        }
        if (!GoingLeft)
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
