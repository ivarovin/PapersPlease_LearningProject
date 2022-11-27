using System;
using PapersPlease.Runtime.Controller;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PapersPlease.Runtime.View
{
    [RequireComponent(typeof(Button))]
    public class ForwardingInput : MonoBehaviour
    {
        [Inject] TimePassage timeController;
        
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                timeController.Inject(TimeSpan.FromHours(1));
            });
        }
    }
}