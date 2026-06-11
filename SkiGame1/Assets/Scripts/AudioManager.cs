using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip hitSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Obstacle.OnObstacleHit += PlayHitSound;
    }

    private void OnDisable()
    {
        Obstacle.OnObstacleHit -= PlayHitSound;
    }

    // Update is called once per frame
    private void PlayHitSound()
    {
        source.PlayOneShot(hitSound);
    }
}
