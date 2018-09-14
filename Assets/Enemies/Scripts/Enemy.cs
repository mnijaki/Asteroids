using UnityEngine;

// Enemy.
public class Enemy : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields          
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Time in seconds to spawn enemy.
  [Range(0.5F,300.0F)]
  [Tooltip("Time in seconds to spawn enemy")]
  public float seconds_to_spawn = 2.0F;

  #endregion

} // End of Enemy