using UnityEngine;

namespace Code.Gameplay.Cameras.Provider
{
  public interface ICameraProvider
  {
    UnityEngine.Camera MainCamera { get; }
    float WorldScreenHeight { get; }
    float WorldScreenWidth { get; }
    void SetMainCamera(Camera camera);
  }
}