using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour{


    Rigidbody2D rigBod;
    Vector2 thrustDirection = new Vector2(1,0);
    const float thrustForce = 1f;
    const float degPerSecond = 90;
  //  float colliderRadius;
   // Vector3 pos;
    float rotateInput;

    // Start is called before the first frame update
    void Start(){

        rigBod = GetComponent<Rigidbody2D>();
        //CircleCollider2D cc2d = GetComponent<CircleCollider2D>();
      //  colliderRadius = cc2d.radius;

        
    }

    // For physics calculations
    void FixedUpdate(){

        //thrust
        if (Input.GetAxis("Thrust") > 0) {
            
            //calculate x and y components of thrust
            thrustDirection.x = Mathf.Cos(Mathf.Deg2Rad*transform.eulerAngles.z);
            thrustDirection.y = Mathf.Sin(Mathf.Deg2Rad*transform.eulerAngles.z);


            rigBod.AddForce(thrustDirection * thrustForce, ForceMode2D.Force);


        }

        //rotation 
        rotateInput = Input.GetAxis("RotateShip");
        if(rotateInput != 0) {
            transform.Rotate(Vector3.forward, degPerSecond * Time.deltaTime * rotateInput);
        }

    }
}
