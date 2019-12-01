using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Setting")]
    public GameContoller gc;

    [Header("Enemy")]
    public GameObject target;

    [Header("Line Setting")]
    public Vector2 lineWidth;
    public Color lineColor;

    private LineRenderer lr;
    
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //타겟 찾기
        FindTarget();

        //라인 시작, 종료점 설정
        DrawLine();
    }

    void FindTarget()
    {
        if (target != null && gc.activeEnemys.Count > 0)
        {
            for (int i = 1; i < gc.activeEnemys.Count; i++)
            {
                if (Vector3.Distance(transform.position, target.transform.position) > Vector3.Distance(transform.position, gc.activeEnemys[i - 1].transform.position))
                    target = gc.activeEnemys[i - 1];
            }
        }
        else if (gc.activeEnemys.Count > 0)
            target = gc.activeEnemys[0];

        gc.target = target;
    }

    void DrawLine()
    {
        if (target != null)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, target.transform.position);
            transform.LookAt(target.transform, Vector3.forward);
        }
        else
            lr.SetPosition(1, transform.position);

        lr.startWidth = lineWidth.x;
        lr.endWidth = lineWidth.y;

        lr.material.SetColor("_Color", lineColor);
    }
}
