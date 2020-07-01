//using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Knight_Script : MonoBehaviour
{


    //gets called at beginning
    private void Start() {
        float mag = UnityEngine.Random.Range(3f, 5f);
        float angle = UnityEngine.Random.Range(0, 2 * Mathf.PI);

        //sets object into random direction 
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * mag, ForceMode2D.Impulse);
    }



    // gets called when the knight collides with something
    private void OnCollisionEnter2D(Collision2D collision) {
        print("Ouch");
    }
}
