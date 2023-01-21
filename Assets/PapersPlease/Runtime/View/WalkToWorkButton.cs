using System.Threading.Tasks;
using PapersPlease.Runtime.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace PapersPlease.Runtime.View
{
    public class WalkToWorkButton : MonoBehaviour, WalkToWork
    {
        public async Task Listen()
        {
            var tcs = new TaskCompletionSource<bool>();
            GetComponent<Button>().onClick.AddListener(() => tcs.TrySetResult(true));
            await tcs.Task;
        }
    }
}