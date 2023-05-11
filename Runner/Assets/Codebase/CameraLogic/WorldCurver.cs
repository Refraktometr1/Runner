using UnityEngine;

public class WorldCurver : MonoBehaviour
{
	[Range(-0.01f, 0.01f)]
	public float curveVerticalStrength = 0.001f;

    int m_CurveStrengthID;

    private void OnEnable()
    {
        m_CurveStrengthID = Shader.PropertyToID("_CurveStrength");
    }

	void Update()
	{
		Shader.SetGlobalFloat(m_CurveStrengthID, curveVerticalStrength);
	}
}
