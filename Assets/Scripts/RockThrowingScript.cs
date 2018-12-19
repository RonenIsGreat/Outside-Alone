using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockThrowingScript : MonoBehaviour {

    public Text PickupRockText;
    public Image Crosshair;
    public Text RocksNumberText;
    public Rigidbody throwingRockPrefab;
    public int DistanceToSee = 3;
    public int maxRocksToCollect = 5;
    public int ThrowForce = 1200;

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
        pickupRock();
        throwRock();
    }

    private void pickupRock()
    {
        RaycastHit hit;
        Color colorForCrossHair = originalCrosshairColor;
        int RayCastlayerMask = 1 << layerNumber;
        Color displayPickupRockTextColor = Color.clear;

        if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceToSee, RayCastlayerMask))
        {
            if (hit.collider.CompareTag("Rock"))
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
                        increaseRocksNumber();
                    }
                }
            }
        }

        Crosshair.color = colorForCrossHair;
        PickupRockText.color = displayPickupRockTextColor;
    }

    private void throwRock()
    {
        if(collectedRocksNumber > 0 && Input.GetMouseButtonDown(0))
        {
            Rigidbody rockInstance;
            rockInstance = Instantiate(throwingRockPrefab, transform.position, throwingRockPrefab.rotation) as Rigidbody;
            rockInstance.AddForce(transform.forward * ThrowForce);
            decreaseRocksNumber();
        }
    }

    private void increaseRocksNumber()
    {
        collectedRocksNumber++;
        RocksNumberText.text = collectedRocksNumber.ToString();
    }

    private void decreaseRocksNumber()
    {
        collectedRocksNumber--;
        RocksNumberText.text = collectedRocksNumber.ToString();
    }
}
