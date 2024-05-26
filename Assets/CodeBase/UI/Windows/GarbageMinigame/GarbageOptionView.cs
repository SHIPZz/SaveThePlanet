using System;
using UnityEngine;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class GarbageOptionView : MonoBehaviour
    {
        public GarbageInfoPopupView GarbageInfoPopupView;

        private void OnCollisionEnter2D(Collision2D other)
        {
            print("sdfasdfasdf");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            print("asdasdasdasd");
        }
    }
}