using System;
using System.Collections;
using UnityEngine;

public class JumperSFX : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip groundSound;
    public AudioClip walkSound;
    public float walkDelay = 0.25f;
    public AudioClip hitWallSound;
    private AudioSource m_AudioSource;
    private bool m_IsWalkSoundPlaying;
    private Action<EventData> m_OnGround;
    private Action<EventData> m_OnHitWall;

    private Action<EventData> m_OnJump;
    private Action<EventData> m_OnWalk;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();

        var storage = FindObjectOfType<Storage>();
        if (storage != null) m_AudioSource.volume = storage.data.sfx;

        m_OnJump = _ => { PlaySound(jumpSound); };
        m_OnGround = _ => { PlaySound(groundSound); };
        m_OnWalk = _ => { StartCoroutine(PlayWalkSound()); };
        m_OnHitWall = _ => { PlaySound(hitWallSound); };

        SimpleEventManager.StartListening("GroundEvent", m_OnGround);
        SimpleEventManager.StartListening("JumpEvent", m_OnJump);
        SimpleEventManager.StartListening("WalkEvent", m_OnWalk);
        SimpleEventManager.StartListening("HitWallEvent", m_OnHitWall);
    }

    private void OnDestroy()
    {
        SimpleEventManager.StopListening("GroundEvent", m_OnGround);
        SimpleEventManager.StopListening("JumpEvent", m_OnJump);
        SimpleEventManager.StopListening("WalkEvent", m_OnWalk);
        SimpleEventManager.StopListening("HitWallEvent", m_OnHitWall);
    }

    private void PlaySound(AudioClip clip)
    {
        m_AudioSource.clip = clip;
        m_AudioSource.Play();
    }

    private IEnumerator PlayWalkSound()
    {
        if (m_IsWalkSoundPlaying) yield break;
        m_IsWalkSoundPlaying = true;
        PlaySound(walkSound);
        yield return new WaitForSeconds(walkDelay);
        m_IsWalkSoundPlaying = false;
    }
}