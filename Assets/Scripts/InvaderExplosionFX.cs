using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderExplosionFX : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(waiterExplosion());
    }
    
    IEnumerator waiterExplosion()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
