

#import <UIKit/UIKit.h>
#import "KBMacros.h"

@class KBAccordionSectionStyle;

@interface KBAccordionSectionView : UIView

@property (nonatomic, readwrite) CGFloat height;
@property (nonatomic, readonly) UIButton *header;
@property (nonatomic, readonly) UIView *sectionView;
@property (nonatomic, readonly, getter=isExpanded) BOOL expanded;

-(instancetype)initWithTitle:(NSString *)sectionTitle
                     andView:(UIView *)sectionView
                sectionStyle:(KBAccordionSectionStyle *)sectionStyle;

-(instancetype)initWithTitle:(NSString *)sectionTitle
                     andView:(UIView *)sectionView
                sectionStyle:(KBAccordionSectionStyle *)sectionStyle
                    collapse:(BOOL)collapse NS_DESIGNATED_INITIALIZER;

@end
