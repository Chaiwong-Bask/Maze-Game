// (c) Copyright HutongGames, LLC 2010-2014. All rights reserved.

using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;

using HutongGames.PlayMaker;
using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace HutongGames.PlayMakerEditor
{
	
	[CustomActionEditor(typeof(NavMeshFindClosestEdge))]
	public class NavMeshFindClosestEdgeCustomEditor : CustomActionEditor
	{
		
		private PlayMakerNavMeshMaskField _maskField;
		
		
		public override bool OnGUI()
		{
			
			NavMeshRaycast _target = (NavMeshRaycast)target;
			
			bool edited = false;
			
			EditField("sourcePosition");
			
			edited = EditMaskField(_target);
			
			EditField("nearestEdgeFound");
			EditField("nearestEdgeFoundEvent");
			EditField("nearestEdgeNotFoundEvent");
			
			EditField("position");
			EditField("normal");
			EditField("distance");
			EditField("mask");
			EditField("hit");
			
			
			return GUI.changed || edited;
		}
		
		bool EditMaskField(NavMeshRaycast _target)
		{
			bool edited = false;
			
			if (_target.passableMask ==null)
			{
				_target.passableMask =  new FsmInt();
				_target.passableMask.Value = -1;
			}
			
			if (_target.passableMask.UseVariable)
			{
				EditField("passableMask");
				
			}else{
				
				GUILayout.BeginHorizontal();
				
				LayerMask _mask = _target.passableMask.Value;
				
				if (_maskField==null)
				{
					_maskField = new PlayMakerNavMeshMaskField();
				}
				LayerMask _newMask = _maskField.LayerMaskField("Passable Mask",_mask,true);
				
				
				if (_newMask!=_mask)
				{
					edited = true;
					_target.passableMask.Value = _newMask.value;
				}
				
				if (PlayMakerEditor.FsmEditorGUILayout.MiniButtonPadded(PlayMakerEditor.FsmEditorContent.VariableButton))
				{
					_target.passableMask.UseVariable = true;
				}
				GUILayout.EndHorizontal();
			}
			
			return edited;
		}
	}
}