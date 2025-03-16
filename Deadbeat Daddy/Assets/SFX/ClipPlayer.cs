using UnityEngine;

public class ClipPlayer : MonoBehaviour
{
    [SerializeField] AudioSource clipSource;
    void Awake()
    {
        clipSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        clipSource.clip = clip;
        clipSource.Play();
    }

    void Update()
    {
        if (clipSource.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
