using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WindowsInput;

public class TypingController : MonoBehaviour
{
    public TextMesh t1;
    public TextMesh t2;

    //세팅
    public GameContoller gc;
    
    //이펙트 생성
    public GameObject effectObj;
    public float posInterval = 0;
    private float pos_X = 0;
    
    //키 입력
    private KeyCode[] keyCodes = null;
    private List<KeyCode> keys = new List<KeyCode>();
    private string text = "";

    //키 입력 확인
    private bool isInput = true;

    //적 단어 자릿수
    private int wordCount = 0;

    [Header("Bullet")]
    public GameObject bullet;
    public Vector3 bulletStartPos;

    void Start()
    {
        // 키코드를 한번 받아옵니다. 이렇게 전체를 받아도되지만 원하는것만 추가해도 되겠지요. 
        if (keyCodes == null)
            keyCodes = Enum.GetValues(typeof(KeyCode)) as KeyCode[];
    }
    void Update()
    {
        // 매 프레임마다 눌렸는지 검사해서 리스트에 누른 키를 추가합니다. 
        foreach (KeyCode keyCode in keyCodes)
            if (WinInput.GetKeyDown(keyCode))
            {
                keys.Add(keyCode);
                isInput = true;
            }

        // 출력을 위해 담아버립니다. 
        foreach (KeyCode keyCode in keys)
            text = keyCode.ToString();

        if (isInput)
        {
            GameObject instance = Instantiate(effectObj);
            instance.GetComponent<KeyEffect>().inputStr = Translation(text);
            instance.transform.position = new Vector3(pos_X, -4.3f, 0);
            instance.transform.parent = transform;
            isInput = false;

            //총알 생성
            if (gc.target != null && gc.target.GetComponent<Enemy>().spWord[wordCount].ToString() == Translation(text))
            {
                Debug.Log("Bullet Spawn");
                GameObject instanceBullet = Instantiate(bullet);
                instanceBullet.GetComponent<Bullet>().target = gc.target;
                instanceBullet.GetComponent<Bullet>().gc = gc;
                instanceBullet.transform.position = bulletStartPos;

                if (gc.target.GetComponent<Enemy>().spWord.Length - 1 == wordCount)
                {
                    wordCount = 0;

                    t1.text = "Target Word :--/--";
                    t2.text = "Input : --";
                }
                else
                    wordCount++;
            }
        }

        //Test Text UI
        if (gc.target != null)
        {
            t1.text = "Target Word :" + gc.target.GetComponent<Enemy>().word + " / " + gc.target.GetComponent<Enemy>().spWord;
            t2.text = "Input : " + Translation(text);
        }
        else
        {
            t1.text = "Target Word :--/--";
            t2.text = "Input : --";
        }
    }

    private string Translation(string str)
    {
        string returnStr = "";
        
        switch (str)
        {
            #region**윗줄
            case "Q":
                returnStr = "ㅂ";
                pos_X = (-posInterval / 2) - posInterval * 4;
                break;
            case "W":
                returnStr = "ㅈ";
                pos_X = (-posInterval / 2) - posInterval * 3;
                break;
            case "E":
                returnStr = "ㄷ";
                pos_X = (-posInterval / 2) - posInterval * 2;
                break;
            case "R":
                returnStr = "ㄱ";
                pos_X = (-posInterval / 2) - posInterval;
                break;
            case "T":
                returnStr = "ㅅ";
                pos_X = -posInterval / 2;
                break;
            case "Y":
                returnStr = "ㅛ";
                pos_X = posInterval / 2;
                break;
            case "U":
                returnStr = "ㅕ";
                pos_X = (posInterval / 2) + posInterval;
                break;
            case "I":
                returnStr = "ㅑ";
                pos_X = (posInterval / 2) + posInterval * 2;
                break;
            case "O":
                returnStr = "ㅐ";
                pos_X = (posInterval / 2) + posInterval * 3;
                break;
            case "P":
                returnStr = "ㅔ";
                pos_X = (posInterval / 2) + posInterval * 4;
                break;
            #endregion

            #region**중간줄
            case "A":
                returnStr = "ㅁ";
                pos_X = -posInterval * 4;
                break;
            case "S":
                returnStr = "ㄴ";
                pos_X = -posInterval * 3;
                break;
            case "D":
                returnStr = "ㅇ";
                pos_X = -posInterval * 2;
                break;
            case "F":
                returnStr = "ㄹ";
                pos_X = -posInterval;
                break;
            case "G":
                returnStr = "ㅎ";
                pos_X = 0;
                break;
            case "H":
                returnStr = "ㅗ";
                pos_X = posInterval;
                break;
            case "J":
                returnStr = "ㅓ";
                pos_X = posInterval * 2;
                break;
            case "K":
                returnStr = "ㅏ";
                pos_X = posInterval * 3;
                break;
            case "L":
                returnStr = "ㅣ";
                pos_X = posInterval * 4;
                break;
            #endregion

            #region **아랫줄
            case "Z":
                returnStr = "ㅋ";
                pos_X = (-posInterval / 2) - posInterval * 3;
                break;
            case "X":
                returnStr = "ㅌ";
                pos_X = (-posInterval / 2) - posInterval * 2;
                break;
            case "C":
                returnStr = "ㅊ";
                pos_X = (-posInterval / 2) - posInterval;
                break;
            case "V":
                returnStr = "ㅍ";
                pos_X = -posInterval / 2;
                break;
            case "B":
                returnStr = "ㅠ";
                pos_X = posInterval / 2;
                break;
            case "N":
                returnStr = "ㅜ";
                pos_X = (posInterval / 2) + posInterval; 
                break;
            case "M":
                returnStr = "ㅡ";
                pos_X = (posInterval / 2) + posInterval * 2;
                break;
                #endregion
        }
        return returnStr;
    }
}
