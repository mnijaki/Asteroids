using UnityEngine;

// Weapon type.
[CreateAssetMenu(fileName = "New weapon type", menuName = "Weapon type")]
public class WeaponType : ScriptableObject
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Model.
  [Tooltip("Model")]
  public GameObject model;
  // TO_DO:MN:2018/08/20: Currently not used, mayby in futer this will be handy for changing position etc.
  // Transform.
  [Tooltip("Transform")]
  public Transform trans;
  // TO_DO:MN:2018/08/20: Need to be implemented.
  // Shell projectile.
  [Tooltip("Shell projectile")]
  public GameObject shell;
  // Name of weapon type.
  [Tooltip("Weapon name")]
  public string weapon_name = "Laser";
  // Weapon damage.
  [Range(10,500)]
  [Tooltip("Weapon damage")]
  public int damage = 10;
  // Weapon range.
  [Range(50,500)]
  [Tooltip("Weapon range")]
  public int range = 100;
  // Fire rate (number of shells fired per second).
  [Range(0.1F,5.0F)]
  [Tooltip("Fire rate (time in seconds how long firing one shell take)")]
  public float fire_rate = 0.1F;
  // TO_DO:MN:2018/08/20: Need to be implemented.
  // Flag if weapon is able to burst fire.
  [Range(0.1F,5.0F)]
  [Tooltip("Flag if weapon is able to burst fire")]
  public bool is_burst_able = false;
  // Weapon sound.
  public AudioClip sound;
  // TO_DO:MN:2018/08/20: Need to be implemented.
  // Shell velocity (in meters).
  [Range(50,500)]
  [Tooltip("Shell velocity (in meters)")]
  public int shell_velocity = 50;
  // TO_DO:MN:2018/08/20: Need to be implemented.
  // Clip size (0 means no clip).
  [Range(0,100)]
  [Tooltip("Clip size")]
  public int clip_size = 12;
  // TO_DO:MN:2018/08/20: Need to be implemented.
  // Initial ammo.
  [Range(1,1000)]
  [Tooltip("Initial ammo")]
  public int initial_ammo = 30;
  // TO_DO:MN:2018/08/20: Need to be implemented.
  // Recoil force. 
  [Range(1,50)]
  [Tooltip("Recoil force")]
  public int recoil_force = 1;
  // Hit force.
  [Range(1,500)]
  [Tooltip("Hit force")]
  public int hit_force = 100;
  // Beam draw duration (only needed for laser types weapons).
  [Range(0.1F,1.0F)]
  [Tooltip("Beam draw duration (only needed for laser types weapons)")]
  public float beam_draw_duration = 0.07F;
  // Flag if weapon can use scoped mode.
  [Tooltip("Flag if weapon can use scoped mode")]
  public bool is_scope_able = false;
  // Weapon weight (will influence player movement).
  [Range(1,50)]
  [Tooltip("Weapon weight (will influence player movement)")]
  public int weight = 1;

  #endregion

} // End of WeaponType