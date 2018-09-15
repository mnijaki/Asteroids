using System.Collections;
using UnityEngine;

// Enemy.
public class Enemy : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Horizontal padding of ship (used for clamping boundries).
  [SerializeField]
  [Range(0.0F,5.0F)]
  [Tooltip("Horizontal padding of ship (used for clamping boundries)")]
  private float ship_padding_hor = 2.0F;
  // Vertical speed of ship.
  [SerializeField]
  [Range(0.0F,100.0F)]
  [Tooltip("Vertical speed of ship")]
  private float ship_speed_vert = 2.0F;
  // Dodge speed.
  [SerializeField]
  [Range(0.0F,1000.0F)]
  [Tooltip("Dodge speed")]
  private float dodge_speed = 10.0F;
  // Dodge minimum range.
  [SerializeField]
  [Range(-10.0F,10.0F)]
  [Tooltip("Dodge minimum range")]
  private float dodge_min_range = -3.0F;
  // Dodge maximum range.
  [SerializeField]
  [Range(1.0F,10.0F)]
  [Tooltip("Dodge maximum range")]
  private float dodge_max_range = 3.0F;
  // Minimum dodge duration.
  [SerializeField]
  [Range(0.0F,10.0F)]
  [Tooltip("Minimum dodge duration")]
  private float dodge_min_duration = 3.0F;
  // Maximum dodge duration.
  [SerializeField]
  [Range(0.0F,10.0F)]
  [Tooltip("Maximum dodge duration")]
  private float dodge_max_duration = 3.0F;
  // Minimum pause between dodges.
  [SerializeField]
  [Range(0.0F,10.0F)]
  [Tooltip("Minimum pause between dodges")]
  private float dodge_min_pause = 1.0F;
  // Maximum pause between dodges.
  [SerializeField]
  [Range(0.0F,10.0F)]
  [Tooltip("Maximum pause between dodges")]
  private float dodge_max_pause = 1.0F;
  // Ship tilt factor.
  [SerializeField]
  [Range(0.0F,100.0F)]
  [Tooltip("Ship tilt factor")]
  public float ship_tilt_factor = 2.0F;
  // Weapon type.
  [SerializeField]
  [Tooltip("Weapon type")]
  private WeaponType weapon_type;
  // End position of weapon.
  [SerializeField]
  [Tooltip("End position of weapon")]
  private Transform weapon_end;
  // Wait time before first fire.
  [SerializeField]
  [Range(0.0F,10.0F)]
  [Tooltip("Wait time before first fire")]
  private float wait_time_before_first_fire = 2.0F;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Rigidbody.
  Rigidbody rbdy;
  // Reference to the audio source which will play shooting sound effect.
  private AudioSource audio_source;
  // Projectiles parent.
  private Transform projectiles_parent;
  // Health.
  private HazardHealth health;
  // Boundries of the game.
  private float min_hor;
  private float max_hor;
  // Initial target 'x' value of the ship.
  private float init_target_x;
  // Target 'x' value of the ship dodge maneuver.
  private float target_x;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Get rigitbody.
    this.rbdy=this.GetComponent<Rigidbody>();
    // Get audio source.
    this.audio_source = this.GetComponent<AudioSource>();
    // Get projectiles parent.
    this.projectiles_parent=GameObject.FindGameObjectWithTag("projectiles").transform;
    // Get health.
    this.health=this.GetComponent<HazardHealth>();
    // Set boundries.
    BoundriesSet();
    // Get initial target x.
    this.init_target_x = this.transform.position.x;
    // Set velocity.
    this.GetComponent<Rigidbody>().velocity = Vector3.back * this.ship_speed_vert;
    // Fire.
    InvokeRepeating("Fire",this.wait_time_before_first_fire,this.weapon_type.fire_rate);
    // Start dodge coroutine.
    StartCoroutine(Dodge());
  } // End of Start

  // Physics calculations.
  private void FixedUpdate()
  {
    // Set ship velocity.
    this.rbdy.velocity = new Vector3(Mathf.MoveTowards(this.rbdy.velocity.x,this.target_x,Time.deltaTime*this.dodge_speed),
                                     this.rbdy.velocity.y,
                                     this.rbdy.velocity.z);
    // Clamp position.
    this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x,this.min_hor,this.max_hor),
                                          this.transform.position.y,
                                          this.transform.position.z);
    // Set tilt.
    this.rbdy.rotation = Quaternion.Euler(0.0F,0.0F,this.rbdy.velocity.x*-this.ship_tilt_factor);
  } // End of FixedUpdate

  // Dodge.
  private IEnumerator Dodge()
  {
    // Loop.
    while(true)
    {
      // Set target 'x' value of the ship. 
      this.target_x = Random.Range(this.dodge_min_range,this.dodge_max_range);
      // Wait for random dodge duration.
      yield return new WaitForSeconds(Random.Range(this.dodge_min_duration,this.dodge_max_duration));
      // Reset target 'x' value.
      this.target_x=this.init_target_x;
      // Wait for random pause time between dodges.
      yield return new WaitForSeconds(Random.Range(this.dodge_min_pause,this.dodge_max_pause));
    }
  } // End of Dodge

  // Set movement boundries.
  private void BoundriesSet()
  {
    // Calculate distance between camera and enemy.
    float distance = this.transform.position.z - Camera.main.transform.position.z;
    // Get left upper corner.
    Vector3 corner = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
    // Set minimum horizonat value.
    this.min_hor=corner.x+this.ship_padding_hor;
    // Get right upper corner.
    corner=Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
    // Set maximum horizonat value.
    this.max_hor=corner.x-this.ship_padding_hor;
  } // End of BoundriesSet

  // On collision.
  private void OnTriggerEnter(Collider other)
  {
    // If enemy didn't colided with player and player projectiles then exit from function.
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

  // Fire weapon.
  private void Fire()
  {
    // Play fire audio.
    this.audio_source.Play();
    // If there is fire effect.
    if(this.weapon_type.fire_vfx != null)
    {
      // Instantiate effect.
      Instantiate(this.weapon_type.fire_vfx,this.weapon_end.position,this.transform.rotation);
    }
    // Instantiate projectile.
    Instantiate(this.weapon_type.projectile,this.weapon_end.position,Quaternion.identity,this.projectiles_parent);
  } // End of Fire

  #endregion

} // End of Enemy