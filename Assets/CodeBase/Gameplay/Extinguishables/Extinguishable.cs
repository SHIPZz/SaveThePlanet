using System;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Extinguishables
{
    public class Extinguishable : MonoBehaviour
    {
        public float Time = 3f;
        
        public event Action<Vector3, Vector3> PutOut;
        public event Action Finished;
        
        public void SetPutOut(Vector3 target, Vector3 rotation)
        {
            PutOut?.Invoke(target, rotation);
            DOTween.Sequence().AppendInterval(Time).OnComplete(() => Finished?.Invoke());
        }
    }
}