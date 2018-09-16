﻿using UnityEngine;

// Player health.
public class PlayerHealth : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Starting health.
  [SerializeField]
  [Range(100,500)]
  [Tooltip("Starting health of player")]
  private int init_health = 100;
  // Player hit clip.
  [SerializeField]
  [Tooltip("Player hit clip")]
  private AudioClip hit_clip;
  // Player destroy clip.
  [SerializeField]
  [Tooltip("Player destroy clip")]
  private AudioClip destroy_clip;
  // Player hit particle system.
  [SerializeField]
  [Tooltip("Player hit particle system")]
  private ParticleSystem hit_vfx;
  // Player destroy particle system.
  [SerializeField]
  [Tooltip("Player destroy particle system")]
  private ParticleSystem destroy_vfx;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Current health.
  private int health;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods       
  // ---------------------------------------------------------------------------------------------------------------------
  #region  

  // Decrease health.
  public void HealthDecrease(int val)
  {
    // Decrease health.
    this.health-=val;
    // Actualize HUD health.
    HudIcons.Instance.HealthSet(this.health);
    // If health < 1.
    if(this.health<1)
    {
      // Destroy player.
      PlayerDestroy();
    }
    // If health >= 1.
    else
    {
      // Start shake of player camera.
      GameObject.FindObjectOfType<CameraShake>().ShakeOwnStart(0.25F,0.5F);
      // If there is hit effect.
      if(this.hit_vfx != null)
      {
        // Instantiate effect.
        Instantiate(this.hit_vfx,this.transform.position,Quaternion.identity);
      }
      // It there is hit clip.
      if(this.hit_clip != null)
      {
        // Play clip.
        MusicManager.Instance.ClipPlayAtPoint(this.transform.position,0.0F,0.1F,this.hit_clip);
      }
    }
  } // End of HealthDecrease

  // Destroy player.
  public void PlayerDestroy()
  {
    // Instantiate effect.
    Instantiate(this.destroy_vfx,this.transform.position,Quaternion.identity);
    // Play clip.
    MusicManager.Instance.ClipPlayAtPoint(this.transform.position,0.0F,0.1F,this.destroy_clip);
    // Actualize HUD health.
    HudIcons.Instance.HealthSet(0);
    // Start default shake of player camera.
    GameObject.FindObjectOfType<CameraShake>().ShakeDefStart();
    // Send message to 'GameManager'.
    GameManager.Instance.OnPlayerDestroy();
    // Destroy object.
    Destroy(this.gameObject);
  } // End of PlayerDestroy

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods       
  // ---------------------------------------------------------------------------------------------------------------------
  #region  

  // Initialization.
  private void Start()
  {
    // Prepare HUD values.
    HudIcons.Instance.HealthPrepare(0.0F,this.init_health);
    // Set starting health.
    this.health=this.init_health;
    HudIcons.Instance.HealthSet(this.health);
  } // End of Start

  #endregion

} // End of PlayerHealth