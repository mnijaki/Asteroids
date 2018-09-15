using UnityEngine;

// Asteroid.
public class Asteroid : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Asteroid vertical velocity.
  [Range(1,500)]
  [Tooltip("Asteroid vertical velocity")]
  public int vert_velocity = 10;
  // Asteroid angular speed.
  [SerializeField]
  [Range(0.0F,10.0F)]
  [Tooltip("Asteroid angular speed")]
  private float angular_speed = 5.0F;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Health.
  private HazardHealth health;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Get health.
    this.health=this.GetComponent<HazardHealth>();
    // Set random angular speed (remember to set 'AngularDrag' in inspector to 0 - turns off resist of angular velocity).
    this.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * this.angular_speed;
    // Set vertical velocity.
    this.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-0.3F,0.3F),0.0F,-1.0F) * this.vert_velocity;
  } // End of Start

  // On collision.
  private void OnTriggerEnter(Collider other)
  {
    // If asteroid didn't colided with player and player projectiles then exit from function.
    if((other.gameObject.layer!=LayerMask.NameToLayer("player"))&&
       (other.gameObject.layer!=LayerMask.NameToLayer("player_projectiles")))
    {
      return;
    }
    // If collision with player.
    if(other.gameObject.layer==LayerMask.NameToLayer("player"))
    {
      // Destroy hazard.
      this.health.HazardDestroy();
    }
    // If not collision with player.
    else
    {
      // Decrease health.
      this.health.HealthDecrease(other.GetComponent<ProjectilePlayer>().projectile_type.damage);
    }
  } // End of OnTriggerEnter

  #endregion

} // End of Asteroid