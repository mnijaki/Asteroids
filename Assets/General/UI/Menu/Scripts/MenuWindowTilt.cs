using UnityEngine;

// Tilt window (change it angle depending of mause position).
public class MenuWindowTilt : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Range of window tilt.
  [Tooltip("Range of window tilt.")]
  public Vector2 range = new Vector2(5.0F,3.0F);

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Transfor.
  private Transform trans;
  // Locla rotation.
  private Quaternion rot_local;
  // Temporary rotation.
  private Vector2 rot_tmp = Vector2.zero;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
	{
    // Get transform.
    this.trans = this.transform;
    // Get local rotation.
    this.rot_local = this.trans.localRotation;
  } // End of Start

  // Update (called once per frame).
  private void Update ()
	{
    // Get mouse position.
		Vector3 pos = Input.mousePosition;   
    // Compute half width and height of screen.
    float half_width = Screen.width * 0.5f;
		float half_height = Screen.height * 0.5f;
    // Compute 'x' and 'y'.
		float x = Mathf.Clamp((pos.x-half_width)/half_width, -1f, 1f);
		float y = Mathf.Clamp((pos.y-half_height)/half_height, -1f, 1f);
    // Usunig 'Time.unscaledDeltaTime' because in pause menu time is paused ('Time.scale=0'), but tilting of window
    // should still work.
    this.rot_tmp = Vector2.Lerp(this.rot_tmp,new Vector2(x,y), Time.unscaledDeltaTime*5f);
    // Actualize angle of window.
    this.trans.localRotation = this.rot_local * Quaternion.Euler(-this.rot_tmp.y * this.range.y,this.rot_tmp.x * this.range.x, 0f);
	} // End of Update

  #endregion

} // End of MenuWindowTilt