using UnityEngine;
using UnityEngine.UI;

// HUD icons.
public class HudIcons : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'HudIcons' (Singelton pattern).
  public static HudIcons Instance
  {
    get
    {
      return HudIcons._instance;
    }
  }

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Level time slider.
  [SerializeField]
  [Tooltip("Level time slider")]
  private Slider time_slider;
  // Player health slider.
  [SerializeField]
  [Tooltip("Player health slider")]
  private Slider health_slider;
  // Player ammo left text.
  [SerializeField]
  [Tooltip("Player ammo left text")]
  private Text ammo_left_txt;
  // Player weapon name text.
  [SerializeField]
  [Tooltip("Player weapon name text")]
  private Text weapon_name_txt;
  // Player lives text.
  [SerializeField]
  [Tooltip("Player lives text")]
  private Text lives_txt;
  // Player score text.
  [SerializeField]
  [Tooltip("Player score text")]
  private Text score_txt;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'HudIcons' (Singelton pattern).
  private static HudIcons _instance;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Prepare time slider.
  public void TimePrepare(float min,float max)
  {
    // Set slider values.
    this.time_slider.minValue=min;
    this.time_slider.maxValue=max;
  } // End TimePrepare

  // Set level time.
  public void TimeSet(float val)
  {
    Instance.time_slider.value=val;
  } // End of TimeSet

  // Prepare health slider.
  public void HealthPrepare(float min,float max)
  {
    // Set slider values.
    this.health_slider.minValue=min;
    this.health_slider.maxValue=max;
  } // End HealthPrepare

  // Set health.
  public void HealthSet(float val)
  {
    Instance.health_slider.value=val;
  } // End of HealthSet

  // Set ammo left.
  public void AmmoLeftSet(int val)
  {
    Instance.ammo_left_txt.text=val.ToString();
  } // End of AmmoLeftSet

  // Set weapon name.
  public void WeaponNameSet(string weapon_name)
  {
    Instance.weapon_name_txt.text=weapon_name;
  } // End of WeaponNameSet

  // Set lives.
  public void LivesSet(int val)
  {
    Instance.lives_txt.text=val.ToString();
  } // End of LivesSet

  // Set score.
  public void ScoreSet(int val)
  {
    Instance.score_txt.text=val.ToString();
  } // End of ScoreSet

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Awake (used to initialize any variables or game state before the game starts).
  private void Awake()
  {
    if(HudIcons._instance==null)
    {
      HudIcons._instance=this;
    }
    else
    {
      GameObject.Destroy(this.gameObject);
    }
  } // End of Awake  

  #endregion

} // End of HudIcons