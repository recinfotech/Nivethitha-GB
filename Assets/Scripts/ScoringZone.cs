using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;
    //publicEvent Trigger
    //privatEvent Trigger

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        Ball ball = Collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(eventData);
            //this.scoreTrigger.Invoke(eventData);
        }

    }
}
