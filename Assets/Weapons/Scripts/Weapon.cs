using UnityEngine;

// Weapon.
public class Weapon:MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

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

  // Projectiles parent.
  private Transform projectiles_parent;
  // Reference to the audio source which will play fire clip.
  private AudioSource audio_source;
  // Time when player will be allowed to fire again, after firing.
  private float next_fire_time;
  // MN:TO_DO:Need to be implemented.
  // Ammo left.
  private int ammo_left;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Get projectiles parent.
    this.projectiles_parent=GameObject.FindGameObjectWithTag("projectiles").transform;
    // Get audio source.
    this.audio_source = GetComponent<AudioSource>();    
    // Equip weapon.
    WeaponEquip(this.weapon_type);
  } // End of Start

  // Update (called once per frame).
  private void Update()
  {
    // If the player has pressed fire button and if enough time has elapsed since he last fired.
    if((Input.GetButton("Fire1")) && (Time.timeSinceLevelLoad>this.next_fire_time))
    {
      // Fire weapon.
      Fire();
    }
  } // End of Update

  // Equip weapon.
  private void WeaponEquip(WeaponType weapon_type)
  {
    // MN:TO_DO:Need to be implemented.
    // * equiping weapon shoold change 'this.weapon_type'
    // * create array of aviable weapons    
    // Set ammo left.
    AmmoLeftSet(this.weapon_type.initial_ammo);
    // Set audio clip.
    this.audio_source.clip=this.weapon_type.fire_clip;
    // TO_DO:
    // Set weapon name.
    HudIcons.Instance.WeaponNameSet(this.weapon_type.weapon_name);
  } // End of WeaponEquip

  // Set ammo left.
  private void AmmoLeftSet(int ammo_left)
  {
    // Set ammo left.
    this.ammo_left=ammo_left;
    // TO_DO:
    // Set ammo left in HUD.
    HudIcons.Instance.AmmoLeftSet(this.ammo_left);
  } // End of AmmoLeftSet

  // Actualize ammo left.
  private void AmmoLeftAct(int shells_fired)
  {
    // Set ammo left.
    this.ammo_left-=shells_fired;
    // If ammo below 0 then set is as 0;
    if(this.ammo_left<0)
    {
      this.ammo_left=0;
    }
    // TO_DO:
    // Set ammo left in HUD.
    HudIcons.Instance.AmmoLeftSet(this.ammo_left);
  } // End of AmmoLeftAct

  // Fire weapon.
  private void Fire()
  {
    // If no ammo left.
    if(this.ammo_left==0)
    {
      // MN:TO_DO:Need to be implemented.
      // * jam sound

      // Exit from function.
      return;
    }
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
    // Update the time when player can fire next time.
    this.next_fire_time = Time.timeSinceLevelLoad + this.weapon_type.fire_rate;    
    // Actualize ammo left.
    AmmoLeftAct(1);
  } // End of Fire

  #endregion

} // End of Weapon