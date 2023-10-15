using UnityEngine;
using UnityEngine.Events;
public class ResponseController : MonoBehaviour
{
   
    [SerializeField] UnityEvent _onDie;
    Color _defaultColor;
    int _dieCount = 0;
    private void Awake()
    {
        _defaultColor = transform.GetChild(0).GetComponent<Renderer>().material.color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name== "Obstacle") 
        {
            _onDie?.Invoke();
            TryGetComponent(out Movement movement);
            movement?.StopMove(); 
            transform.GetChild(0).GetComponent<Renderer>().material.color = Color.black;
            Luna.Unity.LifeCycle.GameEnded();
            _dieCount++;
            Luna.Unity.Analytics.LogEvent("PlayerLost", _dieCount);
        }
    }
    public void ResetColor() => transform.GetChild(0).GetComponent<Renderer>().material.color = _defaultColor;
}
