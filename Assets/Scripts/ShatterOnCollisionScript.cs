using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterOnCollisionScript : MonoBehaviour {

    public GameObject Replacement;

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Rock") || col.collider.CompareTag("Zombie"))
        {
            GameObject.Instantiate(Replacement, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
