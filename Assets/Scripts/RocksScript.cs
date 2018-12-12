using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocksScript : MonoBehaviour {

    public Text PickupRockText;
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
        Color displayPickupRockTextColor = Color.clear;

        if (Physics.Raycast(transform.position, transform.forward , out hit, DistanceToSee, RayCastlayerMask))
        {
            if (hit.collider.CompareTag("CollectableRock"))
            {
                colorForCrossHair = Color.yellow;
                displayPickupRockTextColor = Color.yellow;
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
        PickupRockText.color = displayPickupRockTextColor;
    }
}
