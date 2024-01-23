using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tale_", menuName = "Gameplay/Tale", order = 1)]
public class Tale : ScriptableObject
{
	[System.Serializable] public class AnswerData
	{
		public string Name => Answer;
		public string Answer;
		[Header("Имя следующей истории")]
		public string NextTaleName;
	}
	[System.Serializable]
	public class DialogData
	{
		public AnimateInfo AnimateStartInfo;
		public AnimateInfo AnimateEndInfo;
		public string Name => Dialog;
		public string Owner;
		[TextArea] public string Dialog;
		public AnswerData[] Answers;
	}
	[SerializeField] private Sprite m_Background;
	[SerializeField] private DialogData[] m_Dialog;
	[SerializeField] private string m_NextTaleName;
	public string NextTaleName => m_NextTaleName;
	public Sprite Background => m_Background;
	public DialogData[] Dialog => m_Dialog; 
	
}
