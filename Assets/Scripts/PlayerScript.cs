using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float Health = 100;
    public float MaxHealth = 100;
    public float RegenHealth = 2;
    public Text HealthNumberText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float regen = RegenHealth * Time.deltaTime;
        increaseHealth(regen);
    }

    public void TakeDamage(float damage)
    {
        decreaseHealth(damage);
    }

    private void increaseHealth(float num)
    {
        Health += num;

        if (Health > MaxHealth)
            Health = MaxHealth;

        HealthNumberText.text = ((int)Health).ToString();
    }

    private void decreaseHealth(float num)
    {
        Health -= num;
        HealthNumberText.text = ((int)Health).ToString();

        if (Health < 0)
            playerDied();
    }

    private void playerDied()
    {
        // TODO (game over scene? restart lvl)
    }
}
