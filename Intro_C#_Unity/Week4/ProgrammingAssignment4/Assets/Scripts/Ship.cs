using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour{


    Rigidbody2D rigBod;
    Vector2 thrustDirection = new Vector2(1,0);
    const float thrustForce = 2f;
    const float degPerSecond = 90;
    float colliderRadius;
    Vector3 pos;
    float rotateInput;

    // Start is called before the first frame update
    void Start(){

        rigBod = GetComponent<Rigidbody2D>();
        CircleCollider2D cc2d = GetComponent<CircleCollider2D>();
        colliderRadius = cc2d.radius;

        
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

    // when the object is off screen
    void OnBecameInvisible() {
        // the new position after updates
        pos = gameObject.transform.position;

        // went off the right boundary
        if(pos.x - colliderRadius > ScreenUtils.ScreenRight) {
            pos.x = ScreenUtils.ScreenLeft - colliderRadius; // teleport to left side
        }

        // went off the left boundary
        else if (pos.x + colliderRadius < ScreenUtils.ScreenLeft) {
            pos.x = ScreenUtils.ScreenRight + colliderRadius; // teleport to right side
        }

        // went off the top boundary
        if (pos.y - colliderRadius > ScreenUtils.ScreenTop) {
            pos.y = ScreenUtils.ScreenBottom - colliderRadius; // teleport to bottom side
        }

        // went off the bottom boundary
        else if (pos.y + colliderRadius < ScreenUtils.ScreenBottom) {
            pos.y = ScreenUtils.ScreenTop + colliderRadius; // teleport to top side
        }

        gameObject.transform.position = pos;



    }
}
