using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;

namespace YK.Input
{
    
    public class Input : MonoBehaviour,IPointerClickHandler
    {
        public UnityEvent OnClick;
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }
    }
}