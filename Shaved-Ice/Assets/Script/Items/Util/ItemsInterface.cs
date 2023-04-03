using Unity.VisualScripting;
using UnityEngine;

namespace ItemInterface
{
    public interface IItems
    {
        public void EffectToPlayer();
        public void SetLayer();
    }
    public abstract class Items : MonoBehaviour, IItems
    {
        protected GameObject _player;
        protected PlayerStatus _playerStatus;
        protected StageManager _conditions;
        void Awake()
        {
            _player = GameObject.FindWithTag("Player");
            _playerStatus = _player.GetComponent<PlayerStatus>();
            GameObject conditionManager = GameObject.FindWithTag("StageManager");
            _conditions = conditionManager.GetComponent<StageManager>();
            SetLayer();
        }
        public abstract void EffectToPlayer();
        public void SetLayer()
        {
            gameObject.layer = LayerMask.NameToLayer("Items");
        }
    }
}
