using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{

    Timer spawnTimer;
    [SerializeField]
    GameObject greenRock;
    [SerializeField]
    GameObject magentaRock;
    [SerializeField]
    GameObject whiteRock;


    // spawn location support
    const int SpawnBorderSize = 100;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;

    // Start is called before the first frame update
    void Start()
    {
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 1; // spawn every second
        spawnTimer.Run();

    }

    // Update is called once per frame
    void Update()
    {
        // check for time to spawn a new teddy bear
        if (spawnTimer.Finished) {
            // only keep a maximum of 4 rocks on the screen
            if (GameObject.FindGameObjectsWithTag("Rock").Length < 4) {
                SpawnRock();
            }

            //reset timer
            spawnTimer.Run();
        }
    }



    /// <summary>
    /// Spawns a new teddy bear at a random location
    /// </summary>
    void SpawnRock() {
        // generate random location and create new teddy bear
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
            Random.Range(minSpawnY, maxSpawnY),
            -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        int rockType = (int)Random.Range(0f,3f);

        GameObject rock = null;
        switch (rockType) {
            case 0:
                rock = Instantiate(greenRock) as GameObject;
                break;
            case 1:
                rock = Instantiate(magentaRock) as GameObject;
                break;
            case 2:
                rock = Instantiate(whiteRock) as GameObject;
                break;
        }


        rock.transform.position = worldLocation;
    }
}
