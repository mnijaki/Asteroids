using UnityEngine;

// Weapon type.
[CreateAssetMenu(fileName = "New weapon type", menuName = "Weapon type")]
public class WeaponType : ScriptableObject
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Projectile.
  [Tooltip("Projectile")]
  public GameObject projectile;
  // Name of weapon type.
  [Tooltip("Weapon name")]
  public string weapon_name;
  // Fire rate (number of shells fired per second).
  [Range(0.1F,5.0F)]
  [Tooltip("Fire rate (time in seconds how long firing one shell take)")]
  public float fire_rate = 0.1F;
  // TO_DO: Need to be implemented.
  // Flag if weapon is able to burst fire.
  [Tooltip("Flag if weapon is able to burst fire")]
  public bool is_burst_able = false;
  // TO_DO:MN:Need to be implemented.
  // Clip size (0 means no clip).
  [Range(0,100)]
  [Tooltip("Clip size (0 means no clip)")]
  public int clip_size = 0;
  // Initial ammo.
  [Range(1,1000)]
  [Tooltip("Initial ammo")]
  public int initial_ammo = 500;
  // TO_DO:MN:Need to be implemented.
  // Recoil force. 
  [Range(0,50)]
  [Tooltip("Recoil force")]
  public int recoil_force = 1;
  // TO_DO:MN:Need to be implemented.
  // Weapon weight (will influence player movement).
  [Range(1,50)]
  [Tooltip("Weapon weight (will influence player movement)")]
  public int weight = 1;
  // Weapon fire audio clip.
  public AudioClip fire_clip;
  // TO_DO:MN:Need to be implemented.
  // Fire effect.
  [SerializeField]
  [Tooltip("Fire effect")]
  public GameObject fire_vfx;

  #endregion

} // End of WeaponType