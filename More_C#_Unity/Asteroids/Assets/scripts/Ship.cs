using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ship
/// </summary>
public class Ship : MonoBehaviour {

    //for bullets
    [SerializeField]
    GameObject bulletPrefab;

    GameObject newBullet;






    // thrust and rotation support
    Rigidbody2D rb2D;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 10;
    const float RotateDegreesPerSecond = 270;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start() {
        // saved for efficiency
        rb2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update() {
        // check for rotation input
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0) {

            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0) {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }

        // add a bullet to our list of bullets
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            AudioManager.Play(AudioClipName.PlayerShot);
            newBullet = Instantiate(bulletPrefab);
            //adjust the latest addition only
            newBullet.transform.position = gameObject.transform.position;
            newBullet.transform.rotation = gameObject.transform.rotation;
            newBullet.GetComponent<Bullet>().ApplyForce();
            


        }



    }

    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void FixedUpdate() {
        // thrust as appropriate
        if (Input.GetAxis("Thrust") != 0) {
            rb2D.AddForce(ThrustForce * thrustDirection,
                ForceMode2D.Force);
        }
    }



    //When the ship collides with something (right now, it only collides with asteroids)
    void OnCollisionEnter2D(Collision2D col) {
        AudioManager.Play(AudioClipName.PlayerDeath);
        Destroy(gameObject);
        GameObject.Find("HUD").GetComponent<HUD>().stopTimer();
    }

}
