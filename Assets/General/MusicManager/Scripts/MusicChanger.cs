using UnityEngine;

// Class that handle changing background music in the game.
public class MusicChanger : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Clip.
  [SerializeField]
  [Tooltip("Clip")]
  private AudioClip clip;
  // Delay time of clip play. 
  [SerializeField]
  [Range(0.0F,10.0F)]
  [Tooltip("Delay time of clip play")]
  private float delay=0.0F;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private methods
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Play clip.
    MusicManager.Instance.ClipPlay(this.clip,this.delay,true);
  } // End of Start

  #endregion

} // End of MusicChanger