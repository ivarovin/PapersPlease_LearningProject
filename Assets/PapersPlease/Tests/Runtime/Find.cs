using TMPro;
using UnityEngine;

namespace PapersPlease.Tests.Runtime
{
    public static class Find
    {
        public static string TextOnChildLabelOf<T>() where T : MonoBehaviour
        {
            return Object.FindObjectOfType<T>().GetComponentInChildren<TMP_Text>().text;
        }
    }
}