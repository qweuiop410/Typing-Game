using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyEffect : MonoBehaviour
{
    [Range(0,30)]
    public float jumpPower = 0;
    public string inputStr = "";

    private Rigidbody rb;
    private TextMesh txt;
    private float timer = 0;

    void Start()
    {
        rb = transform.GetChild(0).GetComponent<Rigidbody>();
        rb.velocity = new Vector2(0, jumpPower);

        txt = transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>();
        txt.text = inputStr;
    }

    private void Update()
    {
        timer += Time.deltaTime * 1;
        if (timer > 5)
            Destroy(this.gameObject);
    }
}
