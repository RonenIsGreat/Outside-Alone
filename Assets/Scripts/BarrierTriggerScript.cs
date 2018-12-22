using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierTriggerScript : MonoBehaviour {

    public GameObject Barrier;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        Animator BarrierAnimator = Barrier.GetComponent<Animator>();

        if (BarrierAnimator != null)
        {
            BarrierAnimator.SetBool("Open", true);
        }
    }
}
