using System.Collections;
using UnityEngine;

// Game manager.
public class GameManager:MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'GameManager' (Singelton pattern).
  public static GameManager Instance
  {
    get
    {
      return GameManager._instance;
    }
  }

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Player lives.
  [SerializeField]
  [Range(1,15)]
  [Tooltip("Player lives")]
  private int player_lives = 3;
  // Wave duration time (in seconds).
  [SerializeField]
  [Range(5.0F,120.0F)]
  [Tooltip("Wave duration time (in seconds)")]
  private float wave_duration = 30.0F;
  // Wave break duration time (in seconds).
  [SerializeField]
  [Range(1.0F,10.0F)]
  [Tooltip("Wave break duration time (in seconds)")]
  private float wave_break_duration = 7.0F;
  // Wave start wait duration time (in seconds).
  [SerializeField]
  [Range(1.0F,10.0F)]
  [Tooltip("Wave start wait duration time (in seconds)")]
  private float wave_start_wait = 3.0F;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'GameManager' (Singelton pattern).
  private static GameManager _instance;
  // Score.
  private int score = 0;
  // Flag if spawning of hazards is enabled.
  private bool is_spawning_enabled = false;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // TO_DO:
  public void OnHazardDestroy(Hazard hazard)
  {
    // increase score
  } // End of OnHazardDestroy 

  // TO_DO:
  public void OnPlayerDestroy()
  {
    // increase score
  } // End of OnPlayerDestroy 

  // Return flag if spawning of hazards is enabled.
  public bool IsSpawningEnabled()
  {
    return this.is_spawning_enabled;
  } // End of IsSpawningEnabled

  // Event - on player death.
  public void OnPlayerDeath()
  {
    // If player have lives.
    if(Instance.player_lives>0)
    {
      // Decrease lives.
      Instance.player_lives--;
      // TO_DO:
      
      // Actualize text.
      //Gui.Instance.LivesSet(Instance.player_lives);

      // Respawn player with delay.
      //Instance.player.Respawn(2.0F);
    }
    // If player don't have lives.
    else
    {
      // Load lose screen.
      LevelManager.Instance.SceneLoad(LevelManager.Scenes.LOSE,1.0F);
    }
  } // End of OnPlayerDeath

  // Event - on score increase.
  public void ScoreIncrease(int val)
  {
    // Actualize score.
    Instance.score += val;
    // TO_DO:
    // Actualize text.
    //Gui.Instance.ScoreSet(Instance.score);
  } // End of ScoreIncrease

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Awake (used to initialize any variables or game state before the game starts).
  private void Awake()
  {
    if(GameManager._instance==null)
    {
      GameManager._instance=this;
    }
    else
    {
      // Destroy old instance game object.
      Destroy(Instance.gameObject);
      // Save new instance.
      GameManager._instance=this;
    }
  } // End of Awake

  // Initialize.
  private void Start()
  {
    // Make sure that game object will not be destroyed after loading next scene.
    GameObject.DontDestroyOnLoad(Instance.gameObject);
  } // End of Start

  // Event - on level was loaded.
  private void OnLevelWasLoaded(int level)
  {
    // TO_DO:
    // Set GUI values.
    //Gui.Instance.LivesSet(Instance.player_lives);
    //Gui.Instance.ScoreSet(Instance.score);
    // If first level.
    if(LevelManager.Instance.CurLvlGet()==LevelManager.Lvls.Lvl_01)
    {
      // Enable GUI camera.
      GameObject.FindGameObjectWithTag("gui_camera").GetComponent<Camera>().enabled=true;
    }
    // Manage hazards and enemies waves.
    StartCoroutine(WaveManage());
  } // End of OnLevelWasLoaded

  // Manage hazards and enemies waves.
  private IEnumerator WaveManage()
  {
    // Wait for seconds.
    yield return new WaitForSeconds(this.wave_start_wait);
    // Loop.
    while(true)
    {
      // Enable spawning.
      this.is_spawning_enabled=true;
      // Wait for seconds.
      yield return new WaitForSeconds(this.wave_duration);
      // Enable spawning.
      this.is_spawning_enabled=false;
      // Wait for seconds.
      yield return new WaitForSeconds(this.wave_break_duration);
    }
  } // End of WaveManage

  #endregion

} // End of GameManager