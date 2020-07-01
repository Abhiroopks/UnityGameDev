using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

/// <summary>
/// Processes mouse button inputs
/// </summary>
public class MouseButtonProcessor : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    GameObject prefabTeddyBear;

    // first frame input support
    bool spawnInputOnPreviousFrame = false;
	bool explodeInputOnPreviousFrame = false;
    bool currSpawnInput = false;
    bool currExplodeInput = false;
    Vector3 location; // used to spawn teddy bear @ mouse location, or explode at a bear location
    GameObject newObj; // can be either bear or explosion
    GameObject bear; // can be null

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{

        // 
        // Spawn teddy bear if necessary
        //

        currSpawnInput = (Input.GetAxis("SpawnTeddyBear") > 0);

        // spawn teddy bear IFF prev input is 0 and current input is > 0: rising edge
        if(!spawnInputOnPreviousFrame && currSpawnInput) {
            newObj = Instantiate(prefabTeddyBear) as GameObject;
            location = Input.mousePosition;
            location.z = -Camera.main.transform.position.z;
            location = Camera.main.ScreenToWorldPoint(location);
            newObj.transform.position = location;
        }

        spawnInputOnPreviousFrame = currSpawnInput; // save for next frame to check



        // 
        // Explode teddy bear if necessary
        //

        currExplodeInput = (Input.GetAxis("ExplodeTeddyBear") > 0);

        // spawn teddy bear IFF prev input is 0 and current input is > 0: rising edge
        if (!explodeInputOnPreviousFrame && currExplodeInput) {

            bear = GameObject.FindGameObjectWithTag("TeddyBear");
            //explode a bear only if one exists
            if (bear != null) { 
                location = bear.transform.position;
                Destroy(bear);
                newObj = Instantiate(prefabExplosion) as GameObject;;
                newObj.transform.position = location;
            }
        }

        explodeInputOnPreviousFrame = currExplodeInput; // save for next frame to check


    }
}
