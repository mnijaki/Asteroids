using UnityEngine;

// Player.
public class Player:MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Horizontal padding of player ship (used for clamping boundries).
  [SerializeField]
  [Range(0.0F,5.0F)]
  [Tooltip("Horizontal padding of player ship (used for clamping boundries)")]
  private float ship_padding_hor = 2.0F;
  // Vertical padding of player ship (used for clamping boundries).
  [SerializeField]
  [Range(0.0F,5.0F)]
  [Tooltip("Vertical padding of player ship (used for clamping boundries)")]
  private float ship_padding_vert = 2.5F;
  // Horizontal speed of player ship.
  [SerializeField]
  [Range(0.0F,1000.0F)]
  [Tooltip("Horizontal speed of player ship")]
  private float ship_speed_hor = 600.0F;
  // Vertical speed of player ship.
  [SerializeField]
  [Range(0.0F,1000.0F)]
  [Tooltip("Vertical speed of player ship")]
  private float ship_speed_vert = 400.0F;
  // Ship tilt factor.
  [SerializeField]
  [Range(0.0F, 10.0F)]
  [Tooltip("Ship tilt factor")]
  public float ship_tilt_factor = 3.0F;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Rigidbody.
  Rigidbody rbdy;
  // Health.
  private PlayerHealth health;
  // Boundries of the game.
  private float min_hor;
  private float max_hor;
  private float min_vert;
  private float max_vert;

  #endregion
  

  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods.                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Get rigitbody.
    this.rbdy=this.GetComponent<Rigidbody>();
    // Get health.
    this.health=this.GetComponent<PlayerHealth>();
    // Set boundries.
    BoundriesSet();
  } // End of Start

  // FixedUpdate (used for physics calculations).
  private void FixedUpdate()
  {
    // Move player ship.
    PlayerMove();
  } // End of FixedUpdate

  // Set boundries.
  private void BoundriesSet()
  {
    // Calculate distance between camera and player.
    float distance = this.transform.position.z - Camera.main.transform.position.z;
    // Get left upper corner.
    Vector3 corner = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
    // Set minimum horizonat and vertical values.
    this.min_hor=corner.x+this.ship_padding_hor;
    this.min_vert=corner.z+this.ship_padding_vert;
    // Get right down corner.
    corner=Camera.main.ViewportToWorldPoint(new Vector3(1,1,distance));
    // Set maximum horizonat and vertical values.
    this.max_hor=corner.x-this.ship_padding_hor;
    this.max_vert=corner.z-this.ship_padding_vert;
  } // End of BoundriesSet

  // Movement.
  private void PlayerMove()
  {
    // Add velocity to ship.
    this.rbdy.velocity = new Vector3(Input.GetAxis("Horizontal")*this.ship_speed_hor,
                                     this.rbdy.velocity.y,
                                     Input.GetAxis("Vertical")*this.ship_speed_vert) * Time.deltaTime;
    // Clamp ship position to game boundries.
    this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x,this.min_hor,this.max_hor),
                                          this.transform.position.y,
                                          Mathf.Clamp(this.transform.position.z,this.min_vert,this.max_vert));
    // Tilt ship depending of how fast ship is moving.
    this.transform.rotation = Quaternion.Euler(0.0F,0.0F,this.rbdy.velocity.x*-this.ship_tilt_factor);
  } // End of PlayerMove

  // On collision.
  private void OnTriggerEnter(Collider other)
  {
    // If player didn't colided with hazard and hazard projectile then exit from function.
    if((other.gameObject.layer!=LayerMask.NameToLayer("hazards"))&&
       (other.gameObject.layer!=LayerMask.NameToLayer("hazards_projectiles")))
    {
      return;
    }
    // If collision with hazard.
    if(other.gameObject.layer==LayerMask.NameToLayer("hazards"))
    {
      // Destroy player.
      this.health.PlayerDestroy();
    }
    // If not collision with hazard.
    else
    {
      // Decrease health.
      this.health.HealthDecrease(other.GetComponent<ProjectileEnemy>().projectile_type.damage);
    }
  } // End of OnTriggerEnter

  #endregion

} // End of Player