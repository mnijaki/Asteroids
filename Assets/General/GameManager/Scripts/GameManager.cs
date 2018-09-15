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

  // Initial player lives.
  [SerializeField]
  [Range(1,15)]
  [Tooltip("Initial player lives")]
  private int init_player_lives = 3;
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
  // Player prefab.
  [SerializeField]
  [Tooltip("player prefab")]
  private GameObject player_prefab;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'GameManager' (Singelton pattern).
  private static GameManager _instance;
  // Score.
  private int score = 0;
  // Player lives.
  private int player_lives = 0;
  // Level time.
  private float lvl_time = 90.0F;
  // Flag if spawning of hazards is enabled.
  private bool is_spawning_enabled = false;
  // Player.
  private GameObject player;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // TO_DO:
  public void OnHazardDestroy(Hazard hazard)
  {
    // Increase score.
    ScoreIncrease(hazard.score_value);
  } // End of OnHazardDestroy 

  // Event - on player destroy.
  public void OnPlayerDestroy()
  {
    // If player have lives.
    if(Instance.player_lives>0)
    {
      // Decrease lives.
      Instance.player_lives--;
      // Actualize text.
      HudIcons.Instance.LivesSet(Instance.player_lives);
      // Respawn player.
      StartCoroutine(PlayerRespawn(3.0F));
    }
    // If player don't have lives.
    else
    {
      // Load lose screen.
      LevelManager.Instance.SceneLoad(LevelManager.Scenes.LOSE,3.0F);
    }
  } // End of OnPlayerDestroy 

  // Return flag if spawning of hazards is enabled.
  public bool IsSpawningEnabled()
  {
    return this.is_spawning_enabled;
  } // End of IsSpawningEnabled

  // Event - on score increase.
  public void ScoreIncrease(int val)
  {
    // Actualize score.
    Instance.score += val;
    // Actualize text.
    HudIcons.Instance.ScoreSet(Instance.score);
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
    // Set lives.
    Instance.player_lives = Instance.init_player_lives;
  } // End of Start

  // Update (called once per frame).
  void Update()
  {
    // If there is hud.
    if(HudIcons.Instance != null)
    {
      // Actualize progress.
      HudIcons.Instance.TimeSet(this.lvl_time-Time.timeSinceLevelLoad);
    }
  } // End of Update

  // Event - on level was loaded.
  private void OnLevelWasLoaded(int level)
  {
    // If not level then exit from function.
    if(LevelManager.Instance.CurLvlGet()==LevelManager.Lvls.NONE)
    {
      return;
    }
    // Instantiate player.
    this.player=Instantiate(this.player_prefab);
    // Prepare HUD values.
    HudIcons.Instance.TimePrepare(0.0F,this.lvl_time);
    HudIcons.Instance.HealthPrepare(0.0F,this.player.GetComponent<PlayerHealth>().InitHealthGet());
    // Set HUD values.
    HudIcons.Instance.TimeSet(this.lvl_time);
    HudIcons.Instance.LivesSet(Instance.player_lives);
    HudIcons.Instance.ScoreSet(Instance.score);
    // If first level.
    if(LevelManager.Instance.CurLvlGet()==LevelManager.Lvls.Lvl_01)
    {
      // Enable GUI camera.
      GameObject.FindGameObjectWithTag("hud_camera").GetComponent<Camera>().enabled=true;
    }
    // Manage hazards and enemies waves.
    StartCoroutine(WaveManage());
  } // End of OnLevelWasLoaded

  // Respawn player.
  private IEnumerator PlayerRespawn(float delay)
  {
    // Wait for seconds.
    yield return new WaitForSeconds(delay);
    // Instantiate player.
    this.player=Instantiate(this.player_prefab);
  } // End of PlayerRespawn

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