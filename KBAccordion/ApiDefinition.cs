using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace KBAccordion
{
	// @interface KBAccordionSection : NSObject
	[BaseType(typeof(NSObject))]
	interface KBAccordionSection
	{
		// -(id)initWithTitle:(NSString *)sectionTitle andView:(UIView *)sectionView;
		[Export("initWithTitle:andView:")]
		IntPtr Constructor(string sectionTitle, UIView sectionView);

		// -(id)initWithTitle:(NSString *)sectionTitle andView:(UIView *)sectionView collapse:(BOOL)collapse __attribute__((objc_designated_initializer));
		[Export("initWithTitle:andView:collapse:")]
		[DesignatedInitializer]
		IntPtr Constructor(string sectionTitle, UIView sectionView, bool collapse);

		// @property (nonatomic) UIView * view;
		[Export("view", ArgumentSemantic.Assign)]
		UIView View { get; set; }

		// @property (nonatomic) NSString * title;
		[Export("title")]
		string Title { get; set; }

		// @property (nonatomic) BOOL collapse;
		[Export("collapse")]
		bool Collapse { get; set; }
	}

	// @interface KBAccordionSectionStyle : NSObject
	[BaseType(typeof(NSObject))]
	interface KBAccordionSectionStyle
	{
		// @property (nonatomic) CGFloat headerHeight;
		[Export("headerHeight")]
		nfloat HeaderHeight { get; set; }

		// @property (nonatomic) UIFont * headerTitleLabelFont;
		[Export("headerTitleLabelFont", ArgumentSemantic.Assign)]
		UIFont HeaderTitleLabelFont { get; set; }

		// @property (nonatomic) UIColor * headerTitleLabelTextColor;
		[Export("headerTitleLabelTextColor", ArgumentSemantic.Assign)]
		UIColor HeaderTitleLabelTextColor { get; set; }

		// @property (nonatomic) UIColor * headerTitleLabelHighlightedTextColor;
		[Export("headerTitleLabelHighlightedTextColor", ArgumentSemantic.Assign)]
		UIColor HeaderTitleLabelHighlightedTextColor { get; set; }

		// @property (nonatomic) KBAccordionHeaderStyle headerStyle;
		[Export("headerStyle", ArgumentSemantic.Assign)]
		KBAccordionHeaderStyle HeaderStyle { get; set; }

		// @property (nonatomic) UIColor * headerBackgroundColor;
		[Export("headerBackgroundColor", ArgumentSemantic.Assign)]
		UIColor HeaderBackgroundColor { get; set; }

		// @property (nonatomic) UIColor * backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Assign)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic) UIColor * dividerColor;
		[Export("dividerColor", ArgumentSemantic.Assign)]
		UIColor DividerColor { get; set; }

		// @property (nonatomic) UIColor * arrowColor;
		[Export("arrowColor", ArgumentSemantic.Assign)]
		UIColor ArrowColor { get; set; }

		// @property (nonatomic) NSTimeInterval animationDuration;
		[Export("animationDuration")]
		double AnimationDuration { get; set; }

		// @property (nonatomic) CGFloat arrowHeight;
		[Export("arrowHeight")]
		nfloat ArrowHeight { get; set; }

		// @property (nonatomic) BOOL arrowVisible;
		[Export("arrowVisible")]
		bool ArrowVisible { get; set; }

		// @property (nonatomic) BOOL stickyHeaders;
		[Export("stickyHeaders")]
		bool StickyHeaders { get; set; }
	}

	// @interface KBAccordionSectionView : UIView
	[BaseType(typeof(UIView))]
	interface KBAccordionSectionView
	{
		// @property (readwrite, nonatomic) CGFloat height;
		[Export("height")]
		nfloat Height { get; set; }

		// @property (readonly, nonatomic) UIButton * header;
		[Export("header")]
		UIButton Header { get; }

		// @property (readonly, nonatomic) UIView * sectionView;
		[Export("sectionView")]
		UIView SectionView { get; }

		// @property (readonly, getter = isExpanded, nonatomic) BOOL expanded;
		[Export("expanded")]
		bool Expanded { [Bind("isExpanded")] get; }

		// -(instancetype)initWithTitle:(NSString *)sectionTitle andView:(UIView *)sectionView sectionStyle:(KBAccordionSectionStyle *)sectionStyle;
		[Export("initWithTitle:andView:sectionStyle:")]
		IntPtr Constructor(string sectionTitle, UIView sectionView, KBAccordionSectionStyle sectionStyle);

		// -(instancetype)initWithTitle:(NSString *)sectionTitle andView:(UIView *)sectionView sectionStyle:(KBAccordionSectionStyle *)sectionStyle collapse:(BOOL)collapse __attribute__((objc_designated_initializer));
		[Export("initWithTitle:andView:sectionStyle:collapse:")]
		[DesignatedInitializer]
		IntPtr Constructor(string sectionTitle, UIView sectionView, KBAccordionSectionStyle sectionStyle, bool collapse);
	}

	// @interface KBAccordionView : UIScrollView
	[BaseType(typeof(UIScrollView))]
	interface KBAccordionView
	{
		// -(id)initWithSections:(NSArray *)sections andSectionStyle:(KBAccordionSectionStyle *)sectionStyle;
		[Export("initWithSections:andSectionStyle:")]
		IntPtr Constructor(NSObject[] sections, KBAccordionSectionStyle sectionStyle);
	}

	// @interface KBArrowIcon : UIView
	[BaseType(typeof(UIView))]
	interface KBArrowIcon
	{
		// @property (nonatomic) UIColor * color;
		[Export("color", ArgumentSemantic.Assign)]
		UIColor Color { get; set; }

		// -(void)pointDownAnimated:(BOOL)animated;
		[Export("pointDownAnimated:")]
		void PointDownAnimated(bool animated);

		// -(void)pointUpAnimated:(BOOL)animated;
		[Export("pointUpAnimated:")]
		void PointUpAnimated(bool animated);
	}
}
