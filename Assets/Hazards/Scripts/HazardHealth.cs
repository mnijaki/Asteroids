using UnityEngine;

// Hazard health.
public class HazardHealth : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Health.
  [SerializeField]
  [Range(10,5000)]
  [Tooltip("Health of hazard")]
  private int health = 10;
  // Hazard hit clip.
  [SerializeField]
  [Tooltip("Hazard hit clip")]
  private AudioClip hit_clip;
  // Hazard destroy clip.
  [SerializeField]
  [Tooltip("Hazard destroy clip")]
  private AudioClip destroy_clip;
  // Hazard hit particle system.
  [SerializeField]
  [Tooltip("Hazard hit particle system")]
  private ParticleSystem hit_vfx;
  // Hazard death particle system.
  [SerializeField]
  [Tooltip("Hazard death particle system")]
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
      // Destroy hazard.
      HazardDestroy();
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

  // Destroy hazard.
  public void HazardDestroy()
  {
    // Instantiate effect.
    Instantiate(this.destroy_vfx,this.transform.position,this.transform.rotation);
    // Play clip.
    MusicManager.Instance.ClipPlayAtPoint(this.transform.position,0.0F,0.1F,this.destroy_clip);
    // Send message to 'GameManager'.
    GameManager.Instance.OnHazardDestroy(this.gameObject.GetComponent<Hazard>());
    // Destroy object.
    Destroy(this.gameObject);
  } // End of HazardDestroy

  #endregion

} // End of HazardHealth