using UnityEngine;

public abstract class BasePowerUp : MonoBehaviour
{
    [SerializeField] public string id = string.Empty;
    
    private string powerUpName => "PowerUp_" + id;
    
    private void Awake()
    {
        var collected = PlayerPrefs.GetInt(powerUpName, 0);
        if (collected != 1) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionGameObject = collision.gameObject;
        if (!collisionGameObject.CompareTag("Player")) return;
        PlayerPrefs.SetInt(powerUpName, 1);
        HandleInteract(collisionGameObject);
        Destroy(gameObject);
    }

    protected abstract void HandleInteract(GameObject gameObject);
}
