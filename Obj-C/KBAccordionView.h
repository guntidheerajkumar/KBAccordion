

#import <UIKit/UIKit.h>
#import "KBAccordionSection.h"
#import "KBMacros.h"

@class KBAccordionSectionStyle;


@interface KBAccordionView : UIScrollView

-(id)initWithSections:(NSArray *)sections andSectionStyle:(KBAccordionSectionStyle *)sectionStyle;

@end
