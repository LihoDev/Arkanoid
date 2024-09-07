using UnityEngine;

namespace Bonus
{
    public class HeavyBall : BonusAction
    {
        private Ball _ball;

        public HeavyBall(Ball ball)
        {
            _ball = ball;
        }

        public override void Activate()
        {
            _ball.IsReflect = false;
            _ball.Sprite.color = Color.red;
        }

        public override void Deactivate()
        {
            _ball.IsReflect = true;
            _ball.Sprite.color = Color.white;
        }
    }
}