namespace Code.Gameplay.Features.Statuses.Systems
{
    public interface IStatusApplier
    {
        public GameEntity ApplyStatus(StatusSetup setup, int producedId, int targetId);
    }
}