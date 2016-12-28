
#import "KBAccordionSectionStyle.h"


@implementation KBAccordionSectionStyle

-(id)init {
    self = [super init];
    if (self) {
        _headerHeight = 30;
        _headerTitleLabelFont = [UIFont systemFontOfSize:14];
        _headerTitleLabelTextColor = [UIColor blackColor];
        _headerTitleLabelHighlightedTextColor = [UIColor darkGrayColor];
        _headerStyle = KBAccordionHeaderStyleLabelLeft;
        _headerBackgroundColor = [UIColor clearColor];
        _backgroundColor = [UIColor clearColor];
        _dividerColor = [UIColor lightGrayColor];
        _arrowVisible = YES;
        _stickyHeaders = YES;
        _animationDuration = 0.5;
        _arrowHeight = 5;
    }
    return self;
}

-(UIColor *)arrowColor {
    if (_arrowColor){
        return _arrowColor;
    } else {
        return _dividerColor;
    }
}

@end
