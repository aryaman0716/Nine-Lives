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
    }

    public void PlayMeow()
    {
        audioSource.PlayOneShot(catMeow);
    }

    public void PlaySad()
    {
        audioSource.PlayOneShot(catSad);
    }
}