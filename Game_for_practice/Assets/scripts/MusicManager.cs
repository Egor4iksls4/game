using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    private AudioSource audioSource;

    private const string musicPos = "Music";

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        musicSlider.value = PlayerPrefs.HasKey(musicPos) ? PlayerPrefs.GetFloat(musicPos) : 0.0f;
        audioSource.volume = musicSlider.value;

        musicSlider.onValueChanged.AddListener(delegate {ChangeVolume();} );
    }

    private void ChangeVolume()
    {
        audioSource.volume = musicSlider.value;
        PlayerPrefs.SetFloat(musicPos, musicSlider.value);
    }
}
