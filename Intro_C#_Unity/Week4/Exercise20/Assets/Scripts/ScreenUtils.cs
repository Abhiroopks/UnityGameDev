using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils
{
    // save screen info here (world coordinates)
    private static float screenLeft;
    private static float screenRight;
    private static float screenTop;
    private static float screenBottom;

    public static void Initialize() {
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCorner = new Vector3(0, 0, screenZ);
        Vector3 upperRightCorner = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCorner);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCorner);

        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;
    }

    public static float getLeft() {
        return screenLeft;
    }

    public static float getRight() {
        return screenRight;
    }

    public static float getTop() {
        return screenTop;
    }

    public static float getBottom() {
        return screenBottom;
    }


}
