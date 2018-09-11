using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// Pause menu manager.
public class PauseMenuManager : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'PauseMenuManager' (Singelton pattern).
  public static PauseMenuManager Instance
  {
    get
    {
      return PauseMenuManager._instance;
    }
  }

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  //  Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Menu parent.
  [SerializeField]
  [Tooltip("Menu parent")]
  private GameObject menu_parent;
  // Continue button.
  [SerializeField]
  [Tooltip("Continue button")]
  private Button continue_btn;
  // Quit button.
  [SerializeField]
  [Tooltip("Quit button")]
  private Button quit_btn;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'PauseMenuManager' (Singelton pattern).
  private static PauseMenuManager _instance;
  // Audio sources (for purpouse of disabling audio sources when puase menu is active).
  private AudioSource[] audios;
  // Dictionary with information about audio sources.
  Dictionary<AudioSource,bool> audios_info = new Dictionary<AudioSource,bool>();
  // Player camera.
  private GameObject player_camera_go;  
  // HUD.
  private GameObject hud;
  // Weapon aim.
  private GameObject weapon_aim;
  // Flag if game is paused.
  private bool is_paused = false;
  // Initial time scale.
  private float initial_time_scale;
  // Initial fixed delta time.
  private float initial_fixed_delta_time;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Pause game.
  public void Pause()
  {
    // If game is paused then exit from function.
    if(Instance.is_paused)
    {
      return;
    }
    // If HUD is null.
    if(Instance.hud==null)
    {
      // Get HUD.
      Instance.hud=GameObject.FindGameObjectWithTag("hud");
    }
    // If weapon aim is null.
    if(Instance.weapon_aim==null)
    {
      Instance.weapon_aim=GameObject.FindGameObjectWithTag("weapon_aim");
    }
    // TO_DO:change to list of cameras
    // If player camera game object is null.
    //if(Instance.player_camera_go==null)
    //{
    //  // Get player camera game object.
    //  Instance.player_camera_go=GameObject.FindObjectOfType<PlayerCamera>().gameObject;
    //}
    // Change flag.
    Instance.is_paused=true;
    // Get initial time scale.
    Instance.initial_time_scale = Time.timeScale;
    // Get initial fixed delta time.
    Instance.initial_fixed_delta_time = Time.fixedDeltaTime;
    // Puase game time.
    Time.timeScale=0.0F;
    Time.fixedDeltaTime = 0;
    // If HUD is not null (could not be activated yet).
    if(Instance.hud!=null)
    {
      // Disable HUD.
      Instance.hud.SetActive(false);
    }
    // If weapon aim is not null (could not be activated yet).
    if(Instance.weapon_aim!=null)
    {
      // Disable weapon aim.
      Instance.weapon_aim.SetActive(false);
    }
    // TO_DO: popraw
    //// Unlock mouse.
    //GameObject.FindObjectOfType<FirstPersonController>().MouseLookGet().SetCursorLock(false);
    // Deactivate player camera.
    Instance.player_camera_go.SetActive(false);
    // Get all audio sources (must be done each time because number of audio source can varry on diffrent stages of the game).
    Instance.audios = GameObject.FindObjectsOfType<AudioSource>();
    // Loop over audio sources.
    foreach(AudioSource audio in Instance.audios)
    {
      // If music manager then skip loop step.
      if(audio.gameObject.CompareTag("music_manager"))
      {
        continue;
      }
      // Add information about audio source to dictionary.
      Instance.audios_info.Add(audio,audio.isPlaying);
      // Pause clip.
      audio.Pause();
    }
    // Activate menu objects.
    Instance.menu_parent.SetActive(true);
  } // End of Pause

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Awake (used to initialize any variables or game state before the game starts).
  private void Awake()
  {
    if(PauseMenuManager._instance==null)
    {
      PauseMenuManager._instance=this;
    }
    else
    {
      GameObject.Destroy(this.gameObject);
    }
  } // End of Awake

  // Initialization.
  private void Start()
  {    
    // Delegate functions to handle buttons events.
    Instance.continue_btn.onClick.AddListener(delegate { OnContinue(); });
    Instance.quit_btn.onClick.AddListener(delegate { OnQuit(); });
  } // End of Start

  // Continue game.
  private void OnContinue()
  {
    // If game is not paused then exit from function.
    if(!Instance.is_paused)
    {
      return;
    }
    // Reset menu to starting settings.
    GameObject.FindObjectOfType<MenuWindowsManager>().Reset();
    // Deactivate menu objects.
    Instance.menu_parent.SetActive(false);
    // Loop over audio sources.
    foreach(KeyValuePair<AudioSource,bool> audio_info in Instance.audios_info)
    {
      // If music manager then skip loop step.
      if(audio_info.Key.gameObject.CompareTag("music_manager"))
      {
        continue;
      }
      // If audio was not playing then skip loop step.
      if(!audio_info.Value)
      {
        continue;
      }
      // Unpause clip.
      audio_info.Key.UnPause();
    }
    // Clear dictionary with informations about audio sources.
    Instance.audios_info.Clear();
    // Activate player camera game object.
    Instance.player_camera_go.SetActive(true);
    // TO_DO:Popraw
    //// Lock mouse.
    //GameObject.FindObjectOfType<FirstPersonController>().MouseLookGet().SetCursorLock(true);
    // If weapon aim is not null (could not be activated yet).
    if(Instance.weapon_aim!=null)
    {
      // Enable weapon aim.
      Instance.weapon_aim.SetActive(true);
    }
    // If HUD is not null (could not be activated yet).
    if(Instance.hud!=null)
    {
      // Enable HUD.
      Instance.hud.SetActive(true);
    }
    // Unpause game time.
    Time.fixedDeltaTime = Instance.initial_fixed_delta_time;
    Time.timeScale=Instance.initial_time_scale;
    // Change flag.
    Instance.is_paused=false;
  } // End of OnContinue  

  // Quit.
  private void OnQuit()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
  } // End of OnQuit

  #endregion

} // End of PauseMenuManager