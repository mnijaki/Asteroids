using UnityEngine;

// Draw box around object transform.
public class DebugBox : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields          
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Color of outline.
  [SerializeField]
  [Tooltip("Color of outline")]
  private Color color = Color.red;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Draw box around object transform.
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
    Debug.DrawLine(left_upper,right_upper,this.color);
    Debug.DrawLine(right_upper,right_bottom,this.color);
    Debug.DrawLine(right_bottom,left_bottom,this.color);
    Debug.DrawLine(left_bottom,left_upper,this.color);
  } // End of OnDrawGizmos

  #endregion

} // End of DebugBox