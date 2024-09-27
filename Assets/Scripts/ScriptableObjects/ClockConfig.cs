using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Clock config", menuName = "Configs/Clock config", order = 0)]
    public class ClockConfig : ScriptableObject
    {
        [SerializeField] private float _animationDuration;

        public float AnimationDuration => _animationDuration;
    }
}