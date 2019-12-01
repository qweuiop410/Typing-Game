using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffextsController : MonoBehaviour
{
    public GameContoller gc;
    public HitEffect hitEffect;
    
    public List<GameObject> effects = new List<GameObject>();

    public float randomPosRange = 0;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            effects.Add(transform.GetChild(i).gameObject);

        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].AddComponent<HitEffect>();
            effects[i].SetActive(false);
        }

        hitEffect.enabled = false;
    }
    
    public void HitEffectSpawn(Vector3 pos)
    {
        for (int i = 0; i < effects.Count; i++)
        {
            if (!effects[i].activeInHierarchy)
            {
                float x = Random.Range(-randomPosRange, randomPosRange);
                float y = Random.Range(-randomPosRange, randomPosRange);

                effects[i].SetActive(true);
                effects[i].transform.position = new Vector3(pos.x + x, pos.y + y, pos.z);
                break;
            }
        }
    }
}
