using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private static Dictionary<AudioClip, float> lastPlayed;
    private static AudioSource source;

    [SerializeField] private AudioClip _audio;
    [SerializeField] private Vector2 _pitchRange, _volumeRange;

    private float cooldown = 0.03f;    

    private void Awake()
    {
        if (!source)
            source = Camera.main.GetComponent<AudioSource>();
        if (lastPlayed == null)
            lastPlayed = new Dictionary<AudioClip, float>();
    }

    public void Play()
    {
        if (lastPlayed.ContainsKey(_audio) && Time.time - lastPlayed[_audio] < cooldown)
            return;
        var pitch = Random.Range(_pitchRange.x, _pitchRange.y);
        var volume = Random.Range(_volumeRange.x, _volumeRange.y);
        //source.Stop();
        source.pitch = pitch;
        source.volume = volume;
        source.PlayOneShot(_audio);
        lastPlayed[_audio] = Time.time;
    }
}
