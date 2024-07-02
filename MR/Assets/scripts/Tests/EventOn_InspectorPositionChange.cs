using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

//[ExecuteAlways]
//[CustomEditor(typeof(MyComponent))]
public class EventOn_InspectorPositionChange : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private Transform trackedTransform;
    [SerializeField] private uint updateEvery = 1;
    [SerializeField] private UnityEvent onPositionChanged = new UnityEvent(); // UnityEvent to be set in the Inspector
    private Vector3 _lastPosition;
    private Vector3 initialPosition;
    private byte updateCount = 0;
    private void OnValidate()
    {
        if (trackedTransform == null) 
            trackedTransform = transform;
        if (updateEvery <= 0 )
            updateEvery = 1;
    }

    private void Update()
    {
        if (updateCount % updateEvery != 0)
            return;

        Vector3 currentPosition = trackedTransform.position + Vector3.zero;
        if (currentPosition != _lastPosition)
        {
            _lastPosition = currentPosition + Vector3.zero;

            onPositionChanged.Invoke();
        }
        updateCount++;
    }

    public void LogPositionChange()
    {
        // Handle position change here
        Debug.Log($"Position changed from {_lastPosition} for {trackedTransform.name}");
    }
#endif
}
