using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    // Called before Start()
    void Awake() {
        ScreenUtils.Initialize();

    }
}
