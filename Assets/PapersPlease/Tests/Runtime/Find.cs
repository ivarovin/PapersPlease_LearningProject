using System.Collections.Generic;
using System.Linq;
using PapersPlease.Runtime.View;
using TMPro;
using UnityEngine;

namespace PapersPlease.Tests.Runtime
{
    public static class Find
    {
        public static string TextOnChildLabelOf<T>() where T : MonoBehaviour
        {
            return Object.FindObjectOfType<T>()
                .GetComponentInChildren<TMP_Text>()
                .text;
        }
        
        public static string EconomicMagnitudeValueOf(string name)
        {
            return EconomicMagnitudes()
                .Single(m => m.name == name)
                .transform.Find("Value")
                .GetComponent<TMP_Text>().text;
        }
        
        public static IEnumerable<EconomicMagnitude> EconomicMagnitudes()
        {
            return Object.FindObjectsOfType<EconomicMagnitude>();
        }
    }
}