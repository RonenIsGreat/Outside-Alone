using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieFriendController : MonoBehaviour {
    public Transform target;
    public float engaugeDistance = 10f;
    public float moveSpeed = 5f;
    private bool isFacingLeft = true;
    public Text dialogueText;


    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (dialogueText.IsActive())
        {
            return;
        }
		if (Vector3.Distance(target.position,this.transform.position) < engaugeDistance)
        {
            Vector3 targetDirection = target.position - this.transform.position;

            if (Mathf.Sign(targetDirection.x) == 1 && isFacingLeft)
            {
                Flip();
            } else if (Mathf.Sign(targetDirection.x) == -1 && !isFacingLeft)
            {
                Flip();
            }
        }
        else if (Vector3.Distance(target.position, this.transform.position) < engaugeDistance)
        {
            Debug.DrawLine(target.position, this.transform.position, Color.green);
        }
	}

    private void Flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
