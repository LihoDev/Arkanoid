using Bonus;

public class GemFreezeBall : Gem
{
    public override void Activate()
    {
        _switcher.SwitchBonus<FreezeBall>();
    }
}
