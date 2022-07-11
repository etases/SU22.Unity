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

    private Action<EventData> m_OnJump;
    private Action<EventData> m_OnGround;
    private Action<EventData> m_OnWalk;
    private Action<EventData> m_OnHitWall;
    private AudioSource m_AudioSource;
    private bool m_IsWalkSoundPlaying;
    private SimpleEventManager m_EventManager;

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

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_EventManager = FindObjectOfType<SimpleEventManager>();

        var storage = FindObjectOfType<Storage>();
        if (storage != null)
        {
            m_AudioSource.volume = storage.data.sfx;
        }

        m_OnJump = _ =>
        {
            PlaySound(jumpSound);
        };
        m_OnGround = _ =>
        {
            PlaySound(groundSound);
        };
        m_OnWalk = _ =>
        {
            StartCoroutine(PlayWalkSound());
        };
        m_OnHitWall = _ =>
        {
            PlaySound(hitWallSound);
        };

        if (m_EventManager != null)
        {
            m_EventManager.StartListening("GroundEvent", m_OnGround);
            m_EventManager.StartListening("JumpEvent", m_OnJump);
            m_EventManager.StartListening("WalkEvent", m_OnWalk);
            m_EventManager.StartListening("HitWallEvent", m_OnHitWall);
        }
    }
    
    private void OnDestroy()
    {
        if (m_EventManager != null)
        {
            m_EventManager.StopListening("GroundEvent", m_OnGround);
            m_EventManager.StopListening("JumpEvent", m_OnJump);
            m_EventManager.StopListening("WalkEvent", m_OnWalk);
            m_EventManager.StopListening("HitWallEvent", m_OnHitWall);
        }
    }
}