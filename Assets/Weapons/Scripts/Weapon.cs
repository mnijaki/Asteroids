using System.Collections;
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

  // Reference to the audio source which will play shooting sound effect.
  private AudioSource audio_source;
  // Time when player will be allowed to fire again, after firing.
  private float next_fire_time;
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
    // Get audio source.
    this.audio_source = GetComponent<AudioSource>();
    // Equip weapon.
    WeaponEquip(this.weapon_type);
  } // End of Start

  // Update (called once per frame).
  private void Update()
  {
    // If the player has pressed the fire button and if enough time has elapsed since he last fired.
    if((Input.GetButtonDown("Fire1")) && (Time.time>this.next_fire_time))
    {
      // Fire weapon.
      Fire();
    }
  } // End of Update

  // Equip weapon.
  private void WeaponEquip(WeaponType weapon_type)
  {
    // TO_DO: equiping weapon shoold change 'this.weapon_type'
    //        should be array of aviable weapons    
    // Set ammo left.
    AmmoLeftSet(this.weapon_type.initial_ammo);
    // Set weapon name.
   // HudIcons.Instance.WeaponNameSet(this.weapon_type.weapon_name);
  } // End of WeaponEquip

  // Set ammo left.
  private void AmmoLeftSet(int ammo_left)
  {
    // Set ammo left.
    this.ammo_left=ammo_left;
    // Set ammo left in HUD.
    //HudIcons.Instance.AmmoLeftSet(this.ammo_left);
  } // End of AmmoLeftSet

  // Actualize ammo left.
  private void AmmoLeftAct(int shells_fired)
  {
    // Set ammo left.
    this.ammo_left-=shells_fired;
    // If ammo belove 0 then set is as 0;
    if(this.ammo_left<0)
    {
      this.ammo_left=0;
    }
    // Set ammo left in HUD.
    HudIcons.Instance.AmmoLeftSet(this.ammo_left);
  } // End of AmmoLeftAct

  // Fire weapon.
  private void Fire()
  {
    // If no ammo left.
    if(this.ammo_left==0)
    {
      // TO_DO: jam sound
      // Exit from function.
      return;
    }
    Debug.Log("x4");
    // Play fire audio.
    this.audio_source.Play();
    // Instantiate projectile.
    Instantiate(this.weapon_type.projectile,this.transform);
    // Update the time when player can fire next time.
    this.next_fire_time = Time.time + this.weapon_type.fire_rate;    
    

    // TO_DO:add burst fire managing.
    // Actualize ammo left.
   // AmmoLeftAct(1);
  } // End of Fire

  #endregion

} // End of Weapon