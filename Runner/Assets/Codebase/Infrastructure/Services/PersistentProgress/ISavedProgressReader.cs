using Codebase.Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
  public interface ISavedProgressReader
  {
    void LoadProgress(PlayerProgress progress);
  }
}