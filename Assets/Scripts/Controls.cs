using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{    
    Player player;

    void Start() 
    {
        player = GetComponent<Player>();
    }
    void Update()
    {   
        // left mouse button
        if(Input.GetMouseButtonDown(0))
        {
            player.Shoot();
        }
    }
}
