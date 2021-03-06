﻿//----------------------------------------------
// Flip Web Apps: Game Framework
// Copyright © 2016 Flip Web Apps / Mark Hewitt
//
// Please direct any bugs/comments/suggestions to http://www.flipwebapps.com
// 
// The copyright owner grants to the end user a non-exclusive, worldwide, and perpetual license to this Asset
// to integrate only as incorporated and embedded components of electronic games and interactive media and 
// distribute such electronic game and interactive media. End user may modify Assets. End user may otherwise 
// not reproduce, distribute, sublicense, rent, lease or lend the Assets. It is emphasized that the end 
// user shall not be entitled to distribute or transfer in any way (including, without, limitation by way of 
// sublicense) the Assets in any other way than as integrated components of electronic games and interactive media. 

// The above copyright notice and this permission notice must not be removed from any files.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//----------------------------------------------

using UnityEditor;

namespace GameFramework.GameStructure.GameItems.Editor.AbstractClasses
{
    public abstract class ShowPrefabEditor : UnityEditor.Editor
    {
        SerializedProperty _contextProperty;
        SerializedProperty _prefabTypeProperty;
        SerializedProperty _nameProperty;
        SerializedProperty _parentProperty;
        SerializedProperty _worldPositionStaysProperty;

        public void OnEnable()
        {
            _contextProperty = serializedObject.FindProperty("_context");
            _prefabTypeProperty = serializedObject.FindProperty("_prefabType");
            _nameProperty = serializedObject.FindProperty("_name");
            _parentProperty = serializedObject.FindProperty("_parent");
            _worldPositionStaysProperty = serializedObject.FindProperty("_worldPositionStays");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_contextProperty);
            EditorGUILayout.PropertyField(_prefabTypeProperty);
            if (_prefabTypeProperty.enumValueIndex == 0)
                EditorGUILayout.PropertyField(_nameProperty);
            EditorGUILayout.PropertyField(_parentProperty);
            EditorGUILayout.PropertyField(_worldPositionStaysProperty);
#if !BEAUTIFUL_TRANSITIONS
            EditorGUILayout.HelpBox("Enable Beautiful Transitions from the integrations window (Window Menu | Game Framework) to allow for animations between selection changes.", MessageType.Info);

#endif
            serializedObject.ApplyModifiedProperties();
        }
    }
}
