using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextScript : MonoBehaviour {

    public MeshRenderer InfoText;
    public float FadeSpeed = 3;
    bool exitedStartArea = false;
    Color infoTextOriginalColor;

    private void Start()
    {
        infoTextOriginalColor = InfoText.material.color;
    }

    // Update is called once per frame
    void Update ()
    {
        ColorChange();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
            exitedStartArea = false;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
            exitedStartArea = true;
    }

    private void ColorChange()
    {
        if (exitedStartArea)
            InfoText.material.color = Color.Lerp(InfoText.material.color, Color.clear, FadeSpeed * Time.deltaTime);
        else
            InfoText.material.color = Color.Lerp(InfoText.material.color, infoTextOriginalColor, FadeSpeed * Time.deltaTime);
    }
}
