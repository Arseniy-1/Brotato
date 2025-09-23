using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Windows.Configs
{
  [CreateAssetMenu(fileName = "WindowConfig", menuName = "Configs/WindowConfig")]
  public class WindowsConfig : ScriptableObject
  {
    public List<WindowConfig> WindowConfigs;
  }
}