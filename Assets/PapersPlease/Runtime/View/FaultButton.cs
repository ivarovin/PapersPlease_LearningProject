using PapersPlease.Runtime.Model;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PapersPlease.Runtime.View
{
    public class FaultButton : MonoBehaviour
    {
        [Inject] WorkdayPerformance performanceToInjectInto;

        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => performanceToInjectInto.Faults++);
        }
    }
}