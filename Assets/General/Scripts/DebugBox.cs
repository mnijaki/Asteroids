using UnityEngine;

// Draw box around object transform.
public class DebugBox:MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Function only for purpose of debbuging area that will check if player is on the ground.
  private void OnDrawGizmos()
  {
    // Get boundry points.
    Vector3 left_upper = new Vector3(this.transform.position.x-this.transform.localScale.x/2,
                                     0.0F,
                                     this.transform.position.z+this.transform.localScale.z/2);
    Vector3 right_upper = new Vector3(left_upper.x+this.transform.localScale.x,
                                      0.0F,
                                      left_upper.z);
    Vector3 right_bottom = new Vector3(left_upper.x+this.transform.localScale.x,
                                       0.0F,
                                       left_upper.z-this.transform.localScale.z);
    Vector3 left_bottom = new Vector3(left_upper.x,
                                      0.0F,
                                      left_upper.z-this.transform.localScale.z);
    // Draw box.
    Debug.DrawLine(left_upper,right_upper,Color.red);
    Debug.DrawLine(right_upper,right_bottom,Color.red);
    Debug.DrawLine(right_bottom,left_bottom,Color.red);
    Debug.DrawLine(left_bottom,left_upper,Color.red);
  } // End of OnDrawGizmos

  #endregion

} // End of DebugBox