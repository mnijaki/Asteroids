using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shake camera.
public class CameraShake : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Default shake duration.
  [SerializeField]
  [Range(0.1F,10.0F)]
  [Tooltip("Default shake duration")]
  private float def_duration = 1.0F;
  // Default shake magnitude.
  [SerializeField]
  [Range(0.1F,10.0F)]
  [Tooltip("Default shake magnitude")]
  private float def_magnitude = 0.2F;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Flag if shaking is happening.
  private bool is_shaking = false;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Start own shake of player camera.
  public void ShakeOwnStart(float duration,float magnitude)
  {
    // If shaking is happening.
    if(this.is_shaking)
    {
      // Exit from function.
      return;
    }
    // Shake player camera.
    StartCoroutine(Shake(duration,magnitude));
  } // End of ShakeOwnStart

  // Start default shake of player camera.
  public void ShakeDefStart()
  {
    // If shaking is happening.
    if(this.is_shaking)
    {
      // Exit from function.
      return;
    }
    // Shake player camera.
    StartCoroutine(Shake(this.def_duration,this.def_magnitude));
  } // End of ShakeDefStart

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Shake player camera.
  private IEnumerator Shake(float duration,float magnitude)
  {
    // Change flag.
    this.is_shaking=true;
    // Starting position of camera.
    Vector3 start_pos = this.transform.localPosition;
    // Offset variables.
    float x;
    float y;
    float z;
    // Loop over duration time.
    while(duration > 0.0F)
    {
      // Compute offset.
      x = start_pos.x + (Random.Range(-1.0F,1.0F)*magnitude);
      y = start_pos.y + (Random.Range(-1.0F,1.0F)*magnitude);
      z = start_pos.z + (Random.Range(-1.0F,1.0F)*magnitude);
      // Set offset.
      this.transform.localPosition=new Vector3(x,y,z);
      // Decrease duration.
      duration-=Time.deltaTime;
      // Yield.
      yield return null;
    }
    // Reset camera to starting position.
    this.transform.localPosition=start_pos;
    // Change flag.
    this.is_shaking=false;
  } // End of Shake

  #endregion

} // End of CameraShake