using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    [Header("Script")]
    public TypingController typingController;
    public EnemySpawner enemySpawner;
    public Cannon cannon;
    public Words words;
    public SplitWord splitWord;
    public HitEffextsController hitEffextsController;
    public ScoreController scoreController;

    [Header("Enemy Control")]
    public GameObject target;
    public List<GameObject> activeEnemys;
    
    private void Start()
    {
        typingController.gc = this;
        enemySpawner.gc = this;
        cannon.gc = this;
        words.gc = this;
    }
}
