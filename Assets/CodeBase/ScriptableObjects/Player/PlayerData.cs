using UnityEngine;

namespace CodeBase.ScriptableObjects.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Gameplay/Data/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [Range(0, 50f)] public float ThrowLeftClickSpeed = 15f;
        [Range(0, 50f)] public float ThrowRightClickSpeed = 7f;
    }
}