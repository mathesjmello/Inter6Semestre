using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAdvance : MonoBehaviour
{

    public QuestLog quest;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            quest.ProximaQuest();
        }
    }
}
