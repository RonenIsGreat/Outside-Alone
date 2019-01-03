using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialFinishedScrpit : MonoBehaviour {

    public List<GameObject> objectsToDestroy = new List<GameObject>();
	
	// Update is called once per frame
	void Update () {
        if (areAllObjectsDestroyed())
        {
            StartCoroutine(ChangeScene());
        }
	}

    private IEnumerator ChangeScene()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(3);
    }

    private bool areAllObjectsDestroyed()
    {
        foreach (var item in objectsToDestroy)
        {
            if (item != null)
                return false;
        }

        return true;
    }
}
