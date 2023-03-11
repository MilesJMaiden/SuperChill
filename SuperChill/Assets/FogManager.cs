using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogEndDistance = 5;
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.fogEndDistance = Mathf.Lerp(RenderSettings.fogEndDistance, 50, 0.01f);
    }
}
