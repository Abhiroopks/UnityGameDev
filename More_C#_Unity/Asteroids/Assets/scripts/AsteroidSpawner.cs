using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    [SerializeField]
    GameObject prefabAsteroid;

    List<GameObject> obj = new List<GameObject>();

    float colliderRadius;


    // Start is called before the first frame update
    void Start() {
        colliderRadius = prefabAsteroid.GetComponent<CircleCollider2D>().radius;

        //spawn at bottom, moving up
        Vector3 loc = new Vector3(0, ScreenUtils.ScreenBottom - colliderRadius, 0);
        obj.Add(Instantiate(prefabAsteroid,new Vector3(0,0,0),Quaternion.identity));
        obj[0].GetComponent<Asteroid>().Initialize(Direction.Up,loc);

        //spawn at top, moving down
        loc.Set(0,ScreenUtils.ScreenTop + colliderRadius,0);
        obj.Add(Instantiate(prefabAsteroid, new Vector3(0, 0, 0), Quaternion.identity));
        obj[1].GetComponent<Asteroid>().Initialize(Direction.Down, loc);

        //spawn at right, moving left
        loc.Set(ScreenUtils.ScreenRight + colliderRadius, 0, 0);
        obj.Add(Instantiate(prefabAsteroid, new Vector3(0, 0, 0), Quaternion.identity));
        obj[2].GetComponent<Asteroid>().Initialize(Direction.Left, loc);

        //spawn at right, moving left
        loc.Set(ScreenUtils.ScreenLeft - colliderRadius, 0, 0);
        obj.Add(Instantiate(prefabAsteroid, new Vector3(0, 0, 0), Quaternion.identity));
        obj[3].GetComponent<Asteroid>().Initialize(Direction.Right, loc);


    }

    // Update is called once per frame
    void Update() {

    }
}
