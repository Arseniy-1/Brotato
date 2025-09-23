using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp
{
    [CreateAssetMenu(fileName = "LevelUpConfig", menuName = "Configs/LevelUpConfig")]
    public class LevelUpConfig : ScriptableObject
    {
        public int MaxLevel;
        public List<float> ExperienceForLevelUp;
    }
}