using Bonus;

public class GemHeavyBall : Gem
{
    public override void Activate()
    {
        _switcher.SwitchBonus<HeavyBall>();
    }
}
