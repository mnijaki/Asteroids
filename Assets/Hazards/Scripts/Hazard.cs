using UnityEngine;

// Hazard.
public class Hazard : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields          
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Time in seconds to spawn hazard.
  [Range(0.5F,300.0F)]
  [Tooltip("Time in seconds to spawn hazard")]
  public float seconds_to_spawn = 5.0F;

  #endregion

} // End of Hazard