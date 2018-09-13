using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projectile.
public class Projectile : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Projectile type.
  [Tooltip("Projectile type")]
  public ProjectileType type;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Set velocity.
    this.GetComponent<Rigidbody>().velocity = this.transform.forward * this.type.velocity;
  } // End of Start

  // On collision.
  private void OnTriggerEnter(Collider other)
  {
    // MN:TO_DO:to powinno byc w enemy health
    // Increase score.
    //GameManager.Instance.ScoreIncrease(this.points);
    // decrease enemy health


    // Play sound (used own 'ClipPlayAtPoint' method, becoause default unity method won't give access 
    // to spatial blend and other settings).
    MusicManager.Instance.ClipPlayAtPoint(Camera.main.transform.position,0.0F,this.type.destroy_clip);
    // Destroy game object.
    Destroy(this.gameObject);
  } // End of OnTriggerEnter

  #endregion

} // End of Projectile
