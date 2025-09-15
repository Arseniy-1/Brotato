using Entitas;

namespace Code.Gameplay.Features.Armaments
{
    public class FollowProducerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _followers;
        private readonly IGroup<GameEntity> _producers;

        public FollowProducerSystem(GameContext gameContext)
        {
            _followers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.FollowingProducer,
                    GameMatcher.WorldPosition,
                    GameMatcher.ProducerId));

            _producers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity follower in _followers)
            foreach (GameEntity producer in _producers)
            {
                if (follower.ProducerId == producer.Id) 
                    follower.ReplaceWorldPosition(producer.WorldPosition);
            }
        }
    }
}