using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ss : MonoBehaviour
{
    static int ssIndex;
    private float time;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ScreenCapture.CaptureScreenshot("ss/ss" + ssIndex.ToString() + ".png" );
            ssIndex++;
        }

        time += Time.deltaTime;
        if (time >= 3f)
        {
            ScreenCapture.CaptureScreenshot("ss/ss" + ssIndex.ToString() + ".png" );
            ssIndex++;
            time = 0f;
        }
    }
}
