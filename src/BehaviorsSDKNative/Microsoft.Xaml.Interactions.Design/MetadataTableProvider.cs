﻿// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System;
using System.ComponentModel;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.PropertyEditing;
using Microsoft.Windows.Design.PropertyEditing.Editors;
using Microsoft.Xaml.Interactions.Core;
using Microsoft.Xaml.Interactions.Design.Properties;
using Microsoft.Xaml.Interactions.Media;

namespace Microsoft.Xaml.Interactivity.Design
{
    internal class MetadataTableProvider : IProvideAttributeTable
    {
        private AttributeTableBuilder attributeTableBuilder;

        public AttributeTable AttributeTable
        {
            get
            {
                if (attributeTableBuilder == null)
                {
                    attributeTableBuilder = new AttributeTableBuilder();
                }

                #region IncrementalUpdateBehavior
                AddAttributes<IncrementalUpdateBehavior>(
                    new DescriptionAttribute(Resources.Description_IncrementalUpdateBehavior)
                );

                AddAttributes<IncrementalUpdateBehavior>(
                    "Phase",
                    new DescriptionAttribute(Resources.Description_IncrementalUpdateBehavior_Phase),
                    new CategoryAttribute(Resources.Category_Common_Properties));
                #endregion

                #region EventTriggerBehavior
                AddAttributes<EventTriggerBehavior>(
                    new DescriptionAttribute(Resources.Description_EventTriggerBehavior)
                    );

                AddAttributes<EventTriggerBehavior>(
                    "EventName",
                    new DescriptionAttribute(Resources.Description_EventTriggerBehavior_EventName),
                    CreateEditorAttribute<EventPickerPropertyValueEditor>(),
                    new CategoryAttribute(Resources.Category_Common_Properties)
                    );

                AddAttributes<EventTriggerBehavior>(
                    "SourceObject",
                    new DescriptionAttribute(Resources.Description_EventTriggerBehavior_SourceObject),
                    CreateEditorAttribute<ElementBindingPickerPropertyValueEditor>(),
                    new CategoryAttribute(Resources.Category_Common_Properties));

                AddAttributes<EventTriggerBehavior>(
                    "Actions",
                    new DescriptionAttribute(Resources.Description_EventTriggerBehavior_Actions));
                #endregion

                #region InvokeCommandAction
                AddAttributes<InvokeCommandAction>(
                    new DescriptionAttribute(Resources.Description_InvokeCommandAction),
                    new DefaultBindingPropertyAttribute("Command"));

                AddAttributes<InvokeCommandAction>(
                    "Command",
                    new CategoryAttribute(Resources.Category_Common_Properties),
                    CreateEditorAttribute<PropertyBindingPickerPropertyValueEditor>(),
                    new DescriptionAttribute(Resources.Description_InvokeCommandAction_Command));

                AddAttributes<InvokeCommandAction>(
                    "CommandParameter",
                    new TypeConverterAttribute(typeof(StringConverter)),
                    new CategoryAttribute(Resources.Category_Common_Properties),
                    new DescriptionAttribute(Resources.Description_InvokeCommandAction_CommandParameter),
                    new EditorBrowsableAttribute(EditorBrowsableState.Advanced));

                AddAttributes<InvokeCommandAction>(
                    "InputConverter",
                    new CategoryAttribute(Resources.Category_Common_Properties),
                    new DescriptionAttribute(Resources.Description_InvokeCommandAction_InputConverter),
                    new EditorBrowsableAttribute(EditorBrowsableState.Advanced));

                AddAttributes<InvokeCommandAction>(
                    "InputConverterParameter",
                    new TypeConverterAttribute(typeof(StringConverter)),
                    new CategoryAttribute(Resources.Category_Common_Properties),
                    new DescriptionAttribute(Resources.Description_InvokeCommandAction_InputConverterParameter),
                    new EditorBrowsableAttribute(EditorBrowsableState.Advanced));

                AddAttributes<InvokeCommandAction>(
                    "InputConverterLanguage",
                    new CategoryAttribute(Resources.Category_Common_Properties),
                    new DescriptionAttribute(Resources.Description_InvokeCommandAction_InputConverterLanguage),
                    new TypeConverterAttribute(typeof(CultureInfoNamesConverter)),
                    new EditorBrowsableAttribute(EditorBrowsableState.Advanced));
                #endregion

                #region ControlStoryboardAction
                AddAttributes<ControlStoryboardAction>(
                    new DescriptionAttribute(Resources.Description_ControlStoryboardAction)
                    );

                AddAttributes<ControlStoryboardAction>(
                    "ControlStoryboardOption",
                    new DescriptionAttribute(Resources.Description_ControlStoryboardAction_ControlStoryboardOption),
                    new CategoryAttribute(Resources.Category_Common_Properties));

                AddAttributes<ControlStoryboardAction>(
                    "Storyboard",
                    new DescriptionAttribute(Resources.Description_ControlStoryboardAction_Storyboard),
                    new CategoryAttribute(Resources.Category_Common_Properties),
                    CreateEditorAttribute<StoryboardPickerPropertyValueEditor>(),
                    new TypeConverterAttribute(typeof(TypeConverter)));
                #endregion

                #region GotoStateAction
                AddAttributes<GoToStateAction>(
                    new DescriptionAttribute(Resources.Description_GoToStateAction)
                    );

                AddAttributes<GoToStateAction>(
                    "StateName",
                    CreateEditorAttribute<StatePickerPropertyValueEditor>(),
                    new DescriptionAttribute(Resources.Description_GoToStateAction_StateName),
                    new CategoryAttribute(Resources.Category_Common_Properties));

                AddAttributes<GoToStateAction>(
                    "UseTransitions",
                    new DescriptionAttribute(Resources.Description_GoToStateAction_UseTransitions),
                    new CategoryAttribute(Resources.Category_Common_Properties));

                AddAttributes<GoToStateAction>(
                    "TargetObject",
                    new CategoryAttribute(Resources.Category_Common_Properties),
                    new DescriptionAttribute(Resources.Description_GoToStateAction_TargetObject),
                    CreateEditorAttribute<ElementBindingPickerPropertyValueEditor>());
                #endregion

                #region NavigateToPageAction
                AddAttributes<NavigateToPageAction>(
                    new DescriptionAttribute(Resources.Description_NavigateToPageAction)
                    );

                AddAttributes<NavigateToPageAction>(
                    "TargetPage",
                    CreateEditorAttribute<PagePickerPropertyValueEditor>(),
                    new DescriptionAttribute(Resources.Description_NavigateToPageAction_TargetPage),
                    new CategoryAttribute(Resources.Category_Common_Properties));

                AddAttributes<NavigateToPageAction>(
                    "Parameter",
                    new DescriptionAttribute(Resources.Description_NavigateToPageAction_Parameter),
                    new CategoryAttribute(Resources.Category_Common_Properties),
                    new TypeConverterAttribute(typeof(StringConverter)));
                #endregion

                #region PlaySoundAction
                AddAttributes<PlaySoundAction>(
                    new DescriptionAttribute(Resources.Description_PlaySoundAction)
                    );

                AddAttributes<PlaySoundAction>(
                    "Source",
                    CreateEditorAttribute<UriPropertyValueEditor>(),
                    new DescriptionAttribute(Resources.Description_PlaySoundAction_Source),
                    new CategoryAttribute(Resources.Category_Common_Properties));

                AddAttributes<PlaySoundAction>(
                    "Volume",
                    new NumberRangesAttribute(0, 0, 1, 1, false),
                    new NumberIncrementsAttribute(0.001, 0.01, 0.1),
                    new DescriptionAttribute(Resources.Description_PlaySoundAction_Volume),
                    new CategoryAttribute(Resources.Category_Common_Properties));
                #endregion

                return attributeTableBuilder.CreateTable();
            }
        }


        private void AddAttribute<T>(Attribute attribute)
        {
            attributeTableBuilder.AddCustomAttributes(typeof(T), attribute);
        }

        private void AddAttributes<T>(params Attribute[] attributes)
        {
            foreach (Attribute attribute in attributes)
            {
                AddAttribute<T>(attribute);
            }
        }

        private void AddAttribute<T>(string propertyName, Attribute attribute)
        {
            attributeTableBuilder.AddCustomAttributes(typeof(T), propertyName, attribute);
        }

        private void AddAttributes<T>(string propertyName, params Attribute[] attributes)
        {
            foreach (Attribute attribute in attributes)
            {
                AddAttribute<T>(propertyName, attribute);
            }
        }

        private static EditorAttribute CreateEditorAttribute<T>() where T : PropertyValueEditor
        {
            return PropertyValueEditor.CreateEditorAttribute(typeof(T));
        }

    }
}