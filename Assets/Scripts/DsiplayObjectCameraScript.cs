using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DsiplayObjectCameraScript : MonoBehaviour {

    public GameObject targetObject;
    public GameObject mainCameraObject;
    public GameObject playerControllerObject;
    public Text DisplayTargetText;

    private Camera mainCamera;
    private Camera displayCamera;
    private FirstPersonController walkScript;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        if(targetObject != null)
        {
            offset = transform.position - targetObject.transform.position;
            mainCamera = mainCameraObject.GetComponent<Camera>();
            displayCamera = GetComponent<Camera>();
            walkScript = playerControllerObject.GetComponent<FirstPersonController>();
            StartCoroutine(removeText());
        }
    }

    private IEnumerator removeText()
    {
        //Wait for 10 seconds
        yield return new WaitForSeconds(10);
        DisplayTargetText.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (targetObject != null)
        {
            transform.position = targetObject.transform.position + offset;

            if (Input.GetKey(KeyCode.T))
            {
                mainCamera.enabled = false;
                displayCamera.enabled = true;
                walkScript.enabled = false;
                DisplayTargetText.enabled = false;
            }
            else
            {
                mainCamera.enabled = true;
                displayCamera.enabled = false;
                walkScript.enabled = true;
            }
        }
    }
}
