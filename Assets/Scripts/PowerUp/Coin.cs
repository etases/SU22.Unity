using UnityEngine;

public class Coin : BasePowerUp
{
    protected override void HandleInteract(GameObject _)
    {
        var coin = PlayerPrefs.GetInt("coins", 0);
        coin++;
        PlayerPrefs.SetInt("coins", coin);
    }
}
