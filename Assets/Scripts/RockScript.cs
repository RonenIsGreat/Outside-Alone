﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour {
    public float Damage = 50;

    private Vector3 lastPosition;
    private float speed;

    void Start () {
        lastPosition = transform.position;
        speed = 0;
    }
    
    void FixedUpdate()
    {
        // speed in km/h
        speed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = transform.position;
        stopRollingRock();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ZombieScript targetScript = collision.transform.GetComponent<ZombieScript>();

        if (targetScript != null)
        {
            float dealingDamage = calculateDamage();
            bool toChasePlayer = true;
            targetScript.GetDamage(dealingDamage, toChasePlayer);
        }
    }

    private float calculateDamage()
    {
        if (speed > 5)
            return Damage;
        else
            return 0;
    }

    private void stopRollingRock()
    {
        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
        rigidbody.inertiaTensorRotation = new Quaternion(0.01f, 0.01f, 0.01f, 1f);
        float scaler = 0.1f;
        rigidbody.AddTorque(-rigidbody.angularVelocity * scaler);
    }
}
