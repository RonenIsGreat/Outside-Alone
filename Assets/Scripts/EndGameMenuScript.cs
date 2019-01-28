using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script

public class EndGameMenuScript : MonoBehaviour {
    public Button toMainText;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        toMainText = toMainText.GetComponent<Button>();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
