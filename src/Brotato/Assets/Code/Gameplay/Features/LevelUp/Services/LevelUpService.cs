using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;

namespace Code.Gameplay.Features.LevelUp.Services
{
    public class LevelUpService : ILevelUpService
    {
        private readonly IStaticDataService _staticDataService;

        public float CurrentExperience { get; private set; }
        public int CurrentLevel { get; private set; }

        public LevelUpService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public float ExperienceForLevelUp() =>
            _staticDataService.ExperienceForLevel(CurrentLevel + 1);

        public void AddExperience(float amount)
        {
            if (amount <= 0)
                return;

            CurrentExperience += amount;
            UpdateLevel();
        }

        private void UpdateLevel()
        {
            if (CurrentLevel >= _staticDataService.MaxLevel())
                return;

            float experienceForLevelUp = _staticDataService.ExperienceForLevel(CurrentLevel + 1);

            if (CurrentExperience < experienceForLevelUp)
                return;

            CurrentExperience -= experienceForLevelUp;
            CurrentLevel++;

            CreateEntity
                .Empty()
                .With(x => x.isLevelUp = true);
            
            UpdateLevel();
        }
    }
}