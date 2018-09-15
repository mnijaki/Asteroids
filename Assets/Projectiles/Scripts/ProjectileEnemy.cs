﻿using UnityEngine;

// Projectile of enemy.
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
    if(other.gameObject.layer!=LayerMask.NameToLayer("player"))
    {
      return;
    }
    // If there is destroy effect.
    if(this.projectile_type.destroy_vfx != null)
    {
      // Instantiate effect.
      Instantiate(this.projectile_type.destroy_vfx,this.transform.position,this.transform.rotation);
    }
    // It there is destroy clip.
    if(this.projectile_type.destroy_clip != null)
    {
      // Play clip.
      MusicManager.Instance.ClipPlayAtPoint(this.transform.position,0.0F,0.1F,this.projectile_type.destroy_clip);
    }
    // Destroy object.
    Destroy(this.gameObject);
  } // End of OnTriggerEnter

  #endregion

} // End of ProjectileEnemy
