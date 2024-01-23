using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBase
{
	private Sequence m_Sequence;
	private AnimateInfo m_To;
	public void DoAnimate(Part part, AnimateInfo to)
	{
		this.part = part;
		m_To = to;
		IsComplete = false;
		IsStart = true;
		
		m_Sequence = DOTween.Sequence();

		Debug.Log(m_To.Alpha +"::"+to.name);
		m_Sequence.Append(this.part.Splash.GetComponent<CanvasGroup>().DOFade(m_To.Alpha, m_To.Duration));
		m_Sequence.Join(this.part.Background.rectTransform.DOPivot(m_To.Pivot, m_To.Duration));
		m_Sequence.Join(this.part.Background.rectTransform.DOScale(m_To.Scale, m_To.Duration));
		m_Sequence.Join(this.part.Splash.DOColor(m_To.Color, to.Duration));
		m_Sequence.OnComplete(CompleteHandler);
		m_Sequence.Play();
	}
	protected void CompleteHandler()
	{
		DOTween.Kill(m_Sequence, true);
		m_Sequence = null;
		
		IsComplete = true;
		IsStart = false;
	}
	protected Part part;

	public bool IsComplete, IsStart;
}
