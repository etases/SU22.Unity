using System.Collections;
using UnityEngine;

public class TemporaryPlatform : Platform
{
    public float delayInactive = 2f;
    public float delayActive = 2f;
    private bool m_IsInAction;
    private SpriteRenderer m_SpriteRenderer;
    private Collider2D m_Collider2D;
    
    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Collider2D = GetComponent<Collider2D>();
    }

    private void SetActive(bool active)
    {
        m_SpriteRenderer.enabled = active;
        m_Collider2D.enabled = active;
    }

    protected override void HandleCollisionEnter(GameObject player)
    {
        StartCoroutine(StartAction());
    }

    private IEnumerator StartAction()
    {
        if (m_IsInAction) yield break;
        m_IsInAction = true;
        yield return new WaitForSeconds(delayInactive);
        SetActive(false);
        yield return new WaitForSeconds(delayActive);
        SetActive(true);
        m_IsInAction = false;
    }
}