using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject FollowTarget;
    public EdgeCollider2D MovementBounds;
    private Vector2 _minBounds, _maxBounds;
    private float _halfWidth, _halfHeight;
    private float _initialZValue;
    private Camera _camera;

    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();
        _minBounds = MovementBounds.bounds.min;
        _maxBounds = MovementBounds.bounds.max;
        _halfHeight = _camera.orthographicSize;
        _halfWidth = _halfHeight * Screen.width / Screen.height;
        _initialZValue = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowTarget.transform != null)
        {
            transform.position = Vector3.Lerp(transform.position, FollowTarget.transform.position, 0.1f) + new Vector3(0, 0, _initialZValue);
        }

        float clampedX = Mathf.Clamp(transform.position.x, _minBounds.x + _halfWidth, _maxBounds.x - _halfWidth);
        //if FollowTarget has a renderer, we raise the camera's upper bound for the height of the FollowTarget
        Renderer followTargetRenderer = FollowTarget.GetComponent<Renderer>();
        float adjustedHalfHeight = followTargetRenderer != null ? _halfHeight - followTargetRenderer.bounds.size.y : _halfHeight;
        float clampedY = Mathf.Clamp(transform.position.y, _minBounds.y + _halfHeight, _maxBounds.y - adjustedHalfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
