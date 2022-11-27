using System.Threading.Tasks;
using PapersPlease.Runtime.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace PapersPlease.Runtime.View
{
    public class WalkToWorkButton : MonoBehaviour, WalkToWork
    {
        TaskCompletionSource<bool> tcs;

        void Start()
        {
            GetComponent<Button>().onClick.AddListener(Notify);
        }

        void Notify()
        {
            tcs?.SetResult(true);
        }

        public async Task Listen()
        {
            tcs = new TaskCompletionSource<bool>();
            await tcs.Task;
        }
    }
}