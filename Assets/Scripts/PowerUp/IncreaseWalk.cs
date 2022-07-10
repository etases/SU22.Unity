using UnityEngine;

public class IncreaseWalk : BasePowerUp
{
    public float walkIncrease = 0.5f;

    protected override void HandleInteract(GameObject collidedGameObject)
    {
        var jumper = collidedGameObject.GetComponent<Jumper>();
        jumper.walkSpeed += walkIncrease;
    }
}