using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields          
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Spawn rate of spawner.
  [SerializeField]
  [Range(0.0F,50.0F)]
  [Tooltip("Spawn rate of spawner")]
  private float spawn_rate = 1.0F;
  // Array of hazards.
  [SerializeField]
  [Tooltip("Array of hazards")]
  public Hazard[] hazards;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields          
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Hazards parent.
  private Transform hazards_parent;
  // Time since last spawn of hazard.
  private float time_since_last_spawn = 0.0F;
  // Last random spawn value.
  private float last_random;
  // Min and max horizontal value.
  private float min_hor;
  private float max_hor;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // Find hazards parent.
    this.hazards_parent=GameObject.FindGameObjectWithTag("hazards_parent").transform;
    // Set initial random value.
    this.last_random=Random.Range(0.0F,4.0F);
    // Get boundry points.
    this.min_hor = this.transform.position.x - this.transform.localScale.x/2;
    this.max_hor = this.min_hor + this.transform.localScale.x;
  } // End of Start

  // Update (called once per frame).
  private void Update()
  {    
    // Loop over array of aviable hazards.
    foreach(Hazard hazard in this.hazards)
    {
      // If spawning of enemies is disabled then exit from function.
      if(!GameManager.Instance.IsSpawningEnabled())
      {
        return;
      }
      // If it is time to spawn hazard.
      if(IsTimeToSpawn(hazard))
      {
        // Instantiate hazard.
        Instantiate(hazard,
                    new Vector3(Random.Range(this.min_hor,this.max_hor),this.transform.position.y,this.transform.position.z),
                    this.transform.rotation,
                    this.hazards_parent);
      }
    }
  } // End of Update

  // Return information if it is time to spawn hazard.
  private bool IsTimeToSpawn(Hazard hazard)
  {
    // If it is time to spawn hazard.
    if(this.last_random < this.time_since_last_spawn)
    {
      // Reset last spawn time.
      this.time_since_last_spawn=0;
      // Reset last random value.
      this.last_random=Random.Range(0.0F,hazard.seconds_to_spawn*this.spawn_rate*2);
      // Return true.
      return true;
    }
    else
    {
      // Actualize last spawn time.
      this.time_since_last_spawn = Time.deltaTime + this.time_since_last_spawn;
      // Return false.
      return false;
    }
  } // End of IsTimeToSpawn

  #endregion

} // End of HazardSpawner