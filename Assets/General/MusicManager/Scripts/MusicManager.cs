using UnityEngine;
using System.Collections;

// Class that handle background music in the game.
public class MusicManager : MonoBehaviour
{
  // ---------------------------------------------------------------------------------------------------------------------
  // Public fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'MusicManager' (Singelton pattern).
  public static MusicManager Instance
  {
    get
    {
      return MusicManager._instance;
    }
  }

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private fields                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Single static instance of 'MusicManager' (Singelton pattern).
  private static MusicManager _instance;
  // Audio source.
  private AudioSource audio_source;

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Public methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Play clip.
  public void ClipPlay(AudioClip clip, float delay, bool is_looped)
  {
    StartCoroutine(ClipPlayWithDelay(clip,delay,is_looped));
  } // End of ClipPlay

  // Stop clip.
  public void ClipStop()
  {
    Instance.audio_source.Stop();
  } // End of ClipStop

  // Change volume.
  public void VolumeChange(float volume)
  {
    Instance.audio_source.volume=volume;
  } // End of VolumeChange

  // Play clip at point (added this method, because in Unity 'ClipPlayAtPoint()' method you cannot change spatial blend
  // and other settings).
  public AudioSource ClipPlayAtPoint(Vector3 pos, float spatial_blend, float volume, AudioClip clip)
  {
    // MN:TO_DO:2018/09/10: Add pooling.
    // Create temporary game object.
    GameObject go = new GameObject("TmpAudio");
    // Set position.
    go.transform.position = pos;
    // Add audio source.
    AudioSource audio_source = go.AddComponent<AudioSource>();
    // Set spatial blend.
    audio_source.spatialBlend = spatial_blend;
    // Set volume.
    audio_source.volume = volume;
    // Set clip.
    audio_source.clip = clip; 
    // Play clip.
    audio_source.Play();
    // Destory game object after clip is ended.
    Destroy(go,clip.length);
    // Return audio source (will give abilty to change more properties of audio source).
    return audio_source;
  } // End of ClipPlayAtPoint

  #endregion


  // ---------------------------------------------------------------------------------------------------------------------  
  // Private methods                  
  // ---------------------------------------------------------------------------------------------------------------------
  #region

  // Awake (used to initialize any variables or game state before the game starts).
  private void Awake()
  {
    if(MusicManager._instance==null)
    {
      MusicManager._instance=this;
    }
    else
    {
      GameObject.Destroy(this.gameObject);
    }
  } // End of Awake

  // Initialization.
  private void Start()
  {
    // Make sure that game object will not be destroyed after loading next scene.
    GameObject.DontDestroyOnLoad(Instance.gameObject);
    // Get audio source.
    Instance.audio_source=Instance.GetComponent<AudioSource>();
    // Set volume from player preferences.
    Instance.audio_source.volume=PlayerPrefsManager.MasterVolumeGet();
  } // End of Start

  // Play clip with delay.
  private IEnumerator ClipPlayWithDelay(AudioClip clip,float delay,bool is_looped)
  {
    // If no clip then exit form function.
    if(clip==null)
    {
      yield break;
    }
    // Wait for seconds.
    yield return new WaitForSeconds(delay);
    // Load clip.
    Instance.audio_source.clip=clip;
    // Set loop on clip.
    Instance.audio_source.loop=is_looped;
    // Play clip.
    Instance.audio_source.Play();
  } // End of ClipPlayWithDelay

  #endregion

} // End of MusicManager