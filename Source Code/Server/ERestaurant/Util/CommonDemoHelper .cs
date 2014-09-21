using DevExpress.Web.ASPxEditors;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERestaurant.Util
{
    public class CommonDemoHelper
    {
        static Action<TextBoxSettings> textBoxSettingsMethod;
        static Action<DateEditSettings> dateEditSettingsMethod;
        static Action<LabelSettings> labelSettingsMethod;
        static Action<LabelSettings> wideLabelSettingsMethod;
        static Action<SpinEditSettings> spinEditSettingsMethod;
        static Action<MemoSettings> memoSettingsMethod;

        public static Action<TextBoxSettings> TextBoxSettingsMethod
        {
            get
            {
                if (textBoxSettingsMethod == null)
                    textBoxSettingsMethod = CreateTextBoxSettingsMethod();
                return textBoxSettingsMethod;
            }
        }
        public static Action<DateEditSettings> DateEditSettingsMethod
        {
            get
            {
                if (dateEditSettingsMethod == null)
                    dateEditSettingsMethod = CreateDateEditSettingsMethod();
                return dateEditSettingsMethod;
            }
        }
        public static Action<LabelSettings> LabelSettingsMethod
        {
            get
            {
                if (labelSettingsMethod == null)
                    labelSettingsMethod = CreateLabelSettingsMethod();
                return labelSettingsMethod;
            }
        }
        public static Action<LabelSettings> WideLabelSettingsMethod
        {
            get
            {
                if (wideLabelSettingsMethod == null)
                    wideLabelSettingsMethod = CreateWideLabelSettingsMethod();
                return wideLabelSettingsMethod;
            }
        }
        public static Action<SpinEditSettings> SpinEditSettingsMethod
        {
            get
            {
                if (spinEditSettingsMethod == null)
                    spinEditSettingsMethod = CreateSpinEditSettingsMethod();
                return spinEditSettingsMethod;
            }
        }
        public static Action<MemoSettings> MemoSettingsMethod
        {
            get
            {
                if (memoSettingsMethod == null)
                    memoSettingsMethod = CreateMemoSettingsMethod();
                return memoSettingsMethod;
            }
        }

        static Action<TextBoxSettings> CreateTextBoxSettingsMethod()
        {
            return settings =>
            {
                settings.ControlStyle.CssClass = "editor";
                settings.ShowModelErrors = true;
                settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
            };
        }
        static Action<DateEditSettings> CreateDateEditSettingsMethod()
        {
            return settings =>
            {
                settings.ControlStyle.CssClass = "editor";
                settings.ShowModelErrors = true;
                settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
            };
        }
        static Action<LabelSettings> CreateLabelSettingsMethod()
        {
            return settings => { settings.ControlStyle.CssClass = "label"; };
        }
        static Action<LabelSettings> CreateWideLabelSettingsMethod()
        {
            return settings => { settings.ControlStyle.CssClass = "wideLabel"; };
        }
        static Action<SpinEditSettings> CreateSpinEditSettingsMethod()
        {
            return settings =>
            {
                settings.ControlStyle.CssClass = "editor";
                settings.ShowModelErrors = true;
                settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;

                settings.Properties.NumberType = SpinEditNumberType.Float;
                settings.Properties.Increment = 0.1M;
                settings.Properties.LargeIncrement = 1;
                settings.Properties.SpinButtons.ShowLargeIncrementButtons = true;
            };
        }
        static Action<MemoSettings> CreateMemoSettingsMethod()
        {
            return settings =>
            {
                settings.Height = 50;
                settings.ControlStyle.CssClass = "editor";
                settings.ShowModelErrors = true;
                settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
            };
        }
    }
}