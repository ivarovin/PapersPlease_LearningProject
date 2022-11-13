using System;
using PapersPlease.Runtime.Controller;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PapersPlease.Runtime.View
{
    public class StartDayInput : MonoBehaviour
    {
        [Inject]
        StartDay controller;

        void Start()
        {
            GetComponent<Button>().onClick.AddListener(controller.Execute);
        }
    }
}