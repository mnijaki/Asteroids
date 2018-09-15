using UnityEngine;

// Hazard.
public class Hazard : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public fields          
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Score value for destroying hazard.
  [Range(10,1000)]
  [Tooltip("Score value for destroying hazard")]
  public int score_value = 10;
  // Time in seconds to spawn hazard.
  [Range(0.5F,300.0F)]
  [Tooltip("Time in seconds to spawn hazard")]
  public float seconds_to_spawn = 5.0F;

  #endregion

} // End of Hazard