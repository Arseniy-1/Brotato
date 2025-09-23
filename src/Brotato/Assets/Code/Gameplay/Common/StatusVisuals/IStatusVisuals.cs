namespace Code.Gameplay.Common.StatusVisuals
{
  public interface IStatusVisuals
  {
    void ApplyFreeze();
    void UnapplyFreeze();
    void ApplyPoison();
    void UnapplyPoison();
  }
}