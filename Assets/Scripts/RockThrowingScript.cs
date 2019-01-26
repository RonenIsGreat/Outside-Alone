using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockThrowingScript : MonoBehaviour {

    public Text PickupRockText;
    public Text CantPickupRockText;
    public Image Crosshair;
    public Text RocksNumberText;
    public Rigidbody throwingRockPrefab;
    public int DistanceToCollectRockFrom = 3;
    public int maxRocksToCollect = 5;
    public int ThrowForce = 1200;
    public bool UnlimitedRocks = false;

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
        PickupRockText.color = Color.clear;
        CantPickupRockText.color = Color.clear;

        if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceToCollectRockFrom, RayCastlayerMask))
        {
            if (hit.collider.CompareTag("Rock"))
            {
                GameObject rock = hit.collider.gameObject;

                // Check if player can collect more rocks
                if (collectedRocksNumber < maxRocksToCollect)
                {
                    colorForCrossHair = Color.yellow;
                    PickupRockText.color = Color.yellow;

                    // Player collects the rock
                    if (Input.GetKeyDown("e"))
                    {
                        Destroy(rock);
                        increaseRocksNumber();
                    }
                }
                else
                {
                    CantPickupRockText.color = Color.red;
                }
            }
        }

        Crosshair.color = colorForCrossHair;
    }

    private void throwRock()
    {
        if(collectedRocksNumber > 0 && Input.GetMouseButtonDown(0))
        {
            Rigidbody rockInstance;
            rockInstance = Instantiate(throwingRockPrefab, transform.position + transform.forward, throwingRockPrefab.rotation) as Rigidbody;

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
        if (!UnlimitedRocks)
        {
            collectedRocksNumber--;
            RocksNumberText.text = collectedRocksNumber.ToString();
        }
    }
}
