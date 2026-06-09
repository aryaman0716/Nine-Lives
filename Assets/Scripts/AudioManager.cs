using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioClip catMeow;
    [SerializeField] private AudioClip catSad;

    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 1f); 
    }

    public void PlayMeow()
    {
        audioSource.PlayOneShot(catMeow);
    }

    public void PlaySad()
    {
        audioSource.PlayOneShot(catSad);
    }
    public void SetSFXVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
}