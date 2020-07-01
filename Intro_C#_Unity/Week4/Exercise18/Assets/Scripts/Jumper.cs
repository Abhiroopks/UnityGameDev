using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    // Update is called once per frame
    void Update(){
        // if mouse button is clicked, jump object to mouse location
        if (Input.GetMouseButtonDown(0)) {
            Vector3 screenpt = Input.mousePosition;
            screenpt.z = -Camera.main.transform.position.z;

            gameObject.transform.position = Camera.main.ScreenToWorldPoint(screenpt);
        }



        
    }

}
