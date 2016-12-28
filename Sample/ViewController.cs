using System;
using KBAccordion;
using UIKit;
using CoreGraphics;
using Foundation;

namespace Sample
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var accordionStyle = new KBAccordionSectionStyle();
			accordionStyle.ArrowColor = UIColor.Black;
			accordionStyle.HeaderStyle = KBAccordionHeaderStyle.Left;
			accordionStyle.HeaderTitleLabelFont = UIFont.SystemFontOfSize(14f);
			accordionStyle.BackgroundColor = UIColor.White;
			accordionStyle.HeaderBackgroundColor = UIColor.FromRGB(238,238,238);
			accordionStyle.HeaderTitleLabelTextColor = UIColor.Black;
			accordionStyle.DividerColor = UIColor.FromRGB(38, 166, 154);
			accordionStyle.HeaderHeight = 40f;
			accordionStyle.StickyHeaders = true;
			accordionStyle.AnimationDuration = 0.3f;
			accordionStyle.ArrowHeight = 1f;

			var sections = new NSObject[] { new KBAccordionSection("Summary", new UIView(new CGRect(0,0,0,300))),
										    new KBAccordionSection("Qualification",new UIView(new CGRect(0,0,0,300))),
										    new KBAccordionSection("Experience",new UIView(new CGRect(0,0,0,300))),
										    new KBAccordionSection("Languages",new UIView(new CGRect(0,0,0,300)))
										  };

			var accordionView = new KBAccordionView(sections, accordionStyle);
			accordionView.FlashScrollIndicators();
			accordionView.KeyboardDismissMode = UIScrollViewKeyboardDismissMode.OnDrag;
			accordionView.Frame = new CGRect(10, 0, this.View.Frame.Width - 20, accordionView.Frame.Height);
			this.View = accordionView;
			accordionView.BackgroundColor = UIColor.FromRGB(38, 166,154);
		}
	}
}
