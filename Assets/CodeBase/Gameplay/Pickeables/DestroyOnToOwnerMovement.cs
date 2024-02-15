using CodeBase.Anims;
using UnityEngine;

namespace CodeBase.Gameplay.Pickeables
{
    public class DestroyOnToOwnerMovement : MonoBehaviour
    {
        private TransformScaleAnim _transformScaleAnim;
        private MoveToOwnerOnPickUp _moveToOwnerOnPickUp;

        private void Awake()
        {
            _moveToOwnerOnPickUp = GetComponent<MoveToOwnerOnPickUp>();
            _transformScaleAnim = GetComponent<TransformScaleAnim>();
        }

        private void OnEnable() => 
            _moveToOwnerOnPickUp.Moved += OnMoved;

        private void OnDisable() => 
            _moveToOwnerOnPickUp.Moved -= OnMoved;

        private void OnMoved() => 
            _transformScaleAnim.UnScale(()=> Destroy(gameObject));
    }
}