using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public float desTime = 3.0f;

    private float timer = 0;
    
    void Update()
    {
        timer += Time.deltaTime * 1;
        if (timer > desTime)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }
}
