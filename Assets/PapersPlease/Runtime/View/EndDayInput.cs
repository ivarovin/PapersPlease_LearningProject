﻿using PapersPlease.Runtime.Controller;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PapersPlease.Runtime.View
{
    public class EndDayInput : MonoBehaviour
    {
        [Inject]
        EndDay controller;

        void Start()
        {
            GetComponent<Button>().onClick.AddListener(async () => await controller.ExecuteAsync());
        }
    }
}