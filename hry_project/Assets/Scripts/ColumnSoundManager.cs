using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [Range (0f, 1f)]
    public float volume;

    // Plays column falling sound.
    public void PlayClip()
    {
        AudioManager.instance.PlayAudioClip(clip, transform, volume);
    }
}
