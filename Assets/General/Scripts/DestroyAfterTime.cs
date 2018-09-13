using UnityEngine;

// Destroy object after given time.
public class DestroyAfterTime : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Destroy time.
  [SerializeField]
  [Range(0.0F,5.0F)]
  [Tooltip("Destroy time")]
  private float destroy_time = 3.0F;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Mark object to be destroyed after given time.
    Destroy(this.gameObject,this.destroy_time);
  } // End of Start

  #endregion

} // End of DestroyAfterTime