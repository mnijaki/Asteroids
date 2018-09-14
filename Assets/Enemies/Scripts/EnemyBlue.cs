using UnityEngine;

// Enemy blue.
public class EnemyBlue : MonoBehaviour
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
  // Enemy destroy effect.
  [SerializeField]
  [Tooltip("Enemy destroy effect")]
  private GameObject destroy_vfx;
  // Weapon type.
  [SerializeField]
  [Tooltip("Weapon type")]
  private WeaponType weapon_type;
  // End position of weapon.
  [SerializeField]
  [Tooltip("End position of weapon")]
  private Transform weapon_end;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Boundries of the game.
  private float min_hor;
  private float max_hor;
  private float min_vert;
  private float max_vert;
  // Rigidbody.
  Rigidbody rbdy;
  // Hazards parent.
  private Transform projectiles_parent;
  // Reference to the audio source which will play shooting sound effect.
  private AudioSource audio_source;
  // Time when player will be allowed to fire again, after firing.
  private float next_fire_time;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // TO_DO
    // Set boundries.
    BoundriesSet();
    // Get rigitbody.
    this.rbdy=this.GetComponent<Rigidbody>();
    // Set velocity.
    // TO_DO: popraw
    this.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-0.3F,0.3F),0.0F,-1.0F) * this.ship_speed_vert;
    // Get projectiles parent.
    this.projectiles_parent=GameObject.FindGameObjectWithTag("enemies_projectiles").transform;
    // Get audio source.
    this.audio_source = GetComponent<AudioSource>();

    InvokeRepeating("Fire",0.0F,this.weapon_type.fire_rate);
  } // End of Start

  // Set boundries.
  private void BoundriesSet()
  {
    // Calculate distance between camera and player.
    float distance = this.transform.position.z - Camera.main.transform.position.z;
    // Get left upper corner.
    Vector3 corner = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
    // Set minimum horizonat and vertical values.
    this.min_hor=corner.x+this.ship_padding_hor-10;
    this.min_vert=corner.z+this.ship_padding_vert;
    // Get right down corner.
    corner=Camera.main.ViewportToWorldPoint(new Vector3(1,1,distance));
    // Set maximum horizonat and vertical values.
    this.max_hor=corner.x-this.ship_padding_hor;
    this.max_vert=corner.z-this.ship_padding_vert;
  } // End of BoundriesSet

  // On collision.
  private void OnTriggerEnter(Collider other)
  {
    // If enemy didn't colided with projectile and player then exit from function.
    if((other.gameObject.layer!=LayerMask.NameToLayer("projectiles"))&&
       (other.gameObject.layer!=LayerMask.NameToLayer("player")))
    {
      return;
    }
    //TO_DO: sound, healt, effect, points, 
    // Decrease health.
    //HealthDown(projectile.DamageGet());

    // Instantiate destroy effect.
    Instantiate(this.destroy_vfx,this.transform.position,this.transform.rotation);
    // Destroy object.
    Destroy(this.gameObject);
  } // End of OnTriggerEnter

  // Fire weapon.
  private void Fire()
  {
    
    // Play fire audio.
    this.audio_source.Play();
    // Instantiate projectile.
    
    Instantiate(this.weapon_type.projectile,this.weapon_end.position,this.weapon_end.rotation,this.projectiles_parent);


    // TO_DO:add burst fire managing.
    // Actualize ammo left.
    // AmmoLeftAct(1);
  } // End of Fire

  #endregion

} // End of EnemyBlue