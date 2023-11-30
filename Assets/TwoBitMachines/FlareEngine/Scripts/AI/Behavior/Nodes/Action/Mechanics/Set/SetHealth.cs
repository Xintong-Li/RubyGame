#region 
#if UNITY_EDITOR
using TwoBitMachines.Editors;
using UnityEditor;
#endif
#endregion
using UnityEngine;

namespace TwoBitMachines.FlareEngine.AI
{
        [AddComponentMenu("")]
        public class SetHealth : Action
        {
                [SerializeField] public float value;
                [SerializeField] private Health health;

                public override NodeState RunNodeLogic (Root root)
                {
                        if (health == null)
                        {
                                health = gameObject.GetComponent<Health>();
                        }
                        health?.SetValue(value);
                        return NodeState.Success;
                }

                #region ▀▄▀▄▀▄ Custom Inspector ▄▀▄▀▄▀
#if UNITY_EDITOR
#pragma warning disable 0414
                public override bool HasNextState () { return false; }
                public override bool OnInspector (AIBase ai , SerializedObject parent , Color color , bool onEnable)
                {
                        if (parent.Bool("showInfo"))
                        {
                                Labels.InfoBoxTop(45 , "Set the Health value." +
                                            "\n \nReturns Success");
                        }
                        FoldOut.Box(1 , color , yOffset: -2);
                        {
                                parent.Field("Health" , "value");
                        }
                        Layout.VerticalSpacing(3);
                        return true;
                }
#pragma warning restore 0414
#endif
                #endregion
        }
}
