using CodeBase.UI.Effects;
using UnityEngine;

namespace CodeBase.Gameplay.DestroyableObjects
{
    [RequireComponent(typeof(RecoverDestroyableObjectsOnGarbageDestroyed))]
    [RequireComponent(typeof(EffectCreator))]
    public class EffectOnRecoveredDestroyableObject : MonoBehaviour
    {
        private RecoverDestroyableObjectsOnGarbageDestroyed _recoverDestroyableObjects;
        private EffectCreator _effectCreator;

        private void Awake()
        {
            _recoverDestroyableObjects = GetComponent<RecoverDestroyableObjectsOnGarbageDestroyed>();
            _effectCreator = GetComponent<EffectCreator>();
        }

        private void OnEnable() => 
            _recoverDestroyableObjects.Recovered += SpawnEffect;

        private void OnDisable() => 
            _recoverDestroyableObjects.Recovered -= SpawnEffect;

        private void SpawnEffect(DestroyableObject destroyableObject)
        {
            _effectCreator.CreateAndPlay(destroyableObject.transform, Vector3.zero, true);
        }
    }
}