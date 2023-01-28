using PapersPlease.Runtime.Model;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PapersPlease.Runtime.View
{
    public class HitButton : MonoBehaviour
    {
        [Inject] WorkdayPerformance performanceToInjectInto;

        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => performanceToInjectInto.Hits++);
        }
    }
}