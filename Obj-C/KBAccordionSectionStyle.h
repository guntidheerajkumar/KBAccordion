
#import <UIKit/UIKit.h>

typedef enum KBAccordionHeaderStyle : NSUInteger {
    KBAccordionHeaderStyleLabelRight,
    KBAccordionHeaderStyleLabelCentered,
    KBAccordionHeaderStyleLabelLeft
} KBAccordionHeaderStyle;

@interface KBAccordionSectionStyle : NSObject

/// Defaults to 30
@property (nonatomic) CGFloat headerHeight;
/// Defaults to [UIFont systemFontOfSize:14]
@property (nonatomic) UIFont  *headerTitleLabelFont;
/// Defaults to [UIColor blackColor]
@property (nonatomic) UIColor *headerTitleLabelTextColor;
/// Defaults to [UIColor darkGrayColor]
@property (nonatomic) UIColor *headerTitleLabelHighlightedTextColor;
/// Defaults to KBAccordionHeaderStyleLabelLeft
@property (nonatomic) KBAccordionHeaderStyle headerStyle;
/// Defaults to [UIColor clearColor]
@property (nonatomic) UIColor *headerBackgroundColor;
/// Defaults to [UIColor clearColor]
@property (nonatomic) UIColor *backgroundColor;
/// Defaults to [UIColor lightGrayColor]
@property (nonatomic) UIColor *dividerColor;
/// Defaults to [self dividerColour]
@property (nonatomic) UIColor *arrowColor;
/// Defaults to 0.5
@property (nonatomic) NSTimeInterval animationDuration;
/// Defaults to 5
@property (nonatomic) CGFloat arrowHeight;
/// Defaults to YES
@property (nonatomic) BOOL arrowVisible;
/// Keep the section headers visible on top while scrolling. Defaults to YES
@property (nonatomic) BOOL stickyHeaders;

@end
