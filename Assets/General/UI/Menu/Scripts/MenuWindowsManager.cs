using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

// Menu windows manager.
public class MenuWindowsManager:MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Animator of initially open window.
  public Animator initialy_open_window_anim;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Id of animation trigger responsible for opening of panel.
  private int anim_open_trg_id;
  // Animator attached to opened window.
  private Animator opened_window_anim;
  // Previously selected game object.
  private GameObject prev_selected_go;
  // Name of animation trigger responsible for opening of panel.
  private const string anim_open_trg = "Open";
  // Name of animation closed state.
  private const string anim_closed_state = "Closed";

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // On enabling panel.
  public void OnEnable()
  {
    // Generates an parameter id from a string.
    this.anim_open_trg_id = Animator.StringToHash(anim_open_trg);
    // If there is no animator, that mean there is no window to initially open so exit from function.
    if(this.initialy_open_window_anim == null)
    {
      return;
    }
    // Open panel of given animator.
    OpenPanel(this.initialy_open_window_anim);
  } // End of OnEnable

  // Open panel of given animator.
  public void OpenPanel(Animator anim)
  {
    // If there is no animator, that mean there is no window to open so exit from function. 
    if(this.opened_window_anim == anim)
    {
      return;
    }
    // Set game object associated with animator as active.
    anim.gameObject.SetActive(true);
    // ????
    GameObject newPreviouslySelected = EventSystem.current.currentSelectedGameObject;
    // Set ame object associated with animator as last element in hierarchy.
    anim.transform.SetAsLastSibling();
    // Close currently opened window.
    CurrOpenedWindowClose();
    //
    this.prev_selected_go = newPreviouslySelected;
    //
    this.opened_window_anim = anim;
    this.opened_window_anim.SetBool(this.anim_open_trg_id,true);
    // 
    GameObject go = FindFirstEnabledSelectable(anim.gameObject);
    // Set given game object as selected.
    EventSystem.current.SetSelectedGameObject(go);
  } // End of OpenPanel

  // Reset menu to starting settings.
  public void Reset()
  {
    this.opened_window_anim=null;
    this.prev_selected_go=null;
  } // End of Reset

  // Close currently opened window.
  public void CurrOpenedWindowClose()
  {
    // If there is no opened window then exit from function.
    if(this.opened_window_anim == null)
    {
      return;
    }
    // Trigger animation of closing window.
    this.opened_window_anim.SetBool(this.anim_open_trg_id,false);
    // Set given game object as selected.
    EventSystem.current.SetSelectedGameObject(this.prev_selected_go);
    // 
    StartCoroutine(DisablePanelDeleyed(this.opened_window_anim));
    //
    this.opened_window_anim = null;
  } // End of CurrOpenedWindowClose

  // Find first element that can be selected (eg. button). 
  static GameObject FindFirstEnabledSelectable(GameObject gameObject)
  {
    GameObject go = null;
    Selectable[] selectables = gameObject.GetComponentsInChildren<Selectable>(true);
    foreach(Selectable selectable in selectables)
    {
      // to zwraca false gdy mam disabled caly root of menu
      if(selectable.IsActive() && selectable.IsInteractable())
      {
        go = selectable.gameObject;
        break;
      }
    }
    //
    return go;
  } // End of FindFirstEnabledSelectable

  #endregion

  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // ???
  IEnumerator DisablePanelDeleyed(Animator anim)
  {
    // Flag if closed state is reached.
    bool is_closed_state_reached = false;
    // ????
    bool wantToClose = true;
    // Loop until closed state is reached or 
    while((!is_closed_state_reached) && (wantToClose))
    {
      // If animation is not in transition.
      if(!anim.IsInTransition(0))
      {
        // If this animation was associated with closing animation then change flag (there could be other animation
        // before closing animation).
        is_closed_state_reached=anim.GetCurrentAnimatorStateInfo(0).IsName(anim_closed_state);
      }
      // ????
      wantToClose = !anim.GetBool(this.anim_open_trg_id);
      // Yield.
      yield return new WaitForEndOfFrame();
    }
    // ????
    if(wantToClose)
    {
      anim.gameObject.SetActive(false);
    }
  } // End of DisablePanelDeleyed

  #endregion

} // End of MenuWindowsManager