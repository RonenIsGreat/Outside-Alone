using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script

public class WinMenuScript : MonoBehaviour {
    public Button toMainText;
    // Use this for initialization
    void Start()
    {
        toMainText = toMainText.GetComponent<Button>();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
