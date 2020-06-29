using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    // screen specs
    const int SpawnBorderSize = 100;
    float minX = -9.17f;
    float maxX = 9.17f;
    float minY = -5.10f;
    float maxY = 5.10f;

    void Start() { 

        // apply impulse force to get game object moving
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 2f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce,MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
    }

    

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
