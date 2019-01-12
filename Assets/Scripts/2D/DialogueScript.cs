using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {
    public GameObject dialogueBox;
    public Text dialogueText;
    private List<string> messages = new List<string>();
    private int currentTextIndex = 0;
    public GameObject robotArrow;
    public GameObject zombieArrow;
    // Use this for initialization
    void Start () {
        messages.Add("Robot: Hey bud! what's up??");
        messages.Add("Zombie: Bad Morning!!! My zombie friends started killing humans!");
        messages.Add("Robot: Where?");
        messages.Add("Zombie: On the next villages! please neutralize them!!");
        messages.Add("Robot: On my way!");
        messages.Add("Zombie: Go to the Right arrow, press Space key to jump. Good Luck!");
        robotArrow.SetActive(false);
        zombieArrow.SetActive(false);
        dialogueText.text = messages[currentTextIndex++];
    }
	
	// Update is called once per frame
	void Update () {
		if (dialogueBox.activeSelf)
        {
            if (currentTextIndex % 2 == 0)
            {
                robotArrow.SetActive(false);
                zombieArrow.SetActive(true);
            }
            else
            {
                robotArrow.SetActive(true);
                zombieArrow.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Space) && currentTextIndex<messages.Count)
            {
                dialogueText.text = messages[currentTextIndex++];
            } else if (Input.GetKeyDown(KeyCode.Space) && currentTextIndex >= messages.Count)
            {
                dialogueBox.SetActive(false);
                robotArrow.SetActive(false);
                zombieArrow.SetActive(false);
            }
        }
	}
}
