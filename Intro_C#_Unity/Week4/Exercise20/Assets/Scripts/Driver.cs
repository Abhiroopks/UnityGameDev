using UnityEngine;

public class Driver : MonoBehaviour {

    private const float deltaUnitsPerSecond = 5;
    private float hInput;
    private float vInput;
    private float mag;
    private Vector3 loc;
    private float colliderHalfWidth;
    private float colliderHalfHeight;



    private void Start() {
        //initialize collider info
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        colliderHalfWidth = collider.size.x / 2;
        colliderHalfHeight = collider.size.y / 2;

    }


    // Update is called once per frame
    void Update() {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        mag = Mathf.Sqrt(Mathf.Pow(hInput, 2) + Mathf.Pow(vInput, 2));
        // ensure velocity is always 5 units per second (normalize)
        if (mag > 1) {
            hInput /= mag;
            vInput /= mag;
        }

        // update location by adding the delta changes in x and y
        loc = gameObject.transform.position;
        loc.x += deltaUnitsPerSecond * hInput * Time.deltaTime;
        loc.y += deltaUnitsPerSecond * vInput * Time.deltaTime;
        //ensure object is not outside of screen
        keepInbounds();

        gameObject.transform.position = loc;





    }




    void keepInbounds() {
        //adjust the loc variable to keep in bounds

        if (loc.x - colliderHalfWidth < ScreenUtils.getLeft()) {
            loc.x = ScreenUtils.getLeft() + colliderHalfWidth;
        }
        else if (loc.x + colliderHalfWidth > ScreenUtils.getRight()) {
            loc.x = ScreenUtils.getRight() - colliderHalfWidth;
        }
        if (loc.y - colliderHalfHeight < ScreenUtils.getBottom()) {
            loc.y = ScreenUtils.getBottom() + colliderHalfHeight;
        }
        else if (loc.y + colliderHalfHeight > ScreenUtils.getTop()) {
            loc.y = ScreenUtils.getTop() - colliderHalfHeight;
        }


    }
}
