using CodeBase.Animations;
using UnityEngine;

namespace CodeBase.Gameplay.NatureDamageables
{
    [RequireComponent(typeof(TransformScaleAnim))]
    [RequireComponent(typeof(NatureDamageable))]
    public class ScaleOnDamageable : MonoBehaviour
    {
        private NatureDamageable _natureDamageable;
        private TransformScaleAnim _transformScaleAnim;

        private void Awake()
        {
            _natureDamageable = GetComponent<NatureDamageable>();
            _transformScaleAnim = GetComponent<TransformScaleAnim>();
        }

        private void OnEnable()
        {
            _natureDamageable.Recovered += ToScale;
            _natureDamageable.Damaged += UnScale;
        }

        private void OnDisable()
        {
            _natureDamageable.Recovered -= ToScale;
            _natureDamageable.Damaged -= UnScale;
        }

        private void UnScale() => 
            _transformScaleAnim.UnScale();

        private void ToScale() => 
            _transformScaleAnim.ToScale();
    }
}