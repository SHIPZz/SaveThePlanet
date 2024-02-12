using CodeBase.Enums;
using CodeBase.Services.TriggerObserve;
using UnityEngine;

namespace CodeBase.Gameplay.Garbages
{
    public class Bin : MonoBehaviour
    {
        public TriggerObserver GarbageObserver;
        public GarbageType GarbageType;
        public Transform GarbagePosition;
    }
}