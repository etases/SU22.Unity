using System;
using UnityEngine;

[Flags]
public enum Direction
{
    None = 0,
    Horizontal = 1,
    Vertical = 2,
    Both = 3
}

public class FollowCamera2D : MonoBehaviour
{
    public Transform target;
    public float dampTime = 0.15f;
    public Direction followType = Direction.Horizontal;

    [Range(0.0f, 1.0f)] public float cameraCenterX = 0.5f;

    [Range(0.0f, 1.0f)] public float cameraCenterY = 0.5f;

    public Direction boundType = Direction.None;
    public float leftBound;
    public float rightBound;
    public float upperBound;
    public float lowerBound;
    public bool hardDeadZone;

    // private
    private new Camera camera;
    private float horzExtent;
    private bool isBoundHorizontal;
    private bool isBoundVertical;
    private bool isFollowHorizontal;
    private bool isFollowVertical;
    private Vector3 tempVec = Vector3.one;
    private Vector3 velocity = Vector3.zero;
    private float vertExtent;

    private void Start()
    {
        camera = GetComponent<Camera>();
        vertExtent = camera.orthographicSize;
        //horzExtent = vertExtent * Screen.width / Screen.height;


        //isFollowHorizontal = (followType & Direction.Horizontal) == Direction.Horizontal;
        isFollowVertical = (followType & Direction.Vertical) == Direction.Vertical;
        //isBoundHorizontal = (boundType & Direction.Horizontal) == Direction.Horizontal;
        isBoundVertical = (boundType & Direction.Vertical) == Direction.Vertical;
        
        tempVec = Vector3.one;
    }

    private void LateUpdate()
    {
        if (!target) return;
        var delta = target.position - camera.ViewportToWorldPoint(new Vector3(cameraCenterX, cameraCenterY, 0));

        if (!isFollowHorizontal) delta.x = 0;
        if (!isFollowVertical) delta.y = 0;
        var destination = transform.position + delta;

        if (!hardDeadZone)
            tempVec = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        else
            tempVec.Set(transform.position.x, transform.position.y, transform.position.z);

        //if (isBoundHorizontal) tempVec.x = Mathf.Clamp(tempVec.x, leftBound + horzExtent, rightBound - horzExtent);

        if (isBoundVertical) tempVec.y = Mathf.Clamp(tempVec.y, lowerBound + vertExtent, upperBound - vertExtent);

        tempVec.z = transform.position.z;
        transform.position = tempVec;
    }
}