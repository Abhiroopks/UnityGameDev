using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float angle;
    Vector3 newForce = new Vector3(0,0,0);
    const float lifespan = 1;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = lifespan;
        timer.Run();
        
    }

    // Update is called once per frame
    void Update()
    {

        //lifespan is over
        if (timer.Finished) {
            Destroy(gameObject);
        }
        
    }


    public void ApplyForce() {
        // apply impulse in my direction
        angle = Mathf.Deg2Rad*gameObject.transform.eulerAngles.z;
        newForce.x = Mathf.Cos(angle);
        newForce.y = Mathf.Sin(angle);
        // magnitude of movement
        newForce *= 6;
        GetComponent<Rigidbody2D>().AddForce(newForce,ForceMode2D.Impulse);

    }
}
