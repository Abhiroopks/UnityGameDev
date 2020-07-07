using UnityEngine;

public class Asteroid : MonoBehaviour {

    [SerializeField]
    Sprite Asteroid0;
    [SerializeField]
    Sprite Asteroid1;
    [SerializeField]
    Sprite Asteroid2;

    Vector3 scale;
    Vector3 scaleQuarter = new Vector3(0.25f, 0.25f, 0.25f);
    float angle_collision;
    float mag_collision;




    public void Initialize(Direction dir, Vector3 loc) {
        float rand = Random.Range(0, 3);
        if (rand < 1) {
            GetComponent<SpriteRenderer>().sprite = Asteroid0;
        }
        else if (rand < 2) {
            GetComponent<SpriteRenderer>().sprite = Asteroid1;
        }
        else {
            GetComponent<SpriteRenderer>().sprite = Asteroid2;
        }




        //start moving in a random 30 degree arc centered at the base direction
        float angle = 0;
        float arc = Mathf.Deg2Rad * 15;

        switch (dir) {
            case (Direction.Up):
                angle = Random.Range(-arc, arc) + 90;
                break;
            case (Direction.Down):
                angle = Random.Range(-arc, arc) - 90;
                break;
            case (Direction.Left):
                angle = Random.Range(-arc, arc) + 180;
                break;
            case (Direction.Right):
                angle = Random.Range(-arc, arc);
                break;
        }




        //  float angle = Random.Range(0, 2 * Mathf.PI);
        float mag = Random.Range(1, 2);

        GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * mag, ForceMode2D.Impulse);


        //Set location
        gameObject.transform.position = loc;

    }

    void OnCollisionEnter2D(Collision2D col) {






        
        // collision with bullet
        if (col.gameObject.tag == "Bullet") {

            //play sound
            AudioManager.Play(AudioClipName.AsteroidHit);

            // scale by half if bigger than 0.25 of original scale
            if (transform.localScale.x > 0.25f) {
                // scale object by 0.5
                scale = transform.localScale;
                scale *= 0.5f;
                transform.localScale = scale;
                // scale collider by 0.5
                GetComponent<CircleCollider2D>().radius *= 0.5f;

                // random direction, and magnitude
                angle_collision = Random.Range(0, 2 * Mathf.PI);
                mag_collision = Random.Range(1, 2);
                // spawn two children 
                Instantiate(gameObject).GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(angle_collision), Mathf.Sin(angle_collision)) * mag_collision, ForceMode2D.Impulse);
                angle_collision = Random.Range(0, 2 * Mathf.PI);
                Instantiate(gameObject).GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(angle_collision), Mathf.Sin(angle_collision)) * mag_collision, ForceMode2D.Impulse);
                // destroy bullet
                Destroy(col.gameObject);
            }

            //destroy object anyway
            Destroy(gameObject);

        }


        
    }

}
