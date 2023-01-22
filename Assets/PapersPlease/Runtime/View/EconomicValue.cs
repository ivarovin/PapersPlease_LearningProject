using TMPro;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    public class EconomicValue : MonoBehaviour
    {
        public void Print(int value)
        {
            transform.Find("Value").GetComponentInChildren<TMP_Text>().text = value.ToString();
        }
    }
}