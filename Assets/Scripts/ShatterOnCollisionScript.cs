using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterOnCollisionScript : MonoBehaviour {

    public GameObject Replacement;
    public GameObject[] Zombies;
    public float DamageToZombies = 100;

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Rock"))
        {
            GameObject.Instantiate(Replacement, transform.position, transform.rotation);
            Destroy(gameObject);

            foreach (var zombie in Zombies)
            {
                if (zombie == null)
                    continue;

                ZombieScript script = zombie.GetComponent<ZombieScript>();

                if (script == null)
                    continue;

                bool toChasePlayer = false;
                script.GetDamage(DamageToZombies, toChasePlayer);
            }
        }
    }
}
