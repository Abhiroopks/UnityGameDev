using UnityEngine;

public class ScreenWrapper : MonoBehaviour {


    float colliderRadius;
    Vector3 pos;


    // Start is called before the first frame update
    void Start() {
       // CircleCollider2D cc2d = GetComponent<CircleCollider2D>();
        colliderRadius = GetComponent<CircleCollider2D>().radius;

    }

    // when the object is off screen
    void OnBecameInvisible() {
        // the new position after updates
        pos = gameObject.transform.position;

        // went off the right boundary
        if (pos.x - colliderRadius > ScreenUtils.ScreenRight) {
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
