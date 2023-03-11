using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public VelocityEstimator head;
    public VelocityEstimator rightHand;
    public VelocityEstimator leftHand;

    public float sensitivity = 0.08f;
    public float minTimeScale = 0.05f;

    private float initialFixedDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //The sum of all velocity vals
        float velocityMagnitude = head.GetVelocityEstimate().magnitude + rightHand.GetVelocityEstimate().magnitude + leftHand.GetVelocityEstimate().magnitude;

        Time.timeScale = Mathf.Clamp01(minTimeScale + velocityMagnitude * sensitivity);

        //apply to physics time
        Time.fixedDeltaTime = initialFixedDeltaTime * Time.timeScale;
    }
}
