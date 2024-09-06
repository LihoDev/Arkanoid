using UnityEngine;
using System.Linq;

namespace Bonus
{
    public class BonusSwitcher : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private float _sizeIncrease = 3f;
        private BonusAction[] bonuses;
        private BonusAction _currentBonus;

        public void SwitchBonus<T>() where T : BonusAction
        {
            var newBonus = bonuses.FirstOrDefault(s => s is T);
            if (newBonus == null)
            {
                Debug.LogError("Bonus not found!");
                return;
            }
            if (_currentBonus != null)
                _currentBonus.Deactivate();
            newBonus.Activate();
            _currentBonus = newBonus;
        }

        private void Start() 
        {
            bonuses = new BonusAction[2] {
                new EnlargeBall(_sizeIncrease, _ball),
                new HeavyBall(_ball)
            };
        }
    }
}