using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2FinishedScript : MonoBehaviour {

    public List<GameObject> zombiesToDestroy = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (areAllzombiesDestroyed())
        {
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ChangeScene()
    {
        //Wait a second
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(5);
    }

    private bool areAllzombiesDestroyed()
    {
        foreach (var zombie in zombiesToDestroy)
        {
            if (zombie != null)
                return false;
        }

        return true;
    }
}
