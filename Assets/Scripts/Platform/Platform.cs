using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HandleCollisionEnter(other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HandleCollisionExit(other.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HandleCollisionStay(other.gameObject);
        }
    }

    protected virtual void HandleCollisionEnter(GameObject player) {}
    
    protected virtual void HandleCollisionExit(GameObject player) {}
    
    protected virtual void HandleCollisionStay(GameObject player) {}
}
