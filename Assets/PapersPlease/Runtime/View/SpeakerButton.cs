using System.Threading.Tasks;
using PapersPlease.Runtime.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace PapersPlease.Runtime.View
{
    public class SpeakerButton : MonoBehaviour, Speaker
    {
        TaskCompletionSource<bool> promise;
        
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(Call); 
        }

        void Call()
        {
            promise?.SetResult(true);
        }

        public async Task Listen()
        {
            promise = new TaskCompletionSource<bool>();
            await promise.Task;
            promise = null;
        }
    }
}