using System.Collections.Generic;
using System.Linq;
using PapersPlease.Runtime.Model;
using PapersPlease.Runtime.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        public static string EconomicMagnitudeValueOf(Magnitude magnitude)
        {
            return EconomicMagnitudes()
                .Single(m => m.name == magnitude.ToString())
                .transform.Find("Value")
                .GetComponent<TMP_Text>().text;
        }

        public static Toggle ToggleOf(Magnitude magnitude) => GameObject.Find(magnitude.ToString()).GetComponentInChildren<Toggle>();

        public static IEnumerable<EconomicMagnitude> EconomicMagnitudes()
        {
            return Object.FindObjectsOfType<EconomicMagnitude>();
        }
    }
}