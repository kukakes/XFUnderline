using Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFUnderline;
using XFUnderline.iOS;

[assembly: ExportRenderer(typeof(UnderlineLabel), typeof(UnderlineLabelRenderer))]
namespace XFUnderline.iOS
{
    class UnderlineLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                UnderlineLabel lbl = Element as UnderlineLabel;
                if (lbl.HasUnderline)
                    SetUnderline(true);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == UnderlineLabel.HasUnderlineProperty.PropertyName)
            {
                if (lbl.HasUnderline)
                    SetUnderline(true);
                else
                    SetUnderline(false);
            }
        }

        private void SetUnderline(bool underlined)
        {
            try
            {
                var label = (UILabel)Control;
                var text = (NSMutableAttributedString)label.AttributedText;
                var range = new NSRange(0, text.Length);

                if (underlined)
                {
                    NSRange r;
                    text.GetAttribute(UIStringAttributeKey.UnderlineStyle, 0, out r);

                    text.AddAttribute(UIStringAttributeKey.UnderlineStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single), range);
                }
                else
                {
                    NSRange r;
                    text.GetAttribute(UIStringAttributeKey.UnderlineStyle, 0, out r);

                    text.RemoveAttribute(UIStringAttributeKey.UnderlineStyle, range);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot underline Label. Error: ", ex.Message);
            }
        }


        private void SetUnderline1()
        {
            try
            {
                var label = (UILabel)Control;
                var text = (NSMutableAttributedString)label.AttributedText;
                if (text == null)
                    return;

                var range = new NSRange(0, text.Length);

                text.AddAttribute(UIStringAttributeKey.UnderlineStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single), range);

                Control.AttributedText = text;
                SetNeedsDisplay();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot underline Label. Error: " + ex.Message);
            }
        }

        private void RemoveUnderline()
        {
            try
            {
                var label = (UILabel)Control;
                var text = (NSMutableAttributedString)label.AttributedText;
                var range = new NSRange(0, text.Length);

                text.RemoveAttribute(UIStringAttributeKey.UnderlineStyle, range);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot remove underline Label. Error: ", ex.Message);
            }
        }

    }
}
