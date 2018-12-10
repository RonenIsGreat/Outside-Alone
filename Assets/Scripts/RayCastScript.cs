using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastScript : MonoBehaviour {

    public Text CollectRockText;
    public Image Crosshair;
    public Text RocksNumberText;
    public int DistanceToSee = 3;
    public int maxRocksToCollect = 5;

    private Color originalCrosshairColor;
    private int layerNumber;
    private int collectedRocksNumber;

	// Use this for initialization
	void Start () {
        originalCrosshairColor = Crosshair.color;
        layerNumber = 8;
        collectedRocksNumber = 0;
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Color colorForCrossHair = originalCrosshairColor;
        int RayCastlayerMask = 1 << layerNumber;

        if (Physics.Raycast(transform.position, transform.forward , out hit, DistanceToSee, RayCastlayerMask))
        {
            if (hit.collider.CompareTag("CollectableRock"))
            {
                colorForCrossHair = Color.green;
                GameObject rock = hit.collider.gameObject;

                // Check if player can collect more rocks
                if (collectedRocksNumber < maxRocksToCollect)
                {
                    if (Input.GetKeyDown("e"))
                    {
                        Destroy(rock);
                        collectedRocksNumber++;
                        RocksNumberText.text = collectedRocksNumber.ToString();
                    }
                }
            }
        }

        Crosshair.color = colorForCrossHair;
    }
}
