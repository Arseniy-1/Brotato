namespace Code.Gameplay.Features.Abilities.Factory
{
    public interface IAbilityFactory
    {
        GameEntity CreatePenetratorBoltAbility(int level);
        GameEntity CreateOrbitalAbility(int level);
        GameEntity CreateRotAuraAbility();
    }
}