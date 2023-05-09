using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.AssetManagement
{
  public class AssetProvider : IAssetProvider, ItestProvider
  {
    public GameObject Instantiate(string path, Vector3 at)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab, at, Quaternion.identity);
    }

    public GameObject Instantiate(string path)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab);
    }
    
    public GameObject Instantiate(string path, Vector3 position, Quaternion rotation)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab, position, rotation);
    }

    public void TestDebug()
    {
      Debug.Log("TEEEEEST");
    }
    
  }

  public interface ItestProvider
  {
    public void TestDebug();
  }
}