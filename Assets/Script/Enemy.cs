using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Setting")]
    public GameContoller gc;
    public string word = "";    //단어
    public string spWord = "";  //단어 분할

    [Header("Hit")]
    public int hitCount = 0;

    [Header("Bullet")]
    public GameObject txtObj;
    public float fireInterval = 0;
    
    [Header("Move")]
    public float moveSpeed = 0;
    
    private Vector3 currentPos;
    
    void Start()
    {
        EnemySetting();
        for (int i = 0; i < word.Length; i++)
        {
            spWord += gc.splitWord.SplitString(word[i].ToString()).Trim();
        }
        Debug.Log(spWord + "  //  " + spWord.Length);
    }
    
    void Update()
    {
        //이동
        currentPos = transform.position;
        transform.position = new Vector3(currentPos.x, currentPos.y - (Time.deltaTime * moveSpeed), 0);

        //처치 실패
        if (currentPos.y < -6.5f)
        {
            Debug.Log("Life--");
            gc.scoreController.score -= 10;
            gc.scoreController.life--;
            gc.activeEnemys.Remove(this.gameObject);
            Destroy(gameObject);
        }

        //처치 성공
        if (spWord.Length == hitCount)
        {
            Debug.Log("Hit Die");
            gc.scoreController.score += 50;
            gc.activeEnemys.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }

    void EnemySetting()
    {
        char sp = '_';
        string[] spName = transform.name.Split(sp);

        switch (spName[1])
        {
            case "0":
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/BtlShip_S");
                break;
            case "1":
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/BtlShip_M");
                break;
            case "2":
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/BtlShip_L");
                break;
        }

        transform.GetChild(0).gameObject.AddComponent<PolygonCollider2D>();
        transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
    }
}
