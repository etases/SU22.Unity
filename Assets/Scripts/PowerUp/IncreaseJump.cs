using UnityEngine;

public class IncreaseJump : BasePowerUp
{
    public float jumpIncrease = 1f;
    
    protected override void HandleInteract(GameObject collidedGameObject)
    {
        var jumper = collidedGameObject.GetComponent<Jumper>();
        jumper.jumpSpeed += jumpIncrease;
    }
}
