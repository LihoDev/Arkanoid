using Bonus;

public class GemBallSize : Gem
{
    public override void Activate()
    {
        _switcher.SwitchBonus<EnlargeBall>();
    }
}
