using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Button muteButton;
    public TextMeshProUGUI buttonText;

    private bool isMuted = false;

    void Start()
    {
       
        muteButton.onClick.AddListener(ToggleMute);
        UpdateButtonText();
    }

    void ToggleMute()
    {
        isMuted = !isMuted;
        backgroundMusic.mute = isMuted;
        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        buttonText.text = isMuted ? "Unmute" : "Mute";
    }
}