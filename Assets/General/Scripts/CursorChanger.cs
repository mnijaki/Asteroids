using UnityEngine;

// Cursor changer.
public class CursorChanger: MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // The texture that's going to replace the current cursor.
  [SerializeField]
  [Tooltip("The texture that's going to replace the current cursor")]
  private Texture2D texture;

  #endregion

  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Set cursor.
    Cursor.SetCursor(this.texture,Vector2.zero,CursorMode.Auto);
  } // End of Start

  #endregion

} // End of CursorChanger