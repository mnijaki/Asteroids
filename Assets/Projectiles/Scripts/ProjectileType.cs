using UnityEngine;

// Projectile type.
[CreateAssetMenu(fileName = "New projectile type", menuName = "Projectile type")]
public class ProjectileType: ScriptableObject
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Name of projectile type.
  [Tooltip("Projectile name")]
  public string projectile_name;
  // Projectile damage.
  [Range(10,500)]
  [Tooltip("Projectile damage")]
  public int damage = 10;
  // Projectile range.
  [Range(10,500)]
  [Tooltip("Projectile range")]
  public int range = 500;  
  // Projectile velocity.
  [Range(10,500)]
  [Tooltip("Projectile velocity")]
  public int velocity = 10;
  // TO_DO:MN:Need to be implemented.
  // Hit force.
  [Range(0,500)]
  [Tooltip("Hit force")]
  public int hit_force = 100;
  // Projectile destroy clip.
  [Tooltip("Projectile destroy clip")]
  public AudioClip destroy_clip;
  // Projectile destroy effect.
  [SerializeField]
  [Tooltip("Projectile destroy effect")]
  public GameObject destroy_vfx;

  #endregion

} // End of ProjectileType