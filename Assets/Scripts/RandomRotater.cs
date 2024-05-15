using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{
    Rigidbody physics;
    public int speed;
    private void Start()
    {
        physics = GetComponent<Rigidbody>();

        physics.angularVelocity = Random.insideUnitSphere* speed;


    }
}
