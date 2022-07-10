using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BasePowerUp : MonoBehaviour
{
    [SerializeField] public string id = string.Empty;

    private string powerUpName => "PowerUp_" + id;

    private void Awake()
    {
        var collected = PlayerPrefs.GetInt(powerUpName, 1);
        if (collected != 1)
        {
            Destroy(gameObject);
            return;
        }

        var collider = GetComponent<Collider2D>();
        if (!collider.isTrigger)
            collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionGameObject = collision.gameObject;
        if (!collisionGameObject.CompareTag("Player")) return;
        PlayerPrefs.SetInt(powerUpName, 1);
        HandleInteract(collisionGameObject);
        SimpleEventManager.TriggerEvent("PowerPickup", new Dictionary<string, object>
        {
            {"player", collisionGameObject},
            {"powerUp", this}
        });
        Destroy(gameObject);
    }

    protected abstract void HandleInteract(GameObject collidedGameObject);
}