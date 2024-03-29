using System;
using UnityEngine;

/// <summary>
/// The end zone the player has to protect. Calls an event when an Undead enters it
/// </summary>
public class EndZone : MonoBehaviour
{
    /// <summary>
    /// When an Undead reached the end zone
    /// </summary>
    public event Action UndeadReachEnd;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Undead"))
        {
            collision.transform.GetComponent<Undead>().Unuse();

            UndeadReachEnd?.Invoke();
        }
    }
}
