namespace Code.Infrastructure.View
{
    public interface IEntityViewFactory
    {
        EntityBehaviour CreateViewForEntity(GameEntity entity);
        EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity);
    }
}