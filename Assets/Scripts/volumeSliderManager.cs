using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeSliderManager : MonoBehaviour {

    public AudioMixer audioMixer;
    public Text percentageText;

    public void SetVolume (float volume){
        audioMixer.SetFloat("Volume", volume);
    }

    public void textUpdate (float value) {
        int a = Mathf.RoundToInt(value / -80f * 100);
        int b = 100 - a;
        percentageText.text = b.ToString() + "%";
    }
}