using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

    public float Health = 100;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
