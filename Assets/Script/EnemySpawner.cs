using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Setting")]
    public GameContoller gc;

    [Header("Enemys")]
    public int enemyKind = 0;
    public GameObject enemys;
    public GameObject txtObj;

    [Header("Position")]
    public Vector2 posX;
    public float posY = 0;

    [Header("Spawn Time")]
    public float spawnTime = 0;

    private float timer = 0;
    
    void Update()
    {
        timer += Time.deltaTime * 1;

        if (timer > spawnTime)
        {
            int ran = Random.Range(0, enemyKind);
            GameObject instanceObj = Instantiate(enemys);

            //ran이 높아질수록 대형
            instanceObj.transform.name = "Enemy_" + ran;

            float ranX = Random.Range(posX.x, posX.y);
            instanceObj.transform.position = new Vector3(ranX, posY, 0);

            instanceObj.GetComponent<Enemy>().gc = this.gc;
            instanceObj.GetComponent<Enemy>().txtObj = this.txtObj;

            Debug.Log("Set Word");
            int ranWord;
            switch (ran)
            {
                case 0:
                    ranWord = Random.Range(0, gc.words.easyWords.Count);
                    instanceObj.GetComponent<Enemy>().word = gc.words.easyWords[ranWord];
                    break;
                case 1:
                    ranWord = Random.Range(0, gc.words.normalWords.Count);
                    instanceObj.GetComponent<Enemy>().word = gc.words.normalWords[ranWord];
                    break;
                case 2:
                    ranWord = Random.Range(0, gc.words.hardWords.Count);
                    instanceObj.GetComponent<Enemy>().word = gc.words.hardWords[ranWord];
                    break;
            }

            gc.activeEnemys.Add(instanceObj);

            timer = 0;
        }
    }
}
