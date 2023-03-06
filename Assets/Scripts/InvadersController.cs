using UnityEngine;

public class InvadersController : MonoBehaviour
{
    public float speed = 1f;
    public bool goingLeft;
    public bool goingDown;
    private float amountDown = 0.3f;

    
    private void Update()
    {
        /*if (transform.position.x >= 2)
        {
            goingLeft = true;
            transform.position = new Vector3(transform.position.x, transform.position.y-amountDown);
        }
        
        else if (transform.position.x <= -1.5)
        {
            goingLeft = false;
            transform.position = new Vector3(transform.position.x, transform.position.y - amountDown);
        }*/
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