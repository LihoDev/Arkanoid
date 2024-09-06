using UnityEngine;

namespace Bonus
{
    public class EnlargeBall : BonusAction
    {
        private float _size;
        private Ball _ball;

        public EnlargeBall (float size, Ball ball)
        {
            _size = size;
            _ball = ball;
        }

        public override void Activate()
        {
            _ball.transform.localScale = Vector3.one * _size;
        }

        public override void Deactivate()
        {
            _ball.transform.localScale = Vector3.one;
        }
    }
}