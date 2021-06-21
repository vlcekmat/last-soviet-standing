using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    // stats
    public float shootingCooldown = 1f;

    // state
    public bool canShoot = true;

    // component references
    Rigidbody2D rb;
    Animator playerAnimator;
    [SerializeField] Animator flashAnimator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {   
        RotateTowardsCursor();
    }

    void RotateTowardsCursor()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 origPos = transform.position;
        float angle = MathModule.AngleFromTo(origPos, mousePos);
        rb.SetRotation(angle);
    }

    public void Shoot()
    {
        if(canShoot)
        {   
            StartCoroutine(StartShootingCooldown());
            flashAnimator.gameObject.GetComponent<AudioSource>().Play();
            playerAnimator.SetTrigger("Shoot");
            flashAnimator.SetTrigger("Shoot");
        }
    }

    IEnumerator StartShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootingCooldown);
        canShoot = true;
    }
}
