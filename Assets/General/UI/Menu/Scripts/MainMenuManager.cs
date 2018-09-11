using UnityEngine;

// Main menu manager.
public class MainMenuManager : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // New game.
  public void NewGame()
  {
    LevelManager.Instance.LvlLoadNext(0.0F,true);
  } // End of NewGame

  // Quit game.
  public void QuitGame()
  {
    LevelManager.Instance.Quit();
  } // End of QuitGame

  #endregion

} // End of MainMenuManager