using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projectile.
public class ProjectileEnemy : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Projectile type.
  [Tooltip("Projectile type")]
  public ProjectileType projectile_type;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Set velocity.
    this.GetComponent<Rigidbody>().velocity = Vector3.back * this.projectile_type.velocity;
  } // End of Start

  // On collision.
  private void OnTriggerEnter(Collider other)
  {
    // If projectile didn't colided with player then exit from function.
    if(other.gameObject.layer!=LayerMask.NameToLayer("Player"))
    {
      return;
    }

    // TO_DO:collision matrix
    //TO_DO: sound, effect, 

    // If there is destroy clip.
    if(this.projectile_type.destroy_clip != null)
    {
      // Play sound (used own 'ClipPlayAtPoint' method, becoause default unity method won't give access 
      // to spatial blend and other settings).
      MusicManager.Instance.ClipPlayAtPoint(Camera.main.transform.position,0.0F,this.projectile_type.destroy_clip);
    }
    // Destroy game object.
    Destroy(this.gameObject);
  } // End of OnTriggerEnter

  #endregion

} // End of ProjectileEnemy
