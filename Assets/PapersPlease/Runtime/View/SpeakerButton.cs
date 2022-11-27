using System.Threading.Tasks;
using DG.Tweening;
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
            GetComponent<Button>().onClick.AddListener(() => promise?.SetResult(true)); 
        }

        public async Task Listen()
        {
            promise = new TaskCompletionSource<bool>();
            await promise.Task;
            promise = null;
        }

        public async Task ShowCall()
        {
            await transform.DOPunchScale(Vector3.one * .1f, .25f, 3, .1f).AsyncWaitForCompletion();
        }
    }
}