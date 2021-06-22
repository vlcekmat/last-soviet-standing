using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{   
    // stats
    public float movSpeed = 1f;
    // cached reference
    GameObject player;
    Rigidbody2D rb;

    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        FacePlayer();

        rb.MovePosition(transform.gameObject.transform.position + GetVectorToPlayer().normalized * movSpeed * Time.deltaTime);
    }

    void FacePlayer()
    {
        float angle = MathModule.AngleFromTo(transform.position, player.transform.position);
        rb.SetRotation(angle);
    }

    Vector3 GetVectorToPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        return direction;
    }
}
