using System.Threading.Tasks;
using DG.Tweening;
using PapersPlease.Runtime.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace PapersPlease.Runtime.View
{
    public class SpeakerButton : MonoBehaviour, Speaker
    {
        TaskCompletionSource<bool> tcs;
        
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => tcs?.SetResult(true)); 
        }

        public async Task Listen()
        {
            tcs = new TaskCompletionSource<bool>();
            await tcs.Task;
            tcs = null;
        }

        public async Task ShowCall()
        {
            await transform.DOPunchScale(Vector3.one * .1f, .25f, 3, .1f).AsyncWaitForCompletion();
        }
    }
}