using UnityEngine;
public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip track1;
    [SerializeField] private AudioClip track2;

    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayCurrentTrack();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    private void PlayCurrentTrack()
    {
        if (currentTrackIndex == 0)
        {
            audioSource.clip = track1;
        }
        else
        {
            audioSource.clip = track2;
        }
        audioSource.Play();
    }

    private void PlayNextTrack()
    {
        currentTrackIndex++;

        if (currentTrackIndex > 1)
        {
            currentTrackIndex = 0;
        }

        PlayCurrentTrack();
    }
}