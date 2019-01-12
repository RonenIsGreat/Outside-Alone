using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieFriendController : MonoBehaviour {
    private bool isDead = false;
    private Animator animator;
    public GameObject dialogueBox;

    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (dialogueBox.activeSelf || isDead)
        {
            return;
        }
        animator.SetBool("IsDead", true);
        isDead = true;
    }
}
