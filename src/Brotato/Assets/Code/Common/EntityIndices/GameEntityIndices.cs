using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Indexing;
using Entitas;
using Zenject;

namespace Code.Common.EntityIndices
{
    public class GameEntityIndices : IInitializable
    {
        private readonly GameContext _gameContext;

        public const string StatusesOfType = "StatusesOfType";
        
        public GameEntityIndices(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        
        public void Initialize()
        {
            _gameContext.AddEntityIndex(new EntityIndex<GameEntity, StatusKey>(
                name: StatusesOfType,
                _gameContext.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.StatusTypeId,
                        GameMatcher.Status,
                        GameMatcher.Duration,
                        GameMatcher.TimeLeft,
                        GameMatcher.TargetId)),
                getKey: GetTargetStatusKey, 
                new StatusKeyEqualityComparer()));
        }

        private StatusKey GetTargetStatusKey(GameEntity entity, IComponent component)
        {
            return new StatusKey(
                (component as TargetId)?.Value ?? entity.TargetId,
                (component as StatusTypeIdComponent)?.Value ?? entity.StatusTypeId); 
        }
    }
}