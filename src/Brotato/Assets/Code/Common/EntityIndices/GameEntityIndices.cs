using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.CharacterStats.Indexing;
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
        public const string StatChanges = "StatChanges";
        
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
            
            _gameContext.AddEntityIndex(new EntityIndex<GameEntity, StatKey>(
                name: StatChanges,
                _gameContext.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.StatChange,
                        GameMatcher.TargetId)),
                getKey: GetTargetStatKey, 
                new StatKeyEqualityComparer()));
        }

        private StatKey GetTargetStatKey(GameEntity entity, IComponent component)
        {
            return new StatKey(
                (component as TargetId)?.Value ?? entity.TargetId,
                (component as StatChange)?.Value ?? entity.StatChange);
        }

        private StatusKey GetTargetStatusKey(GameEntity entity, IComponent component)
        {
            return new StatusKey(
                (component as TargetId)?.Value ?? entity.TargetId,
                (component as StatusTypeIdComponent)?.Value ?? entity.StatusTypeId); 
        }
    }
}