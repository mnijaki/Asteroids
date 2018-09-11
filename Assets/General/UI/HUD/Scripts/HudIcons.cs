using System.Collections;
using System.Collections.Generic;
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

  // Player health slider.
  [SerializeField]
  [Tooltip("Player health slider")]
  private Slider health_slider;
  // Player armor slider.
  [SerializeField]
  [Tooltip("Player armor slider")]
  private Slider armor_slider;
  // Player ammo left text.
  [SerializeField]
  [Tooltip("Player ammo left text")]
  private Text ammo_left_txt;
  // Player weapon name text.
  [SerializeField]
  [Tooltip("Player weapon name text")]
  private Text weapon_name_txt;

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

  // Set health.
  public void HealthSet(float val)
  {
    Instance.health_slider.value=val;
  } // End of HealthSet

  // Set armor.
  public void ArmorSet(float val)
  {
    Instance.armor_slider.value=val;
  } // End of ArmorSet

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