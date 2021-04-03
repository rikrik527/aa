using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SingletonDefaultCamera
{



    //default field of view static
    public static float defaultFieldOfView = 93f;
    // default camera offset x
    public static float defaultOffsetX = 2f;
    public static float defaultOffsetZ = -3f;
    public static float defaultOffsetY = 1;

    //default select target field of view
    public static float selectedFieldOfView = 39f;
    public static float selectedOffsetX = 0f;
    public static float selectedOffsetY = 0.9f;
    public static float selectedOffsetZ = -3f;
    //default orthographicsize
    public static float defaultOrthographicSize = 8.4375f;
    //default selected orthgraphicsize
    public static float selectedOrthographicSize = 1f;

    //change view
    public static GameObject closeUpView;
    public static GameObject defaultView;
    public static GameObject cityView;


}


