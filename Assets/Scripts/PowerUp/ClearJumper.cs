using UnityEngine;

public class ClearJumper : BasePowerUp
{
    protected override void HandleInteract(GameObject collidedGameObject)
    {
        var jumper = collidedGameObject.GetComponent<Jumper>();
        jumper.jumpSpeed = Jumper.dJumpSpeed;
        jumper.walkSpeed = Jumper.dWalkSpeed;
    }
}