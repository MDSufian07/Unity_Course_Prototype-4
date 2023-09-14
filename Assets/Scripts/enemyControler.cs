using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class enemyControler : MonoBehaviour
{
    private float speed = 1.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    public int Length { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDir*speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
