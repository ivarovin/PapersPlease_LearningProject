using TMPro;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    public class EconomicMagnitude : MonoBehaviour
    {
        public int Value => int.Parse(transform.Find("Value").GetComponentInChildren<TMP_Text>().text);
        
        public void Print(int value)
        {
            transform.Find("Value").GetComponentInChildren<TMP_Text>().text = value.ToString();
        }
    }
}