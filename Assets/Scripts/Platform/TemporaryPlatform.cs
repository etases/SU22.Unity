using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class TemporaryPlatform : Platform
{
    public float delayInactive = 2f;
    public float delayActive = 2f;
    private bool m_IsInAction;
    private SpriteShapeRenderer m_SpriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        m_SpriteRenderer = GetComponent<SpriteShapeRenderer>();
    }

    private void SetActive(bool active)
    {
        m_SpriteRenderer.enabled = active;
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
        yield return new WaitForSeconds(delayInactive);
        SetActive(false);
        yield return new WaitForSeconds(delayActive);
        SetActive(true);
        m_IsInAction = false;
    }
}