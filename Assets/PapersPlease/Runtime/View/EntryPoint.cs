using System;
using PapersPlease.Runtime.Controller;
using UnityEngine;
using Zenject;

namespace PapersPlease.Runtime.View
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject] TimePassage time;

        void Update()
        {
            time.InjectTime(TimeSpan.FromSeconds(Time.deltaTime));
        }
    }
}