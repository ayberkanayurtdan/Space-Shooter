using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody physics;
    [SerializeField] int speed; 
    void Start()
    {
        physics = GetComponent<Rigidbody>();

        physics.velocity = transform.forward*speed;
    }

 
}
