namespace Code.Gameplay.Features.Effects.Factory
{
    public interface IEffectsFactory
    {
        GameEntity CreateEffect(EffectSetup effectSetup, int producerId, int targetId);
    }
}