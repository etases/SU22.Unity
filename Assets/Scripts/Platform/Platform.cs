using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Platform : MonoBehaviour
{
    private readonly bool m_IsTrigger;
    protected new Collider2D collider2D;

    protected Platform(bool isTrigger)
    {
        m_IsTrigger = isTrigger;
    }

    protected Platform() : this(false)
    {
    }

    protected virtual void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        collider2D.isTrigger = m_IsTrigger;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") HandleCollisionEnter(other.gameObject);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") HandleCollisionExit(other.gameObject);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") HandleCollisionStay(other.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") HandleCollisionEnter(col.gameObject);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") HandleCollisionExit(col.gameObject);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") HandleCollisionStay(col.gameObject);
    }

    protected virtual void HandleCollisionEnter(GameObject player)
    {
    }

    protected virtual void HandleCollisionExit(GameObject player)
    {
    }

    protected virtual void HandleCollisionStay(GameObject player)
    {
    }
}