using UnityEngine;

public abstract class BasePowerUp : MonoBehaviour
{
    [SerializeField] public string id = string.Empty;
    private readonly PowerUpPickupEvent m_PowerUpPickupEvent = new();
    
    private string powerUpName => "PowerUp_" + id;
    
    private void Awake()
    {
        var collected = PlayerPrefs.GetInt(powerUpName, 0);
        if (collected != 1)
        {
            Destroy(gameObject);
        }
        else
        {
            PowerUpManager.AddEvent(m_PowerUpPickupEvent);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionGameObject = collision.gameObject;
        if (!collisionGameObject.CompareTag("Player")) return;
        PlayerPrefs.SetInt(powerUpName, 1);
        HandleInteract(collisionGameObject);
        m_PowerUpPickupEvent.Invoke(this, collisionGameObject);
        Destroy(gameObject);
    }

    protected abstract void HandleInteract(GameObject collidedGameObject);
}
