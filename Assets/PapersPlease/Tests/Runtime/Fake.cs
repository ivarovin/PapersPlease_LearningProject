using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace PapersPlease.Tests.Runtime
{
    public static class Fake
    {
        public static void Toggle(string name) => GameObject.Find(name).GetComponentsInChildren<Toggle>().Single().Invert();
        
        static void Invert(this Toggle toggle) => toggle.isOn = !toggle.isOn;
    }
}