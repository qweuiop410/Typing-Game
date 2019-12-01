using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameContoller gc;
    public GameObject target;
    public float moveSpeed = 0;
    
    private float moveValue = 0;
    private float timer = 0;
    
    void Update()
    {
        moveValue += Time.deltaTime * moveSpeed;
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Mathf.Abs(Mathf.Tan(moveValue)));
            transform.LookAt(target.transform);
            transform.GetChild(0).transform.localRotation = Quaternion.Euler(-90, 0, 0);

            if (Vector3.Distance(transform.position, target.transform.position) < 0.5f)
            {
                Debug.Log("Bullet Destroy / Hit Count");
                gc.scoreController.score += 10;
                gc.hitEffextsController.HitEffectSpawn(target.transform.position);
                target.GetComponent<Enemy>().hitCount++;
                Destroy(gameObject);
            }
        }

        timer += Time.deltaTime * 1;
        if(timer > 5)
            Destroy(gameObject);
    }
}
