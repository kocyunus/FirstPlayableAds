using UnityEngine;

public class Movement : MonoBehaviour
{
    float _speed;
    bool _isMove = false;
    [SerializeField] float _direction = 1;
    private float _increaseSpeed = 0.01f;
    int _retryCount;
    public void ChangeDirection() => _direction *= -1;
    private void Update()
    {
        if (!_isMove)
            return;

        transform.position += new Vector3(_direction, 0, 0) * Time.deltaTime * _speed;
        _speed += _increaseSpeed;
    }
    public void StopMove()=> _isMove = false;
    public void StartMove() => _isMove = true;
    public void ResetMovement()
    {
        _isMove = false;
        transform.position = Vector3.zero;
        _direction = 1;
        _speed = 1;
        _retryCount++;
        Luna.Unity.Analytics.LogEvent("PlayerPlayRetry", _retryCount);
    }
    public void SetIncreaseSpeed(float val)=> _increaseSpeed = val;
}
