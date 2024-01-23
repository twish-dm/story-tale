using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Part : MonoBehaviour
{
	[SerializeField] private RectTransform m_Content;
	[SerializeField] private Image m_Background;
	[SerializeField] private GameObject m_OwnerRoot;
	[SerializeField] private Text m_OwnerName;
	[SerializeField] private Text m_DialogField;
	[SerializeField] private Button m_PrefabAnswer;
	[SerializeField] private GameObject m_NextDialogButton;
	[SerializeField] private Image m_Splash;
	public Image Splash => m_Splash;
	public Image Background => m_Background;

	private Tale m_Tale;
	private Tale.DialogData m_DialogData;
	private List<Button> m_Answers;
	private Dictionary<Button, UnityAction> m_AnswersMap;
	private TaleTimeline m_TaleTimeline;
	private IEnumerator m_NextCoroutine;
	private int m_DialogIndex = 0;
	private AnimateBase m_AnimateBase;
	private void Awake()
	{
		m_Answers = new List<Button>();
		m_AnswersMap = new Dictionary<Button, UnityAction>();
		m_AnimateBase = new AnimateBase();
	}
	public void Introduce(Tale tale, TaleTimeline timeline)
	{
		m_Tale = tale;
		m_TaleTimeline = timeline;
		m_Background.sprite = m_Tale.Background;
		m_DialogIndex = 0;
		m_NextCoroutine = Next(m_TaleTimeline);
		StartCoroutine(m_NextCoroutine);
	}
	private bool m_DialogComplete;
	public IEnumerator Next(TaleTimeline timeline)
	{
		if (m_Tale == null) throw new Exception($"'m_Tale' is NULL");
		


		if (m_DialogIndex >= m_Tale.Dialog.Length)
		{
			timeline.NextTale(m_Tale.NextTaleName);
			yield break;
		}
		m_DialogComplete = false;

		m_DialogData = m_Tale.Dialog[m_DialogIndex];
		m_DialogIndex++;


		m_OwnerRoot.SetActive(!string.IsNullOrEmpty(m_DialogData.Owner));
		m_OwnerName.text = m_DialogData.Owner;
		m_DialogField.text = m_DialogData.Dialog;
		if (m_Answers == null)
			m_Answers = new List<Button>();
		for (int i=0; i< m_Answers.Count; i++)
			Destroy(m_Answers[i].gameObject);
		m_Answers.Clear();
		m_AnswersMap.Clear();
		Button answer = null;
		string taleActionDo = null;
		for (int i = 0; i < m_DialogData.Answers.Length; i++)
		{
			answer = Instantiate(m_PrefabAnswer, m_Content);
			answer.GetComponentInChildren<Text>().text = m_DialogData.Answers[i].Answer;
			string taleAction = m_DialogData.Answers[i].NextTaleName;
			m_AnswersMap[answer] = () =>
			{
				m_DialogComplete = true;

				taleActionDo = taleAction;


			};
			answer.onClick.AddListener(m_AnswersMap[answer]);
			m_Answers.Add(answer);
		}

		m_NextDialogButton.SetActive(m_Answers.Count == 0);

		Debug.Log("START ANIMATION");
		m_AnimateBase.DoAnimate(this, m_DialogData.AnimateStartInfo);
		yield return new WaitWhile(() => !m_AnimateBase.IsComplete);
		Debug.Log("WAIT");
		yield return new WaitWhile(() => !m_DialogComplete);
		Debug.Log("END ANIMATION");
		m_AnimateBase.DoAnimate(this, m_DialogData.AnimateEndInfo);
		yield return new WaitWhile(() => !m_AnimateBase.IsComplete);
		
		if (string.IsNullOrEmpty(taleActionDo))
		{

			m_NextCoroutine = Next(m_TaleTimeline);
			StartCoroutine(m_NextCoroutine);
			yield break;
		}
		else
		{
			timeline.NextTale(taleActionDo);
			yield break;
		}
	}

	public void NextDialog()
	{

		m_DialogComplete = true;
	}
}
