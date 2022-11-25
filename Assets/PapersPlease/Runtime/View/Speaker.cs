using PapersPlease.Runtime.Controller;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PapersPlease.Runtime.View
{
    public class Speaker : MonoBehaviour
    {
        [Inject] CallForNextImmigrant controller;
        
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(async () => await controller.Execute()); 
        }
    }
}