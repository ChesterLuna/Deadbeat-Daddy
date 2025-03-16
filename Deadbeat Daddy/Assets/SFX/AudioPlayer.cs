using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private GameObject musicPlayer;
    [SerializeField] private GameObject SFXPlayer;

    public void PlayMusicSoundClip(AudioClip clip)
    {
        ClipPlayer player = Instantiate(musicPlayer).GetComponent<ClipPlayer>();
        player.PlayClip(clip);
    }
    public void PlaySFXSoundClip(AudioClip clip)
    {
        ClipPlayer player = Instantiate(SFXPlayer).GetComponent<ClipPlayer>();
        player.PlayClip(clip);
    }

}
