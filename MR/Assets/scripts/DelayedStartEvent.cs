using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DelayedStartEvent : MonoBehaviour
{
    public float delayInSeconds = 1f; // Set the delay in seconds
    public UnityEvent delayedEvent; // Public Unity event

    private void OnEnable()
    {
        // Start the coroutine
        StartCoroutine(DelayedEventCoroutine());
    }

    private IEnumerator DelayedEventCoroutine()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayInSeconds);

        // Trigger the event
        delayedEvent.Invoke();
    }
}