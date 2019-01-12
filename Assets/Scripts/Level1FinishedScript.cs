using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1FinishedScript : MonoBehaviour {

    public GameObject zombieToKill;

    // Update is called once per frame
    void Update()
    {
        if (isZombieKilled())
        {
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ChangeScene()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(4);
    }

    private bool isZombieKilled()
    {
        if (zombieToKill != null)
            return false;

        return true;
    }
}
