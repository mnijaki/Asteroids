using UnityEngine;

// Asteroid.
public class Asteroid : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Asteroid destroy effect.
  [SerializeField]
  [Tooltip("Asteroid destroy effect")]
  private GameObject destroy_vfx;
  // Asteroid velocity.
  [Range(1,500)]
  [Tooltip("Asteroid velocity")]
  public int velocity = 10;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Angular speed.
  [SerializeField]
  [Range(0.0F,10.0F)]
  [Tooltip("Angular speed")]
  public float angular_speed = 5.0F;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Set random angular speed (remember to set 'AngularDrag' in inspector to 0 - turns off resist of angular velocity).
    this.GetComponent<Rigidbody>().angularVelocity=Random.insideUnitSphere*this.angular_speed;
    // Set velocity.
    this.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-0.3F,0.3F),0.0F,-1.0F) * this.velocity;
  } // End of Start

  // On collision.
  private void OnTriggerEnter(Collider other)
  {
    // If asteroid didn't colided with projectile and player then exit from function.
    if((other.gameObject.layer!=LayerMask.NameToLayer("projectiles"))&&
       (other.gameObject.layer!=LayerMask.NameToLayer("player")))
    {
      return;
    }
    //TO_DO: sound, healt, effect, points, should also interact with player
    // Decrease health.
    //HealthDown(projectile.DamageGet());

    // Instantiate destroy effect.
    Instantiate(this.destroy_vfx,this.transform.position,this.transform.rotation);
    // Destroy object.
    Destroy(this.gameObject);
  } // End of OnTriggerEnter

  #endregion

} // End of Asteroid