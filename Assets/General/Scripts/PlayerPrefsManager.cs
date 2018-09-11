using UnityEngine;

// Manage player preferences.
public class PlayerPrefsManager:MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // .....................................................................................................................
  // Master volume.
  private const string MASTER_VOLUME_KEY = "master_volume";
  private const float MASTER_VOLUME_MIN = 0.0F;
  private const float MASTER_VOLUME_MAX = 1.0F;
  private const float MASTER_VOLUME_DEF = 0.5F;
  private const bool MASTER_VOLUME_WHOLE_NUMBERS = false;
  // Music volume.
  private const string MUSIC_VOLUME_KEY = "music_volume";
  private const float MUSIC_VOLUME_MIN = 0.0F;
  private const float MUSIC_VOLUME_MAX = 1.0F;
  private const float MUSIC_VOLUME_DEF = 0.5F;
  private const bool MUSIC_VOLUME_WHOLE_NUMBERS = false;
  // Special effects volume.
  private const string SFX_VOLUME_KEY = "sfx_volume";
  private const float SFX_VOLUME_MIN = 0.0F;
  private const float SFX_VOLUME_MAX = 1.0F;
  private const float SFX_VOLUME_DEF = 0.5F;
  private const bool SFX_VOLUME_WHOLE_NUMBERS = false;
  // .....................................................................................................................
  // Quality (doesn't have 'max' and 'def' because it cannot be const).
  private const string QUALITY_KEY = "quality";
  private const int QUALITY_MIN = 0;
  private const bool QUALITY_WHOLE_NUMBERS = true;
  // View distance.
  private const string VIEW_DISTANCE_KEY = "view_distance";
  private const float VIEW_DISTANCE_MIN = 100.0F;
  private const float VIEW_DISTANCE_MAX = 3000.0F;
  private const float VIEW_DISTANCE_DEF = 1000.0F;
  private const bool VIEW_DISTANCE_WHOLE_NUMBERS = false;
  // .....................................................................................................................
  // Post processing enabled/disabled.
  private const string POST_PROCESSING_KEY = "post_processing";
  private const int POST_PROCESSING_MIN = 0;
  private const int POST_PROCESSING_MAX = 1;
  private const int POST_PROCESSING_DEF = 1;
  // Anti-Aliasing.
  private const string ANTI_ALIASING_KEY = "anti_aliasing";
  private const int ANTI_ALIASING_MIN = 0;
  private const int ANTI_ALIASING_MAX = 8;
  private const int ANTI_ALIASING_DEF = 2;
  private const bool ANTI_ALIASING_WHOLE_NUMBERS = true;
  // Ambient occlusion(dynamiczne wyznaczanie oświetlenia - takie coś jak w blenderze, mega muli, 
  // używane w post processingu).
  private const string AO_KEY = "ao";
  private const int AO_MIN = 0;
  private const int AO_MAX = 1;
  private const int AO_DEF = 1;
  // Depth of field.
  private const string DEPTH_OF_FIELD_KEY = "depth_of_field";
  private const int DEPTH_OF_FIELD_MIN = 0;
  private const int DEPTH_OF_FIELD_MAX = 1;
  private const int DEPTH_OF_FIELD_DEF = 0;
  // Motion blur.
  private const string MOTION_BLUR_KEY = "motion_blur";
  private const int MOTION_BLUR_MIN = 0;
  private const int MOTION_BLUR_MAX = 1;
  private const int MOTION_BLUR_DEF = 1;
  // Bloom.
  private const string BLOOM_KEY = "bloom";
  private const int BLOOM_MIN = 0;
  private const int BLOOM_MAX = 1;
  private const int BLOOM_DEF = 1;
  // Color grading.
  private const string COLOR_GRADING_KEY = "color_grading";
  private const int COLOR_GRADING_MIN = 0;
  private const int COLOR_GRADING_MAX = 1;
  private const int COLOR_GRADING_DEF = 1;
  // Chromatic.
  private const string CHROMATIC_KEY = "chromatic";
  private const int CHROMATIC_MIN = 0;
  private const int CHROMATIC_MAX = 1;
  private const int CHROMATIC_DEF = 1;
  // Vignette.
  private const string VIGNETTE_KEY = "vignette";
  private const int VIGNETTE_MIN = 0;
  private const int VIGNETTE_MAX = 1;
  private const int VIGNETTE_DEF = 1;
  // .....................................................................................................................
  // Difficulty.
  private const string DIFFICULTY_KEY = "difficulty";
  private const int DIFFICULTY_MIN = 1;
  private const int DIFFICULTY_MAX = 10;
  private const int DIFFICULTY_DEF = 1;
  private const bool DIFFICULTY_WHOLE_NUMBERS = true;
  // Level unlocks.
  private const string LEVEL_UNLOCKED_KEY = "level_unlocked";
  private const int LEVEL_UNLOCKED_MIN = 0;
  private const int LEVEL_UNLOCKED_MAX = 10;
  private const int LEVEL_UNLOCKED_DEF = 0;
  private const bool LEVEL_UNLOCKED_WHOLE_NUMBERS = true;
  // Movement speed.
  private const string MOVEMENT_SPEED_KEY = "movement_speed";
  private const float MOVEMENT_SPEED_MIN = 0.5F;
  private const float MOVEMENT_SPEED_MAX = 1.5F;
  private const float MOVEMENT_SPEED_DEF = 1.0F;
  private const bool MOVEMENT_SPEED_WHOLE_NUMBERS = false;
  // Mouse speed.
  private const string MOUSE_SPEED_KEY = "mouse_speed";
  private const float MOUSE_SPEED_MIN = 0.5F;
  private const float MOUSE_SPEED_MAX = 1.5F;
  private const float MOUSE_SPEED_DEF = 1.0F;
  private const bool MOUSE_SPEED_WHOLE_NUMBERS = false;
  // Permanent death death.
  private const string PERMA_DEATH_KEY = "perma_death";
  private const int PERMA_DEATH_MIN = 0;
  private const int PERMA_DEATH_MAX = 1;
  private const int PERMA_DEATH_DEF = 0;
  // .....................................................................................................................

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods associated with audio                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Set master volume.
  public static void MasterVolumeSet(float volume)
  {
    // If out of range.
    if((volume<MASTER_VOLUME_MIN)&&(volume>MASTER_VOLUME_MAX))
    {
      // Write log to console.
      Debug.LogError("Master volume out of range ["+volume.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetFloat(MASTER_VOLUME_KEY,volume);
  } // End of MasterVolumeSet

  // Get master volume.
  public static float MasterVolumeGet()
  {
    // If there is no volume key.
    if(!PlayerPrefs.HasKey(MASTER_VOLUME_KEY))
    {
      // Set default value.
      MasterVolumeSet(MASTER_VOLUME_DEF);
    }
    // Return value.
    return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
  } // End of MasterVolumeGet

  // Get minimum master volume.
  public static float MasterVolumeMinGet()
  {
    return MASTER_VOLUME_MIN;
  } // End of MasterVolumeMinGet

  // Get maximum master volume.
  public static float MasterVolumeMaxGet()
  {
    return MASTER_VOLUME_MAX;
  } // End of MasterVolumeMaxGet

  // Get default master volume.
  public static float MasterVolumeDefGet()
  {
    return MASTER_VOLUME_DEF;
  } // End of MasterVolumeDefGet

  // Get info if whole numbers.
  public static bool MasterVolumeWholeNumbers()
  {
    return MASTER_VOLUME_WHOLE_NUMBERS;
  } // End of MasterVolumeWholeNumber

  // Set music volume.
  public static void MusicVolumeSet(float volume)
  {
    // If out of range.
    if((volume<MUSIC_VOLUME_MIN)&&(volume>MUSIC_VOLUME_MAX))
    {
      // Write log to console.
      Debug.LogError("Music volume out of range ["+volume.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY,volume);
  } // End of MusicVolumeSet

  // Get music volume.
  public static float MusicVolumeGet()
  {
    // If there is no volume key.
    if(!PlayerPrefs.HasKey(MUSIC_VOLUME_KEY))
    {
      // Set default value.
      MusicVolumeSet(MUSIC_VOLUME_DEF);
    }
    // Return value.
    return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
  } // End of MusicVolumeGet

  // Get minimum music volume.
  public static float MusicVolumeMinGet()
  {
    return MUSIC_VOLUME_MIN;
  } // End of MusicVolumeMinGet

  // Get maximum music volume.
  public static float MusicVolumeMaxGet()
  {
    return MUSIC_VOLUME_MAX;
  } // End of MusicVolumeMaxGet

  // Get default music volume.
  public static float MusicVolumeDefGet()
  {
    return MUSIC_VOLUME_DEF;
  } // End of MusicVolumeDefGet

  // Get info if whole numbers.
  public static bool MusicVolumeWholeNumbers()
  {
    return MUSIC_VOLUME_WHOLE_NUMBERS;
  } // End of MusicVolumeWholeNumber

  // Set special effects volume.
  public static void SfxVolumeSet(float volume)
  {
    // If out of range.
    if((volume<SFX_VOLUME_MIN)&&(volume>SFX_VOLUME_MAX))
    {
      // Write log to console.
      Debug.LogError("Special effects volume out of range ["+volume.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetFloat(SFX_VOLUME_KEY,volume);
  } // End of SfxVolumeSet

  // Get special effects volume.
  public static float SfxVolumeGet()
  {
    // If there is no volume key.
    if(!PlayerPrefs.HasKey(SFX_VOLUME_KEY))
    {
      // Set default value.
      SfxVolumeSet(SFX_VOLUME_DEF);
    }
    // Return value.
    return PlayerPrefs.GetFloat(SFX_VOLUME_KEY);
  } // End of SfxVolumeGet

  // Get minimum special effects volume.
  public static float SfxVolumeMinGet()
  {
    return SFX_VOLUME_MIN;
  } // End of SfxVolumeMinGet

  // Get maximum special effects volume.
  public static float SfxVolumeMaxGet()
  {
    return SFX_VOLUME_MAX;
  } // End of SfxVolumeMaxGet

  // Get default special effects volume.
  public static float SfxVolumeDefGet()
  {
    return SFX_VOLUME_DEF;
  } // End of SfxVolumeDefGet

  // Get info if whole numbers.
  public static bool SfxVolumeWholeNumbers()
  {
    return SFX_VOLUME_WHOLE_NUMBERS;
  } // End of SfxVolumeWholeNumber

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  //  Public methods associated with video                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Set quality.
  public static void QualitySet(int idx)
  {
    // If out of range.
    if((idx<QUALITY_MIN)&&(idx>QualityMaxGet()))
    {
      // Write log to console.
      Debug.LogError("Quality index out of range ["+idx.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(QUALITY_KEY,idx);
    // MN:TO_DO:2018/09/11: changing quality settings should change other setting e.g. Anti-Aliasing
  } // End of QualitySet

  // Get quality.
  public static int QualityGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(QUALITY_KEY))
    {
      // Set default value.
      QualitySet(QualityDefGet());
    }
    // Return value.
    return PlayerPrefs.GetInt(QUALITY_KEY);
  } // End of QualityGet

  // Get minimum quality.
  public static int QualityMinGet()
  {
    return QUALITY_MIN;
  } // End of QualityMinGet

  // Get maximum quality.
  public static int QualityMaxGet()
  {
    return QualitySettings.names.Length-1;
  } // End of QualityMaxGet

  // Get default quality.
  public static int QualityDefGet()
  {
    return QualitySettings.names.Length-1;
  } // End of QualityDefGet

  // Get info if whole numbers.
  public static bool QualityWholeNumbers()
  {
    return QUALITY_WHOLE_NUMBERS;
  } // End of QualityWholeNumber

  // Set view distance.
  public static void ViewDistanceSet(float val)
  {
    // If out of range.
    if((val<VIEW_DISTANCE_MIN)&&(val>VIEW_DISTANCE_MAX))
    {
      // Write log to console.
      Debug.LogError("View distance out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetFloat(VIEW_DISTANCE_KEY,val);
  } // End of ViewDistanceSet

  // Get view distance.
  public static float ViewDistanceGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(VIEW_DISTANCE_KEY))
    {
      // Set default value.
      ViewDistanceSet(VIEW_DISTANCE_DEF);
    }
    // Return value.
    return PlayerPrefs.GetFloat(VIEW_DISTANCE_KEY);
  } // End of ViewDistanceGet

  // Get minimum view distance.
  public static float ViewDistanceMinGet()
  {
    return VIEW_DISTANCE_MIN;
  } // End of ViewDistanceMinGet

  // Get maximum view distance.
  public static float ViewDistanceMaxGet()
  {
    return VIEW_DISTANCE_MAX;
  } // End of ViewDistanceMaxGet

  // Get default view distance.
  public static float ViewDistanceDefGet()
  {
    return VIEW_DISTANCE_DEF;
  } // End of ViewDistanceDefGet

  // Get info if whole numbers.
  public static bool ViewDistanceWholeNumbers()
  {
    return VIEW_DISTANCE_WHOLE_NUMBERS;
  } // End of ViewDistanceWholeNumber

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods associated with post-processing                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Set post processing.
  public static void PostProcessingSet(int val)
  {
    // If out of range.
    if((val<POST_PROCESSING_MIN)&&(val>POST_PROCESSING_MAX))
    {
      // Write log to console.
      Debug.LogError("Post processing out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(POST_PROCESSING_KEY,val);
  } // End of PostProcessingSet

  // Get post processing.
  public static int PostProcessingGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(POST_PROCESSING_KEY))
    {
      // Set default value.
      PostProcessingSet(POST_PROCESSING_DEF);
    }
    // Return value.
    return PlayerPrefs.GetInt(POST_PROCESSING_KEY);
  } // End of PostProcessingGet

  // Get minimum post processing.
  public static int PostProcessingMinGet()
  {
    return POST_PROCESSING_MIN;
  } // End of PostProcessingMinGet

  // Get maximum post processing.
  public static int PostProcessingMaxGet()
  {
    return POST_PROCESSING_MAX;
  } // End of PostProcessingMaxGet

  // Get default post processing.
  public static int PostProcessingDefGet()
  {
    return POST_PROCESSING_DEF;
  } // End of PostProcessingDefGet

  // Set anti-aliasing.
  public static void AntiAliasingSet(int val)
  {
    // If out of range.
    if((val<ANTI_ALIASING_MIN)&&(val>ANTI_ALIASING_MAX))
    {
      // Write log to console.
      Debug.LogError("Anti-aliasing out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(ANTI_ALIASING_KEY,val);
  } // End of AntiAliasingSet

  // Get anti-aliasing.
  public static int AntiAliasingGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(ANTI_ALIASING_KEY))
    {
      // Set default value.
      AntiAliasingSet(ANTI_ALIASING_DEF);
    }
    // Return value.
    return PlayerPrefs.GetInt(ANTI_ALIASING_KEY);
  } // End of AntiAliasingGet

  // Get minimum anti-aliasing.
  public static int AntiAliasingMinGet()
  {
    return ANTI_ALIASING_MIN;
  } // End of AntiAliasingMinGet

  // Get maximum anti-aliasing.
  public static int AntiAliasingMaxGet()
  {
    return ANTI_ALIASING_MAX;
  } // End of AntiAliasingMaxGet

  // Get default anti-aliasing.
  public static int AntiAliasingDefGet()
  {
    return ANTI_ALIASING_DEF;
  } // End of AntiAliasingDefGet

  // Get info if whole numbers.
  public static bool AntiAliasingWholeNumbers()
  {
    return ANTI_ALIASING_WHOLE_NUMBERS;
  } // End of AntiAliasingWholeNumber

  // Set ambient occlusion.
  public static void AOSet(int val)
  {
    // If out of range.
    if((val<AO_MIN)&&(val>AO_MAX))
    {
      // Write log to console.
      Debug.LogError("Ambient occlusion out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(AO_KEY,val);
  } // End of AOSet

  // Get ambient occlusion.
  public static int AOGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(AO_KEY))
    {
      // Set default value.
      AOSet(AO_DEF);
    }
    // Return value.
    return PlayerPrefs.GetInt(AO_KEY);
  } // End of AOGet

  // Get minimum ambient occlusion.
  public static int AOMinGet()
  {
    return AO_MIN;
  } // End of AOMinGet

  // Get maximum ambient occlusion.
  public static int AOMaxGet()
  {
    return AO_MAX;
  } // End of AOMaxGet

  // Get default ambient occlusion.
  public static int AODefGet()
  {
    return AO_DEF;
  } // End of AODefGet

  // Set depth of field.
  public static void DepthOfFieldSet(int val)
  {
    // If out of range.
    if((val<DEPTH_OF_FIELD_MIN)&&(val>DEPTH_OF_FIELD_MAX))
    {
      // Write log to console.
      Debug.LogError("Depth of field out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(DEPTH_OF_FIELD_KEY,val);
  } // End of DepthOfFieldSet

  // Get depth of field.
  public static int DepthOfFieldGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(DEPTH_OF_FIELD_KEY))
    {
      // Set default value.
      DepthOfFieldSet(DEPTH_OF_FIELD_DEF);
    }
    // Return value.
    return PlayerPrefs.GetInt(DEPTH_OF_FIELD_KEY);
  } // End of DepthOfFieldGet

  // Get minimum depth of field.
  public static int DepthOfFieldMinGet()
  {
    return DEPTH_OF_FIELD_MIN;
  } // End of DepthOfFieldMinGet

  // Get maximum depth of field.
  public static int DepthOfFieldMaxGet()
  {
    return DEPTH_OF_FIELD_MAX;
  } // End of DepthOfFieldMaxGet

  // Get default depth of field.
  public static int DepthOfFieldDefGet()
  {
    return DEPTH_OF_FIELD_DEF;
  } // End of DepthOfFieldDefGet

  // Set motion blur.
  public static void MotionBlurSet(int val)
  {
    // If out of range.
    if((val<MOTION_BLUR_MIN)&&(val>MOTION_BLUR_MAX))
    {
      // Write log to console.
      Debug.LogError("Motion blur out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(MOTION_BLUR_KEY,val);
  } // End of MotionBlurSet

  // Get motion blur.
  public static int MotionBlurGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(MOTION_BLUR_KEY))
    {
      // Set default value.
      MotionBlurSet(MOTION_BLUR_DEF);
    }
    // Return value.
    return PlayerPrefs.GetInt(MOTION_BLUR_KEY);
  } // End of MotionBlurGet

  // Get minimum motion blur.
  public static int MotionBlurMinGet()
  {
    return MOTION_BLUR_MIN;
  } // End of MotionBlurMinGet

  // Get maximum motion blur.
  public static int MotionBlurMaxGet()
  {
    return MOTION_BLUR_MAX;
  } // End of MotionBlurMaxGet

  // Get default motion blur.
  public static int MotionBlurDefGet()
  {
    return MOTION_BLUR_DEF;
  } // End of MotionBlurDefGet

  // Set bloom.
  public static void BloomSet(int val)
  {
    // If out of range.
    if((val<BLOOM_MIN)&&(val>BLOOM_MAX))
    {
      // Write log to console.
      Debug.LogError("Bloom out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(BLOOM_KEY,val);
  } // End of BloomSet

  // Get bloom.
  public static int BloomGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(BLOOM_KEY))
    {
      // Set default value.
      BloomSet(BLOOM_DEF);
    }
    // Return value.
    return PlayerPrefs.GetInt(BLOOM_KEY);
  } // End of BloomGet

  // Get minimum bloom.
  public static int BloomMinGet()
  {
    return BLOOM_MIN;
  } // End of BloomMinGet

  // Get maximum bloom.
  public static int BloomMaxGet()
  {
    return BLOOM_MAX;
  } // End of BloomMaxGet

  // Get default bloom.
  public static int BloomDefGet()
  {
    return BLOOM_DEF;
  } // End of BloomDefGet

  // Set color grading.
  public static void ColorGradingSet(int val)
  {
    // If out of range.
    if((val<COLOR_GRADING_MIN)&&(val>COLOR_GRADING_MAX))
    {
      // Write log to console.
      Debug.LogError("Color grading out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(COLOR_GRADING_KEY,val);
  } // End of ColorGradingSet

  // Get color grading.
  public static int ColorGradingGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(COLOR_GRADING_KEY))
    {
      // Set default value.
      ColorGradingSet(COLOR_GRADING_DEF);
    }
    // Return value.
    return PlayerPrefs.GetInt(COLOR_GRADING_KEY);
  } // End of ColorGradingGet

  // Get minimum color grading.
  public static int ColorGradingMinGet()
  {
    return COLOR_GRADING_MIN;
  } // End of ColorGradingMinGet

  // Get maximum color grading.
  public static int ColorGradingMaxGet()
  {
    return COLOR_GRADING_MAX;
  } // End of ColorGradingMaxGet

  // Get default color grading.
  public static int ColorGradingDefGet()
  {
    return COLOR_GRADING_DEF;
  } // End of ColorGradingDefGet

  // Set chromatic.
  public static void ChromaticSet(int val)
  {
    // If out of range.
    if((val<CHROMATIC_MIN)&&(val>CHROMATIC_MAX))
    {
      // Write log to console.
      Debug.LogError("Chromatic out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(CHROMATIC_KEY,val);
  } // End of ChromaticSet

  // Get chromatic.
  public static int ChromaticGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(CHROMATIC_KEY))
    {
      // Set default value.
      ChromaticSet(CHROMATIC_DEF);
    }
    // Return value.
    return PlayerPrefs.GetInt(CHROMATIC_KEY);
  } // End of ChromaticGet

  // Get minimum chromatic.
  public static int ChromaticMinGet()
  {
    return CHROMATIC_MIN;
  } // End of ChromaticMinGet

  // Get maximum chromatic.
  public static int ChromaticMaxGet()
  {
    return CHROMATIC_MAX;
  } // End of ChromaticMaxGet

  // Get default chromatic.
  public static int ChromaticDefGet()
  {
    return CHROMATIC_DEF;
  } // End of ChromaticDefGet

  // Set vignette.
  public static void VignetteSet(int val)
  {
    // If out of range.
    if((val<VIGNETTE_MIN)&&(val>VIGNETTE_MAX))
    {
      // Write log to console.
      Debug.LogError("Vignette out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(VIGNETTE_KEY,val);
  } // End of VignetteSet

  // Get vignette.
  public static int VignetteGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(VIGNETTE_KEY))
    {
      // Set default value.
      VignetteSet(VIGNETTE_DEF);
    }
    // Return value.
    return PlayerPrefs.GetInt(VIGNETTE_KEY);
  } // End of VignetteGet

  // Get minimum vignette.
  public static int VignetteMinGet()
  {
    return VIGNETTE_MIN;
  } // End of VignetteMinGet

  // Get maximum vignette.
  public static int VignetteMaxGet()
  {
    return VIGNETTE_MAX;
  } // End of VignetteMaxGet

  // Get default vignette.
  public static int VignetteDefGet()
  {
    return VIGNETTE_DEF;
  } // End of VignetteDefGet

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------
  // Public methods associated with gameplay                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Set difficulty.
  public static void DifficultySet(int val)
  {
    // If out of range.
    if((val<DIFFICULTY_MIN)&&(val>DIFFICULTY_MAX))
    {
      // Write log to console.
      Debug.LogError("Difficulty out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(DIFFICULTY_KEY,val);
  } // End of DifficultySet

  // Get difficulty.
  public static int DifficultyGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(DIFFICULTY_KEY))
    {
      // Set default value.
      DifficultySet(DIFFICULTY_DEF);
    }
    // Return value.
    return PlayerPrefs.GetInt(DIFFICULTY_KEY);
  } // End of DifficultyGet

  // Get minimum difficulty.
  public static int DifficultyMinGet()
  {
    return DIFFICULTY_MIN;
  } // End of DifficultyMinGet

  // Get maximum difficulty.
  public static int DifficultyMaxGet()
  {
    return DIFFICULTY_MAX;
  } // End of DifficultyMaxGet

  // Get default difficulty.
  public static int DifficultyDefGet()
  {
    return DIFFICULTY_DEF;
  } // End of DifficultyDefGet

  // Get info if whole numbers.
  public static bool DifficultyWholeNumbers()
  {
    return DIFFICULTY_WHOLE_NUMBERS;
  } // End of DifficultyWholeNumber

  // Unlock level.
  public static void LevelUnlockedSet(int val)
  {
    // If out of range.
    if((val<LEVEL_UNLOCKED_MIN)&&(val>LEVEL_UNLOCKED_MAX))
    {
      // Write log to console.
      Debug.LogError("Level out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(LEVEL_UNLOCKED_KEY,val);
  } // End of LevelUnlockedSet

  // Get unlocked level.
  public static int LevelUnlockedGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(LEVEL_UNLOCKED_KEY))
    {
      // Set default value.
      DifficultySet(LEVEL_UNLOCKED_DEF);
    }
    // Return value.
    return PlayerPrefs.GetInt(LEVEL_UNLOCKED_KEY);
  } // End of LevelUnlockedGet

  // Get minimum unlocked level.
  public static int LevelUnlockedMinGet()
  {
    return LEVEL_UNLOCKED_MIN;
  } // End of LevelUnlockedMinGet

  // Get maximum unlocked level.
  public static int LevelUnlockedMaxGet()
  {
    return LEVEL_UNLOCKED_MAX;
  } // End of LevelUnlockedMaxGet

  // Get default unlocked level.
  public static int LevelUnlockedDefGet()
  {
    return LEVEL_UNLOCKED_DEF;
  } // End of LevelUnlockedDefGet

  // Get info if whole numbers.
  public static bool LevelUnlcokedWholeNumbers()
  {
    return LEVEL_UNLOCKED_WHOLE_NUMBERS;
  } // End of LevelUnlcokedWholeNumber

  // Set movement speed.
  public static void MovementSpeedSet(float val)
  {
    // If out of range.
    if((val<MOVEMENT_SPEED_MIN)&&(val>MOVEMENT_SPEED_MAX))
    {
      // Write log to console.
      Debug.LogError("Movement speed out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetFloat(MOVEMENT_SPEED_KEY,val);
  } // End of MovementSpeedSet

  // Get movement speed.
  public static float MovementSpeedGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(MOVEMENT_SPEED_KEY))
    {
      // Set default value.
      MovementSpeedSet(MOVEMENT_SPEED_DEF);
    }
    // Return value.
    return PlayerPrefs.GetFloat(MOVEMENT_SPEED_KEY);
  } // End of MovementSpeedGet

  // Get minimum movement speed.
  public static float MovementSpeedMinGet()
  {
    return MOVEMENT_SPEED_MIN;
  } // End of MovementSpeedMinGet

  // Get maximum movement speed.
  public static float MovementSpeedMaxGet()
  {
    return MOVEMENT_SPEED_MAX;
  } // End of MovementSpeedMaxGet

  // Get default movement speed.
  public static float MovementSpeedDefGet()
  {
    return MOVEMENT_SPEED_DEF;
  } // End of MovementSpeedDefGet

  // Get info if whole numbers.
  public static bool MovementSpeedWholeNumbers()
  {
    return MOVEMENT_SPEED_WHOLE_NUMBERS;
  } // End of MovementSpeedWholeNumber

  // Set mouse speed.
  public static void MouseSpeedSet(float val)
  {
    // If out of range.
    if((val<MOUSE_SPEED_MIN)&&(val>MOUSE_SPEED_MAX))
    {
      // Write log to console.
      Debug.LogError("Mouse speed out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetFloat(MOUSE_SPEED_KEY,val);
  } // End of MouseSpeedSet

  // Get mouse speed.
  public static float MouseSpeedGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(MOUSE_SPEED_KEY))
    {
      // Set default value.
      MouseSpeedSet(MOUSE_SPEED_DEF);
    }
    // Return value.
    return PlayerPrefs.GetFloat(MOUSE_SPEED_KEY);
  } // End of MouseSpeedGet

  // Get minimum mouse speed.
  public static float MouseSpeedMinGet()
  {
    return MOUSE_SPEED_MIN;
  } // End of MouseSpeedMinGet

  // Get maximum mouse speed.
  public static float MouseSpeedMaxGet()
  {
    return MOUSE_SPEED_MAX;
  } // End of MouseSpeedMaxGet

  // Get default mouse speed.
  public static float MouseSpeedDefGet()
  {
    return MOUSE_SPEED_DEF;
  } // End of MouseSpeedDefGet

  // Get info if whole numbers.
  public static bool MouseSpeedWholeNumbers()
  {
    return MOUSE_SPEED_WHOLE_NUMBERS;
  } // End of MouseSpeedWholeNumber

  // Set permanent death.
  public static void PermaDeathSet(int val)
  {
    // If out of range.
    if((val<PERMA_DEATH_MIN)&&(val>PERMA_DEATH_MAX))
    {
      // Write log to console.
      Debug.LogError("Permanent death out of range ["+val.ToString()+"]");
    }
    // Set value.
    PlayerPrefs.SetInt(PERMA_DEATH_KEY,val);
  } // End of PermaDeathSet

  // Get permanent death.
  public static int PermaDeathGet()
  {
    // If there is no key.
    if(!PlayerPrefs.HasKey(PERMA_DEATH_KEY))
    {
      // Set default value.
      PermaDeathSet(PERMA_DEATH_DEF);
    }
    // Return value.
    return PlayerPrefs.GetInt(PERMA_DEATH_KEY);
  } // End of PermaDeathGet

  // Get minimum permanent death.
  public static int PermaDeathMinGet()
  {
    return PERMA_DEATH_MIN;
  } // End of PermaDeathMinGet

  // Get maximum permanent death.
  public static int PermaDeathMaxGet()
  {
    return PERMA_DEATH_MAX;
  } // End of PermaDeathMaxGet

  // Get default permanent death.
  public static int PermaDeathDefGet()
  {
    return PERMA_DEATH_DEF;
  } // End of PermaDeathDefGet

  #endregion

} // End of PlayerPrefsManager