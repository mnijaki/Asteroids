using UnityEngine;

// Scroll backround.
public class BackgroundScroller : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Scroll speed of background.
  [SerializeField]
  [Range(0.0F,50.0F)]
  [Tooltip("Scroll speed of background")]
  float scroll_speed = 1.0F;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Start position of background.
  private Vector3 start_pos;
  // Vertical size of background.
  private float background_size_vert;
  // Stars particle systems.
  private ParticleSystem stars_close;
  private ParticleSystem stars_distant;
  // Starting speed of stars particle system simulations.
  private float stars_close_start_sim_speed;
  private float stars_distant_start_sim_speed;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Get start position of background.
    this.start_pos = this.transform.position;
    // Get background size.
    this.background_size_vert = this.transform.localScale.y;
    // Get stars particle systems.
    this.stars_close = GameObject.FindGameObjectWithTag("stars").GetComponentsInChildren<ParticleSystem>()[0];
    this.stars_distant = GameObject.FindGameObjectWithTag("stars").GetComponentsInChildren<ParticleSystem>()[1];
    // Get starting speed of stars particle systems simulations.
    this.stars_close_start_sim_speed = this.stars_close.main.simulationSpeed;
    this.stars_distant_start_sim_speed = this.stars_distant.main.simulationSpeed;
    // Set simulations speed of particle systems.
    this.stars_close.playbackSpeed = this.stars_close_start_sim_speed * this.scroll_speed;
    this.stars_distant.playbackSpeed = this.stars_distant_start_sim_speed * this.scroll_speed;
  } // End of Start
	
	// Update is called once per frame
	private void Update()
  {
    // Compute new displacement factor of background ('Mathf.Repeat()' is similar to the modulo operator but it 
    // works with floating point numbers).
    float displacement_factor = Mathf.Repeat(Time.timeSinceLevelLoad*this.scroll_speed,this.background_size_vert);
    // Move background.
    this.transform.position = this.start_pos + Vector3.back * displacement_factor;
  } // End of Update

  // MN:TO_DO:Commented because current implementation could lead to some bugs
  // (values of particle system could not be reseted correctly). 
  //// This function is called when the script is loaded or a value is changed in the inspector 
  //// (Called in the editor only).
  //private void OnValidate()
  //{
  //  // If stars partilce systems was not yet found.
  //  if(this.stars_close==null)
  //  {
  //    // Get stars particle systems.
  //    this.stars_close = GameObject.FindGameObjectWithTag("stars").GetComponentsInChildren<ParticleSystem>()[0];
  //    this.stars_distant = GameObject.FindGameObjectWithTag("stars").GetComponentsInChildren<ParticleSystem>()[1];
  //    // Get starting speed of stars particle systems simulations.
  //    this.stars_close_start_sim_speed = this.stars_close.main.simulationSpeed;
  //    this.stars_distant_start_sim_speed = this.stars_distant.main.simulationSpeed;
  //  }
  //  // Set simulations speed of particle systems.
  //  this.stars_close.playbackSpeed = this.stars_close_start_sim_speed * this.scroll_speed;
  //  this.stars_distant.playbackSpeed = this.stars_distant_start_sim_speed * this.scroll_speed;
  //}

  #endregion

} // End of BackgroundScroller