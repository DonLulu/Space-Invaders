using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionFX : MonoBehaviour
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
