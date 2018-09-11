using UnityEngine;

// Don't destroy game object after loading next scene.
public class DontDestroyOnLoad : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Make sure that game object will not be destroyed after loading next scene.
    GameObject.DontDestroyOnLoad(this.gameObject);
  } // End of Start

  #endregion

} // End of DontDestroyOnLoad