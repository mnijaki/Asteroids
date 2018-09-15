using UnityEngine;

// Player health.
public class PlayerHealth : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Health.
  [SerializeField]
  [Range(100,500)]
  [Tooltip("Health of player")]
  private int health = 100;
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
  // Player death particle system.
  [SerializeField]
  [Tooltip("Player death particle system")]
  private ParticleSystem destroy_vfx;

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
    // If health < 1.
    if(this.health<1)
    {
      // Destroy player.
      PlayerDestroy();
    }
    // If health >= 1.
    else
    {
      // If there is hit effect.
      if(this.hit_vfx != null)
      {
        // Instantiate effect.
        Instantiate(this.hit_vfx,this.transform.position,this.transform.rotation);
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
    Instantiate(this.destroy_vfx,this.transform.position,this.transform.rotation);
    // Play clip.
    MusicManager.Instance.ClipPlayAtPoint(this.transform.position,0.0F,0.1F,this.destroy_clip);
    // Send message to 'GameManager'.
    GameManager.Instance.OnPlayerDestroy();
    // Destroy object.
    Destroy(this.gameObject);
  } // End of PlayerDestroy

  #endregion

} // End of PlayerHealth