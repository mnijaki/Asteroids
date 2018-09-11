using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

// Settings manager.
public class SettingsManager : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Serialized fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // .....................................................................................................................
  // Master volume slider.
  [SerializeField]
  [Tooltip("Master volume slider")]
  private Slider master_volume;
  // Music volume slider.
  [SerializeField]
  [Tooltip("Music volume slider")]
  private Slider music_volume;
  // Special effects volume slider.
  [SerializeField]
  [Tooltip("Special effects volume slider")]
  private Slider sfx_volume;
  // .....................................................................................................................
  // Quality slider.
  [SerializeField]
  [Tooltip("Quality slider")]
  private Slider quality;
  // View distance slider.
  [SerializeField]
  [Tooltip("View distance slider")]
  private Slider view_distance;
  // .....................................................................................................................
  // Post processing profile.
  [SerializeField]
  [Tooltip("Post processing profile")]
  public PostProcessingProfile post_processing_profile;
  // Post processing toggle.
  [SerializeField]
  [Tooltip("Post processing toggle")]
  private Toggle post_processing;
  // Anti-aliasing slider.
  [SerializeField]
  [Tooltip("Anti-aliasing slider")]
  private Slider anti_aliasing_slider;
  [SerializeField]
  [Tooltip("Anti-aliasing togle")]
  private Toggle anti_aliasing_toggle;
  // Ambient occlusion toggle.
  [SerializeField]
  [Tooltip("Ambient occlusion toggle")]
  private Toggle ao;
  // Depth of field toggle.
  [SerializeField]
  [Tooltip("Depth of field toggle")]
  private Toggle depth_of_field;
  // Motion blur toggle.
  [SerializeField]
  [Tooltip("Motion blur toggle")]
  private Toggle motion_blur;
  // Bloom toggle.
  [SerializeField]
  [Tooltip("Bloom toggle")]
  private Toggle bloom;
  // Color grading toggle.
  [SerializeField]
  [Tooltip("Color grading toggle")]
  private Toggle color_grading;
  // Chromatic toggle.
  [SerializeField]
  [Tooltip("Chromatic toggle")]
  private Toggle chromatic;
  // Vignette toggle.
  [SerializeField]
  [Tooltip("Vignette toggle")]
  private Toggle vignette;
  // .....................................................................................................................
  // Difficulty slider.
  [SerializeField]
  [Tooltip("Difficulty slider")]
  private Slider difficulty;
  // Starting level slider.
  [SerializeField]
  [Tooltip("Starting level slider")]
  private Slider level_unlocked;
  // Movement speed slider.
  [SerializeField]
  [Tooltip("Movement speed slider")]
  private Slider movement_speed;
  // Mouse speed slider.
  [SerializeField]
  [Tooltip("Mouse speed slider")]
  private Slider mouse_speed;
  // Permanent death toggle.
  [SerializeField]
  [Tooltip("Permanent death toggle")]
  private Toggle perma_death;
  // .....................................................................................................................

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods associated with audio                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Set default values.
  public void OnAudioDefault()
  {
    this.master_volume.value=PlayerPrefsManager.MasterVolumeDefGet();
    this.music_volume.value=PlayerPrefsManager.MusicVolumeDefGet();
    this.sfx_volume.value=PlayerPrefsManager.SfxVolumeDefGet();
  } // End of OnAudioDefault

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods associated with video                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Set default values.
  public void OnVideoDefault()
  {
    this.quality.value=PlayerPrefsManager.QualityDefGet();
    this.view_distance.value=PlayerPrefsManager.ViewDistanceDefGet();
  } // End of OnVideoDefault

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods associated post processing                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Set default values.
  public void OnPostProcessingDefault()
  {
    this.post_processing.isOn=Convert.ToBoolean(PlayerPrefsManager.PostProcessingDefGet());
    // If there is no post processing profile.
    if(this.post_processing_profile==null)
    {
      this.anti_aliasing_slider.value=PlayerPrefsManager.AntiAliasingDefGet();
    }
    // If there is post processing profile.
    else
    {
      this.anti_aliasing_toggle.isOn=Convert.ToBoolean(PlayerPrefsManager.AntiAliasingDefGet());
    }
    this.ao.isOn=Convert.ToBoolean(PlayerPrefsManager.AODefGet());
    this.depth_of_field.isOn=Convert.ToBoolean(PlayerPrefsManager.DepthOfFieldDefGet());
    this.motion_blur.isOn=Convert.ToBoolean(PlayerPrefsManager.MotionBlurDefGet());
    this.bloom.isOn=Convert.ToBoolean(PlayerPrefsManager.BloomDefGet());
    this.color_grading.isOn=Convert.ToBoolean(PlayerPrefsManager.ColorGradingDefGet());
    this.chromatic.isOn=Convert.ToBoolean(PlayerPrefsManager.ChromaticDefGet());
    this.vignette.isOn=Convert.ToBoolean(PlayerPrefsManager.VignetteDefGet());
  } // End of OnPostProcessingDefault

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods associated with gameplay                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region
    
  // Set default values.
  public void OnGamePlayDefault()
  {
    this.difficulty.value=PlayerPrefsManager.DifficultyDefGet();
    this.level_unlocked.value=PlayerPrefsManager.LevelUnlockedDefGet();
    this.movement_speed.value=PlayerPrefsManager.MovementSpeedDefGet();
    this.mouse_speed.value=PlayerPrefsManager.MouseSpeedDefGet();
    this.perma_death.isOn=Convert.ToBoolean(PlayerPrefsManager.PermaDeathDefGet());
  } // End of OnGamePlayDefault

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization.
  private void Start()
  {
    // ...................................................................................................................
    // Initialization of master volume components.
    MasterVolumeInit();
    // Initialization of music volume components.
    MusicVolumeInit();
    // Initialization of special effects volume components.
    SfxVolumeInit();
    // ...................................................................................................................
    // Initialization of quality components.
    QualityInit();
    // Initialization of view distance components.
    ViewDistanceInit();
    // ...................................................................................................................
    // Initialization of post processing components.
    PostProcessingInit();
    // Initialization of anti-aliasing components.
    AntiAliasingInit();
    // Initialization of ambient occlusion components.
    AOInit();
    // Initialization of depth of field components.
    DepthOfFieldInit();
    // Initialization of motion blur components.
    MotionBlurInit();
    // Initialization of bloom components.
    BloomInit();
    // Initialization of color grading components.
    ColorGradingInit();
    // Initialization of chromatic components.
    ChromaticInit();
    // Initialization of vignette components.
    VignetteInit();
    // ...................................................................................................................
    // Initialization of difficulty components.
    DifficultyInit();
    // Initialization of level components.
    LevelUnlockedInit();
    // Initialization of movement speed components.
    MovementSpeedInit();
    // Initialization of mouse speed components.
    MouseSpeedInit();
    // Initialization of permanent death components.
    PermaDeathInit();
    // ...................................................................................................................
  } // End of Start

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods associated with audio                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization of master volume components.
  private void MasterVolumeInit()
  {
    // Set restrictions on the component.
    this.master_volume.minValue=PlayerPrefsManager.MasterVolumeMinGet();
    this.master_volume.maxValue=PlayerPrefsManager.MasterVolumeMaxGet();
    this.master_volume.wholeNumbers=PlayerPrefsManager.MasterVolumeWholeNumbers();
    // Set values in component.
    this.master_volume.value=PlayerPrefsManager.MasterVolumeGet();
    // Save initial settings.
    OnMasterVolumeChange();
    // Adds a listener.
    this.master_volume.onValueChanged.AddListener(delegate { OnMasterVolumeChange(); });
  } // End of MasterVolumeInit

  // On master volume change.
  private void OnMasterVolumeChange()
  {
    // Actualize player preferences.
    PlayerPrefsManager.MasterVolumeSet(this.master_volume.value);
    // Actualize value.
    AudioListener.volume=this.master_volume.value;
  } // End of OnMasterVolumeChange

  // Initialization of music volume components.
  private void MusicVolumeInit()
  {
    // Set restrictions on the component.
    this.music_volume.minValue=PlayerPrefsManager.MusicVolumeMinGet();
    this.music_volume.maxValue=PlayerPrefsManager.MusicVolumeMaxGet();
    this.music_volume.wholeNumbers=PlayerPrefsManager.MusicVolumeWholeNumbers();
    // Set values in component.
    this.music_volume.value=PlayerPrefsManager.MusicVolumeGet();
    // Save initial settings.
    OnMusicVolumeChange();
    // Adds a listener.
    this.music_volume.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
  } // End of MusicVolumeInit

  // On music volume change.
  private void OnMusicVolumeChange()
  {
    // Actualize player preferences.
    PlayerPrefsManager.MusicVolumeSet(this.music_volume.value);
    // Actualize value.
    MusicManager.Instance.VolumeChange(this.music_volume.value);
  } // End of OnMusicVolumeChange

  // Initialization of special effects volume components.
  private void SfxVolumeInit()
  {
    // Set restrictions on the component.
    this.sfx_volume.minValue=PlayerPrefsManager.SfxVolumeMinGet();
    this.sfx_volume.maxValue=PlayerPrefsManager.SfxVolumeMaxGet();
    this.sfx_volume.wholeNumbers=PlayerPrefsManager.SfxVolumeWholeNumbers();
    // Set values in component.
    this.sfx_volume.value=PlayerPrefsManager.SfxVolumeGet();
    // Save initial settings.
    OnSfxVolumeChange();
    // Adds a listener.
    this.sfx_volume.onValueChanged.AddListener(delegate { OnSfxVolumeChange(); });
  } // End of SfxVolumeInit

  // On special effects volume change.
  private void OnSfxVolumeChange()
  {
    // Actualize player preferences.
    PlayerPrefsManager.SfxVolumeSet(this.sfx_volume.value);
  } // End of OnSfxVolumeChange

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods associated with video                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization of quality components.
  private void QualityInit()
  {
    // Set restrictions on the component.
    this.quality.minValue=PlayerPrefsManager.QualityMinGet();
    this.quality.maxValue=PlayerPrefsManager.QualityMaxGet();
    this.quality.wholeNumbers=PlayerPrefsManager.QualityWholeNumbers();
    // Set values in component.
    this.quality.value=PlayerPrefsManager.QualityGet();
    // Save initial settings.
    OnQualityChange();
    // Adds a listener.
    this.quality.onValueChanged.AddListener(delegate { OnQualityChange(); });
  } // End of QualityInit

  // On quality change.
  private void OnQualityChange()
  {
    // Actualize player preferences.
    PlayerPrefsManager.QualitySet(Convert.ToInt32(this.quality.value));
    // Actualize value.
    QualitySettings.SetQualityLevel(Convert.ToInt32(this.quality.value),true);
  } // End of OnQualityChange

  // Initialization of view distance components.
  private void ViewDistanceInit()
  {
    // Set restrictions on the component.
    this.view_distance.minValue=PlayerPrefsManager.ViewDistanceMinGet();
    this.view_distance.maxValue=PlayerPrefsManager.ViewDistanceMaxGet();
    this.view_distance.wholeNumbers=PlayerPrefsManager.ViewDistanceWholeNumbers();
    // Set values in component.
    this.view_distance.value=PlayerPrefsManager.ViewDistanceGet();
    // Save initial settings.
    OnViewDistanceChange();
    // Adds a listener.
    this.view_distance.onValueChanged.AddListener(delegate { OnViewDistanceChange(); });
  } // End of ViewDistanceInit

  // On view distance change.
  private void OnViewDistanceChange()
  {
    // Actualize player preferences.
    PlayerPrefsManager.ViewDistanceSet(this.view_distance.value);
  } // End of OnViewDistanceChange

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods associated post processing                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization of post processing components.
  private void PostProcessingInit()
  {
    // Set values in component.
    this.post_processing.isOn=Convert.ToBoolean(PlayerPrefsManager.PostProcessingGet());
    // Save initial settings.
    OnPostProcessingChange();
    // Adds a listener.
    this.post_processing.onValueChanged.AddListener(delegate { OnPostProcessingChange(); });
  } // End of PostProcessingInit

  // On post processing change.
  private void OnPostProcessingChange()
  {
    // Actualize player preferences.
    PlayerPrefsManager.PostProcessingSet(Convert.ToInt32(this.post_processing.isOn));
    // If enable post processing.
    if(this.post_processing.isOn)
    {
      // Change state of controls associated with post processing.
      if(this.post_processing_profile==null)
      {
        this.anti_aliasing_slider.interactable=true;
      }
      else
      {
        this.anti_aliasing_toggle.interactable=true;
      }
      this.ao.interactable=true;
      this.depth_of_field.interactable=true;
      this.motion_blur.interactable=true;
      this.bloom.interactable=true;
      this.color_grading.interactable=true;
      this.chromatic.interactable=true;
      this.vignette.interactable=true;
    }
    // If disable post processing.
    else
    {
      // Reset values of controls associated with post processing.
      if(this.post_processing_profile==null)
      {
        this.anti_aliasing_slider.value=0;
      }
      else
      {
        this.anti_aliasing_toggle.isOn=false;
      }
      this.ao.isOn=false;
      this.depth_of_field.isOn=false;
      this.motion_blur.isOn=false;
      this.bloom.isOn=false;
      this.color_grading.isOn=false;
      this.chromatic.isOn=false;
      this.vignette.isOn=false;
      // Change state of controls associated with post processing.
      if(this.post_processing_profile==null)
      {
        this.anti_aliasing_slider.interactable=false;
      }
      else
      {
        this.anti_aliasing_toggle.interactable=false;
      }
      this.ao.interactable=false;
      this.depth_of_field.interactable=false;
      this.motion_blur.interactable=false;
      this.bloom.interactable=false;
      this.color_grading.interactable=false;
      this.chromatic.interactable=false;
      this.vignette.interactable=false;
    }
  } // End of OnPostProcessingChange

  // Initialization of anti-aliasing components.
  private void AntiAliasingInit()
  {
    // If there is no post processing profile.
    if(this.post_processing_profile==null)
    {
      // Set restrictions on the component.
      this.anti_aliasing_slider.minValue=AntiAliasingValToSliderVal(PlayerPrefsManager.AntiAliasingMinGet());
      this.anti_aliasing_slider.maxValue=AntiAliasingValToSliderVal(PlayerPrefsManager.AntiAliasingMaxGet());
      this.anti_aliasing_slider.wholeNumbers=PlayerPrefsManager.AntiAliasingWholeNumbers();
      // Set values in component.
      this.anti_aliasing_slider.value=AntiAliasingValToSliderVal(PlayerPrefsManager.AntiAliasingGet());
      // Save initial settings.
      OnAntiAliasingChange();
      // Adds a listener.
      this.anti_aliasing_slider.onValueChanged.AddListener(delegate { OnAntiAliasingChange(); });
    }
    // If there is post processing profile.
    else
    {
      // Set values in component.
      this.anti_aliasing_toggle.isOn=Convert.ToBoolean(PlayerPrefsManager.AntiAliasingGet());
      // Save initial settings.
      OnAntiAliasingChange();
      // Adds a listener.
      this.anti_aliasing_toggle.onValueChanged.AddListener(delegate { OnAntiAliasingChange(); });
    }
  } // End of AntiAliasingInit

  // On anti-aliasing change.
  private void OnAntiAliasingChange()
  {
    // If there is no post processing profile.
    if(this.post_processing_profile==null)
    {
      // Actualize player preferences.
      PlayerPrefsManager.AntiAliasingSet(AntiAliasingValFromSliderVal(Convert.ToInt32(this.anti_aliasing_slider.value)));
      // Actualize value.
      QualitySettings.antiAliasing=AntiAliasingValFromSliderVal(Convert.ToInt32(this.anti_aliasing_slider.value));
    }
    // If there is post processing profile.
    else
    {
      // Actualize player preferences.
      PlayerPrefsManager.AntiAliasingSet(Convert.ToInt32(this.anti_aliasing_toggle.isOn));
      // Actualize value.
      this.post_processing_profile.antialiasing.enabled=this.anti_aliasing_toggle.isOn;
    }
  } // End of OnAntiAliasingChange

  // Change antialiasing values to slider values (because, currently can't set [0,2,4,8] to slider ticks).  
  private int AntiAliasingValToSliderVal(int val)
  {
    int tmp_val = 0;
    switch(val)
    {
      case 0: tmp_val=0; break;
      case 2: tmp_val=1; break;
      case 4: tmp_val=2; break;
      case 8: tmp_val=3; break;
    }
    return tmp_val;
  } // End of AntiAliasingValToSliderVal

  // Change slider values to antialiasing values (because, currently can't set [0,2,4,8] to slider ticks).  
  private int AntiAliasingValFromSliderVal(int val)
  {
    int tmp_val = 0;
    switch(val)
    {
      case 0: tmp_val=0; break;
      case 1: tmp_val=2; break;
      case 2: tmp_val=4; break;
      case 3: tmp_val=8; break;
    }
    return tmp_val;
  } // End of AntiAliasingValFromSliderVal

  // Initialization of ambient occlusion components.
  private void AOInit()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Set values in component.
    this.ao.isOn=Convert.ToBoolean(PlayerPrefsManager.AOGet());
    // Save initial settings.
    OnAOChange();
    // Adds a listener.
    this.ao.onValueChanged.AddListener(delegate { OnAOChange(); });
  } // End of AOInit

  // On ambient occlusion change.
  private void OnAOChange()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Actualize player preferences.
    PlayerPrefsManager.AOSet(Convert.ToInt32(this.ao.isOn));
    // Actualize value.
    this.post_processing_profile.ambientOcclusion.enabled=this.ao.isOn;
  } // End of OnAOChange

  // Initialization of depth of field components.
  private void DepthOfFieldInit()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Set values in component.
    this.depth_of_field.isOn=Convert.ToBoolean(PlayerPrefsManager.DepthOfFieldGet());
    // Save initial settings.
    OnDepthOfFieldChange();
    // Adds a listener.
    this.depth_of_field.onValueChanged.AddListener(delegate { OnDepthOfFieldChange(); });
  } // End of DepthOfFieldInit

  // On depth of field change.
  private void OnDepthOfFieldChange()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Actualize player preferences.
    PlayerPrefsManager.DepthOfFieldSet(Convert.ToInt32(this.depth_of_field.isOn));
    // Actualize value.
    this.post_processing_profile.depthOfField.enabled=this.depth_of_field.isOn;
  } // End of OnDepthOfFieldChange

  // Initialization of motion blur components.
  private void MotionBlurInit()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Set values in component.
    this.motion_blur.isOn=Convert.ToBoolean(PlayerPrefsManager.MotionBlurGet());
    // Save initial settings.
    OnMotionBlurChange();
    // Adds a listener.
    this.motion_blur.onValueChanged.AddListener(delegate { OnMotionBlurChange(); });
  } // End of MotionBlurInit

  // On motion blur change.
  private void OnMotionBlurChange()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Actualize player preferences.
    PlayerPrefsManager.MotionBlurSet(Convert.ToInt32(this.motion_blur.isOn));
    // Actualize value.
    this.post_processing_profile.motionBlur.enabled=this.motion_blur.isOn;
  } // End of OnMotionBlurChange

  // Initialization of bloom components.
  private void BloomInit()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Set values in component.
    this.bloom.isOn=Convert.ToBoolean(PlayerPrefsManager.BloomGet());
    // Save initial settings.
    OnBloomChange();
    // Adds a listener.
    this.bloom.onValueChanged.AddListener(delegate { OnBloomChange(); });
  } // End of BloomInit

  // On bloom change.
  private void OnBloomChange()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Actualize player preferences.
    PlayerPrefsManager.BloomSet(Convert.ToInt32(this.bloom.isOn));
    // Actualize value.
    this.post_processing_profile.bloom.enabled=this.bloom.isOn;
  } // End of OnBloomChange

  // Initialization of color grading components.
  private void ColorGradingInit()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Set values in component.
    this.color_grading.isOn=Convert.ToBoolean(PlayerPrefsManager.ColorGradingGet());
    // Save initial settings.
    OnColorGradingChange();
    // Adds a listener.
    this.color_grading.onValueChanged.AddListener(delegate { OnColorGradingChange(); });
  } // End of ColorGradingInit

  // On color grading change.
  private void OnColorGradingChange()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Actualize player preferences.
    PlayerPrefsManager.ColorGradingSet(Convert.ToInt32(this.color_grading.isOn));
    // Actualize value.
    this.post_processing_profile.colorGrading.enabled=this.color_grading.isOn;
  } // End of OnColorGradingChange

  // Initialization of chromatic components.
  private void ChromaticInit()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Set values in component.
    this.chromatic.isOn=Convert.ToBoolean(PlayerPrefsManager.ChromaticGet());
    // Save initial settings.
    OnChromaticChange();
    // Adds a listener.
    this.chromatic.onValueChanged.AddListener(delegate { OnChromaticChange(); });
  } // End of ChromaticInit

  // On chromatic change.
  private void OnChromaticChange()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Actualize player preferences.
    PlayerPrefsManager.ChromaticSet(Convert.ToInt32(this.chromatic.isOn));
    // Actualize value.
    this.post_processing_profile.chromaticAberration.enabled=this.chromatic.isOn;
  } // End of OnChromaticChange

  // Initialization of vignette components.
  private void VignetteInit()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Set values in component.
    this.vignette.isOn=Convert.ToBoolean(PlayerPrefsManager.VignetteGet());
    // Save initial settings.
    OnVignetteChange();
    // Adds a listener.
    this.vignette.onValueChanged.AddListener(delegate { OnVignetteChange(); });
  } // End of VignetteInit

  // On vignette change.
  private void OnVignetteChange()
  {
    // If there is no post processing profile then exit from function.
    if(this.post_processing_profile==null)
    {
      return;
    }
    // Actualize player preferences.
    PlayerPrefsManager.VignetteSet(Convert.ToInt32(this.vignette.isOn));
    // Actualize value.
    this.post_processing_profile.vignette.enabled=this.vignette.isOn;
  } // End of OnVignetteChange

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Private methods associated with gameplay                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Initialization of difficulty components.
  private void DifficultyInit()
  {    
    // Set restrictions on the component.
    this.difficulty.minValue=PlayerPrefsManager.DifficultyMinGet();
    this.difficulty.maxValue=PlayerPrefsManager.DifficultyMaxGet();
    this.difficulty.wholeNumbers=PlayerPrefsManager.DifficultyWholeNumbers();
    // Set values in component.
    this.difficulty.value=PlayerPrefsManager.DifficultyGet();
    // Save initial settings.
    OnDifficultyChange();
    // Adds a listener.
    this.difficulty.onValueChanged.AddListener(delegate { OnDifficultyChange(); });
  } // End of DifficultyInit

  // On difficulty change.
  private void OnDifficultyChange()
  {
    // Actualize player preferences.
    PlayerPrefsManager.DifficultySet(Convert.ToInt32(this.difficulty.value));
  } // End of OnDifficultyChange

  // Initialization of level_unlocked components.
  private void LevelUnlockedInit()
  {    
    // Set restrictions on the component.
    this.level_unlocked.minValue=PlayerPrefsManager.LevelUnlockedMinGet();
    this.level_unlocked.maxValue=PlayerPrefsManager.LevelUnlockedMaxGet();
    this.level_unlocked.wholeNumbers=PlayerPrefsManager.LevelUnlcokedWholeNumbers();
    // Set values in component.
    this.level_unlocked.value=PlayerPrefsManager.LevelUnlockedGet();
    // Save initial settings.
    OnLevelUnlockedChange();
    // Adds a listener.
    this.level_unlocked.onValueChanged.AddListener(delegate { OnLevelUnlockedChange(); });
  } // End of LevelUnlockedInit

  // On level_unlocked change.
  private void OnLevelUnlockedChange()
  {
    // Actualize player preferences.
    PlayerPrefsManager.LevelUnlockedSet(Convert.ToInt32(this.level_unlocked.value));
  } // End of OnLevelUnlockedChange

  // Initialization of movement speed components.
  private void MovementSpeedInit()
  {    
    // Set restrictions on the component.
    this.movement_speed.minValue=PlayerPrefsManager.MovementSpeedMinGet();
    this.movement_speed.maxValue=PlayerPrefsManager.MovementSpeedMaxGet();
    this.movement_speed.wholeNumbers=PlayerPrefsManager.MovementSpeedWholeNumbers();
    // Set values in component.
    this.movement_speed.value=PlayerPrefsManager.MovementSpeedGet();
    // Save initial settings.
    OnMovementSpeedChange();
    // Adds a listener.
    this.movement_speed.onValueChanged.AddListener(delegate { OnMovementSpeedChange(); });
  } // End of MovementSpeedInit

  // On movement speed change.
  private void OnMovementSpeedChange()
  {
    // Actualize player preferences.
    PlayerPrefsManager.MovementSpeedSet(this.movement_speed.value);
  } // End of OnMovementSpeedChange

  // Initialization of mouse speed components.
  private void MouseSpeedInit()
  {    
    // Set restrictions on the component.
    this.mouse_speed.minValue=PlayerPrefsManager.MouseSpeedMinGet();
    this.mouse_speed.maxValue=PlayerPrefsManager.MouseSpeedMaxGet();
    this.mouse_speed.wholeNumbers=PlayerPrefsManager.MouseSpeedWholeNumbers();
    // Set values in component.
    this.mouse_speed.value=PlayerPrefsManager.MouseSpeedGet();
    // Save initial settings.
    OnMouseSpeedChange();
    // Adds a listener.
    this.mouse_speed.onValueChanged.AddListener(delegate { OnMouseSpeedChange(); });
  } // End of MouseSpeedInit

  // On mouse speed change.
  private void OnMouseSpeedChange()
  {
    // Actualize player preferences.
    PlayerPrefsManager.MouseSpeedSet(this.mouse_speed.value);
  } // End of OnMouseSpeedChange

  // Initialization of permanent death components.
  private void PermaDeathInit()
  {
    // Set values in component.
    this.perma_death.isOn=Convert.ToBoolean(PlayerPrefsManager.PermaDeathGet());
    // Save initial settings.
    OnPermaDeathChange();
    // Adds a listener.
    this.perma_death.onValueChanged.AddListener(delegate { OnPermaDeathChange(); });
  } // End of PermaDeathInit

  // On permanent death change.
  private void OnPermaDeathChange()
  {
    // Actualize player preferences.
    PlayerPrefsManager.PermaDeathSet(Convert.ToInt32(this.perma_death.isOn));
  } // End of OnPermaDeathChange

  #endregion

} // End of SettingsManager