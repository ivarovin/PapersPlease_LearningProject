using System;
using System.Threading.Tasks;
using DG.Tweening;
using PapersPlease.Runtime.Controller;
using TMPro;
using UnityEngine;
using static DG.Tweening.Ease;

namespace PapersPlease.Runtime.View
{
    public class CanvasNewspaper : MonoBehaviour, Newspaper
    {
        [SerializeField] GameObject background;
        [SerializeField] TextMeshProUGUI date;

        public async Task Open(DateTime dateTime)
        {
            background.SetActive(true);
            gameObject.SetActive(true);
            date.text = $"{dateTime:dd/MM/yyyy}";

            GetComponent<CanvasGroup>().DOFade(1, .2f);
            transform.DOLocalRotate(Vector3.back * 360 * 9, .9f, RotateMode.LocalAxisAdd).SetEase(OutQuad);
            await transform.DOScale(0, .9f).From().SetEase(InQuad).AsyncWaitForCompletion();
        }

        public async Task Close()
        {
            await GetComponent<CanvasGroup>().DOFade(0, .45f).AsyncWaitForCompletion();
            gameObject.SetActive(false);
            background.SetActive(false);
        }
    }
}