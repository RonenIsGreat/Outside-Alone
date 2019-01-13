using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DsiplayObjectCameraScript : MonoBehaviour {

    public GameObject[] targetObjects;
    public GameObject mainCameraObject;
    public GameObject playerControllerObject;
    public Text DisplayTargetText;

    private Camera mainCamera;
    private Camera displayCamera;
    private FirstPersonController walkScript;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = new Vector3(0, 15, -2);
        mainCamera = mainCameraObject.GetComponent<Camera>();
        displayCamera = GetComponent<Camera>();
        walkScript = playerControllerObject.GetComponent<FirstPersonController>();
        StartCoroutine(removeText());
    }

    private IEnumerator removeText()
    {
        //Wait for 10 seconds
        yield return new WaitForSeconds(10);
        DisplayTargetText.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        Transform closestTarget = null;

        // Get the closest target
        foreach (var targetObject in targetObjects)
        {
            if (targetObject == null)
                continue;

            if (closestTarget == null)
                closestTarget = targetObject.transform;
            else if (Vector3.Distance(targetObject.transform.position, playerControllerObject.transform.position) <
                     Vector3.Distance(closestTarget.position, playerControllerObject.transform.position))
            {
                closestTarget = targetObject.transform;
            }
        }

        // Display the closest target
        if (closestTarget != null)
        {
            transform.position = closestTarget.transform.position + offset;
            transform.LookAt(closestTarget.transform);

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
