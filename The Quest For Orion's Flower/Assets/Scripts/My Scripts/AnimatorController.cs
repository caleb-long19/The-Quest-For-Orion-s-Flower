using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public static AnimatorController instance;

    Transform myTrans;
    Animator myAnim; // connects to the Animator component in Unity
    Vector3 artScaleCache;

    void Start()
    {
        myTrans = this.transform;
        myAnim = this.gameObject.GetComponent<Animator>(); // myAnim is equal and attached to the Animator component in Unity
        instance = this;

        artScaleCache = myTrans.localScale;
    }

    public void UpdateSpeed(float currentSpeed) // Update Speed Procedure
    {
        myAnim.SetFloat("Speed", currentSpeed); // Speed parameter is set to the players current speed.
    }
}
