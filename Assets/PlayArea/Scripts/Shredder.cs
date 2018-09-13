using UnityEngine;

// Shredder.
public class Shredder : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // On collision.
  private void OnTriggerEnter(Collider other)
  {
    // Mark object associated with collider to be destroyed (will be destroyed on the next frame).
    Destroy(other.gameObject);
  } // End of OnTriggerEnter

  #endregion

} // End of Shredder