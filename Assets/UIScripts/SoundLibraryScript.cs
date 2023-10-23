using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibraryScript : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audios = new List<AudioClip>();

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int index)
    {
        audioSource.clip = audios[index];
        audioSource.Play();
    }
}
