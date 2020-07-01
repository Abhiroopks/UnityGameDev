using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An explosion
/// </summary>
public class Explosion : MonoBehaviour
{
    // cached for efficiency
    Animator anim;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        anim = GetComponent<Animator>();
    }
        
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // destroy the game object if the explosion has finished its animation
        // normalizedTime has an integer part an fractional part. Int part tells how many times the animation has played, 
        // frac is normalized time(0 to 1) of current play.

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0) {
            Destroy(gameObject);
        }

    }
}
