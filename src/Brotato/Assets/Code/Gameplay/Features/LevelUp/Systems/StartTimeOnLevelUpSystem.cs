using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public class StartTimeOnLevelUpSystem : ReactiveSystem<GameEntity>
    {
        private readonly ITimeService _timeService;

        public StartTimeOnLevelUpSystem(GameContext gameContext, ITimeService timeService) : base(gameContext)
        {
            _timeService = timeService;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) => 
            context.CreateCollector(GameMatcher.Processed.Added());

        protected override bool Filter(GameEntity entity) => 
            entity.isLevelUp && entity.isProcessed;

        protected override void Execute(List<GameEntity> levelUps)
        {
            foreach (GameEntity _ in levelUps)
            {
                _timeService.StartTime();
            }
        }
    }
}