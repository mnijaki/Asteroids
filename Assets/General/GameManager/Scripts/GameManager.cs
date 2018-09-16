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
  // Level duration time.
  [SerializeField]
  [Range(1.0F,360.0F)]
  [Tooltip("Level duration time")]
  private float lvl_time = 90.0F;
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
  private int player_lives;
  // Flag if spawning of hazards is enabled.
  private bool is_spawning_enabled = false;
  // Level timer coroutine.
  private Coroutine lvl_timer_cor;
  // Wave coroutine.
  private Coroutine wave_cor;
  // Respawn player coroutine.
  private Coroutine respawn_cor;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Message - on hazard destroy.
  public void OnHazardDestroy(Hazard hazard)
  {
    // Actualize score.
    Instance.score += hazard.score_value;
    // Actualize text.
    HudIcons.Instance.ScoreSet(Instance.score);
  } // End of OnHazardDestroy 

  // Message - on player destroy.
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
      Instance.respawn_cor = StartCoroutine(PlayerRespawn(3.0F));
    }
    // If player don't have lives.
    else
    {
      // Stop coroutines.
      StopCoroutine(Instance.lvl_timer_cor);
      // Load lose screen.
      LevelManager.Instance.SceneLoad(LevelManager.Scenes.LOSE,3.0F);
    }
  } // End of OnPlayerDestroy 

  // Return flag if spawning of hazards is enabled.
  public bool IsSpawningEnabled()
  {
    return Instance.is_spawning_enabled;
  } // End of IsSpawningEnabled

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

  // Event - on level was loaded.
  private void OnLevelWasLoaded(int level)
  {
    // Stop coroutines.
    if(Instance.wave_cor != null)
    {
      StopCoroutine(Instance.wave_cor);
    }
    if(Instance.respawn_cor != null)
    {
      StopCoroutine(Instance.respawn_cor);
    }
    // If level was not loaded then exit from function.
    if(LevelManager.Instance.CurLvlGet()==LevelManager.Lvls.NONE)
    {
      return;
    }
    // Instantiate player.
    Instantiate(Instance.player_prefab);
    // Prepare HUD values.
    HudIcons.Instance.TimePrepare(0.0F,Instance.lvl_time);
    // Set HUD values.
    HudIcons.Instance.TimeSet(Instance.lvl_time);
    HudIcons.Instance.LivesSet(Instance.player_lives);
    HudIcons.Instance.ScoreSet(Instance.score);
    // MN:TO_DO: Hotfix for HUD camera (want show hud in second level). 
    // Enable GUI camera.
    GameObject.FindGameObjectWithTag("hud_camera").GetComponent<Camera>().enabled=false;
    GameObject.FindGameObjectWithTag("hud_camera").GetComponent<Camera>().enabled=true;
    // Start level timer.
    Instance.lvl_timer_cor = StartCoroutine(LevelTimer());
    // Manage hazards and enemies waves.
    Instance.wave_cor = StartCoroutine(WaveManage());
  } // End of OnLevelWasLoaded

  // Level timer.
  private IEnumerator LevelTimer()
  {
    // Loop.
    while(true)
    {
      // Wait for seconds.
      yield return new WaitForSeconds(1);
      // Actualize progress.
      HudIcons.Instance.TimeSet(Instance.lvl_time-Time.timeSinceLevelLoad);
      // If time has ended then break loop.
      if(Instance.lvl_time-Time.timeSinceLevelLoad<0)
      {
        break;
      }
    }
    // Load next level.
    LevelManager.Instance.LvlLoadNext(0.0F,true);
  } // End of LevelTimer

  // Respawn player.
  private IEnumerator PlayerRespawn(float delay)
  {
    // Wait for seconds.
    yield return new WaitForSeconds(delay);
    // Instantiate player.
    Instantiate(Instance.player_prefab);
  } // End of PlayerRespawn

  // Manage hazards and enemies waves.
  private IEnumerator WaveManage()
  {
    // Wait for seconds.
    yield return new WaitForSeconds(Instance.wave_start_wait);
    // Loop.
    while(true)
    {
      // Enable spawning.
      Instance.is_spawning_enabled=true;
      // Wait for seconds.
      yield return new WaitForSeconds(Instance.wave_duration);
      // Enable spawning.
      Instance.is_spawning_enabled=false;
      // Wait for seconds.
      yield return new WaitForSeconds(Instance.wave_break_duration);
    }
  } // End of WaveManage

  #endregion

} // End of GameManager