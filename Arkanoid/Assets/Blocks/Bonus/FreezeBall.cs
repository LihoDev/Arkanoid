namespace Bonus
{
    public class FreezeBall : BonusAction
    {
        private float _speed;
        private Ball _ball;
        private float _oldSpeed;

        public FreezeBall(float speed, Ball ball)
        {
            _speed = speed;
            _ball = ball;
        }

        public override void Activate()
        {
            _oldSpeed = _ball.Speed;
            _ball.Speed = _speed;
        }

        public override void Deactivate()
        {
            _ball.Speed = _oldSpeed;
        }
    }
}