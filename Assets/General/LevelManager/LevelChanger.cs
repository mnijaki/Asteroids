using System;
using UnityEngine;

// Level(scene) changer.
public class LevelChanger:MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Scene to load.
  [SerializeField]
  [Tooltip("Scene to load")]
  private LevelManager.Scenes scene = LevelManager.Scenes.NONE;
  // Delay of loading scene.
  [SerializeField]
  [Range(0.0F,15.0F)]
  [Tooltip("Delay of loading scene")]
  private float delay = 0.0F;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Function used only for debuging options and prototyping of the game.
  public void DebugSceneLoad(string scene_name)
  {
    // Get scene by name.
    LevelManager.Scenes scene = (LevelManager.Scenes)Enum.Parse(typeof(LevelManager.Scenes),scene_name,false);
    // Load scene.
    LevelManager.Instance.SceneLoad(scene,0.0F);
  } // End of DebugSceneLoad

  // Quit.
  public void Quit()
  {
    LevelManager.Instance.Quit();
  } // End of Quit

  // Load splash scene.
  public void SplashLoad(float delay)
  {
    LevelManager.Instance.SceneLoad(LevelManager.Scenes.SPLASH,delay);
  } // End of SplashLoad

  // Load lose scene.
  public void LoseLoad(float delay)
  {
    LevelManager.Instance.SceneLoad(LevelManager.Scenes.LOSE,delay);
  } // End of LoseLoad

  // Load win scene.
  public void WinLoad(float delay)
  {
    LevelManager.Instance.SceneLoad(LevelManager.Scenes.WIN,delay);
  } // End of WinLoad

  // Load main menu scene.
  public void MainMenuLoad(float delay)
  {
    LevelManager.Instance.SceneLoad(LevelManager.Scenes.MAIN_MENU,delay);
  } // End of MainMenuLoad

  // Load pause menu scene.
  public void PauseMenuLoad(float delay)
  {
    LevelManager.Instance.SceneLoad(LevelManager.Scenes.PAUSE_MENU,delay);
  } // End of PauseMenuLoad

  // Load options scene.
  public void OptionsLoad(float delay)
  {
    LevelManager.Instance.SceneLoad(LevelManager.Scenes.OPTIONS,delay);
  } // End of OptionsLoad

  // Load help scene.
  public void HelpLoad(float delay)
  {
    LevelManager.Instance.SceneLoad(LevelManager.Scenes.HELP,delay);
  } // End of HelpLoad

  // Load top scores with input fields.
  public void TopScoresInputLoad(float delay)
  {
    LevelManager.Instance.SceneLoad(LevelManager.Scenes.TOP_SCORES_INPUT,delay);
  } // End of TopScoresInputLoad

  // Load top scores.
  public void TopScoresLoad(float delay)
  {
    LevelManager.Instance.SceneLoad(LevelManager.Scenes.TOP_SCORES,delay);
  } // End of TopScoresLoad

  // Load next level.
  public void LvlLoadNext(float delay)
  {
    LevelManager.Instance.LvlLoadNext(delay,true);
  } // End of LvlLoadNext

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  //  Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // If no scene choosen then exit form function.
    if(this.scene == LevelManager.Scenes.NONE)
    {
      return;
    }
    // Load scene.
    LevelManager.Instance.SceneLoad(this.scene,this.delay);
  } // End of Start

  #endregion

} // End of LevelChanger