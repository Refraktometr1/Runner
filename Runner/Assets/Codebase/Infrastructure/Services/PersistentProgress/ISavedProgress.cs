using Codebase.Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
  public interface ISavedProgress : ISavedProgressReader
  {
    void UpdateProgress(PlayerProgress progress);
  }
}