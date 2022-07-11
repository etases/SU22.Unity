using System.Collections;
using UnityEngine;

public class NotAPlatform : Platform
{
    public float delay = 1f;
    private bool m_IsInAction;
    private Renderer m_Renderer;

    public NotAPlatform() : base(true)
    {
    }

    protected override void Awake()
    {
        base.Awake();
        m_Renderer = GetComponent<Renderer>();
    }

    private void SetActive(bool active)
    {
        m_Renderer.enabled = active;
        collider2D.enabled = active;
    }

    protected override void HandleCollisionEnter(GameObject player)
    {
        StartCoroutine(StartAction());
    }

    private IEnumerator StartAction()
    {
        if (m_IsInAction) yield break;
        m_IsInAction = true;
        SetActive(false);
        yield return new WaitForSeconds(delay);
        SetActive(true);
        m_IsInAction = false;
    }
}