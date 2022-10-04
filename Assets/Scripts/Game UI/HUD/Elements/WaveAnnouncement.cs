using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using Developed.ScriptableObjects.Variables;

namespace UIElements
{
    public class WaveAnnouncement : MonoBehaviour
    {
        [SerializeField] private Canvas announcementCanvas;

        [SerializeField] private TextMeshProUGUI waveCount;
        [SerializeField] private IntVariable currentWave;

        [SerializeField] private float showTime = 1.5f;


        void Awake()
        {
            currentWave.ValueChanged += UpdateWaveCount;
        }

        void OnDestroy()
        {
            currentWave.ValueChanged -= UpdateWaveCount;
        }



        private void UpdateWaveCount(int newValue)
        {
            if (newValue <= 0)
                return;

            var waveString = String.Join(" ", "Wave", newValue.ToString());
            waveCount.SetText(waveString);

            StopAllCoroutines();
            StartCoroutine(WaitAndHide());
        }


        private IEnumerator WaitAndHide()
        {
            announcementCanvas.enabled = true;

            yield return new WaitForSeconds(showTime);

            announcementCanvas.enabled = false;
        }
    }
}