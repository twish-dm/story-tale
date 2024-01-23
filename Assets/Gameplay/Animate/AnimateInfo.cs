using UnityEngine;

[CreateAssetMenu(fileName = "AnimateTarget", menuName = "Gameplay/AnimateTarget", order = 1)]
public class AnimateInfo:ScriptableObject
{

	[ SerializeField] private Vector2 m_Pivot;
	[ SerializeField] private float m_Scale;
	[ SerializeField] private Color m_Color;
	[ SerializeField] private float m_Alpha;
	[ SerializeField] private float m_Duration;

	public Vector2 Pivot => m_Pivot;
	public float Scale => m_Scale;
	public Color Color => m_Color;
	public float Alpha => m_Alpha;
	public float Duration=> m_Duration;

}
