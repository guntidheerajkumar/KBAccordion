

#import "KBAccordionSectionView.h"
#import "KBAccordionSectionStyle.h"
#import "KBArrowIcon.h"


#define BOUNDS_KEY_PATH NSStringFromSelector(@selector(bounds))
#define MARGIN 8

@implementation KBAccordionSectionView {
    KBAccordionSectionStyle *_sectionStyle;
    CGFloat _sectionViewAlpha;
    KBArrowIcon *_arrowIcon;
}

-(instancetype)initWithTitle:(NSString *)sectionTitle
                     andView:(UIView *)sectionView
                sectionStyle:(KBAccordionSectionStyle *)sectionStyle {
    return [self initWithTitle:sectionTitle andView:sectionView sectionStyle:sectionStyle collapse:YES];
}

-(instancetype)initWithTitle:(NSString *)sectionTitle
                     andView:(UIView *)sectionView
                sectionStyle:(KBAccordionSectionStyle *)sectionStyle
                    collapse:(BOOL)collapse{
    self = [super init];
    if (self) {
        _sectionStyle = sectionStyle;
        _sectionView = sectionView;
        self.backgroundColor = _sectionStyle.backgroundColor;
        [self setClipsToBounds:YES];
        
        [self makeHeader:sectionTitle];
        [self addArrowIcon];
        
        [self addSubview: sectionView];
        [sectionView addObserver:self forKeyPath:BOUNDS_KEY_PATH options:0 context:nil];
        
        if (collapse) {
            [self collapseSectionAnimated:NO];
        } else {
            [self expandSectionAnimated:NO];
        }
        
        [self layoutIfNeeded];
        
    }
    return self;
}

- (void)observeValueForKeyPath:(NSString *)keyPath
                      ofObject:(id)object
                        change:(NSDictionary *)change
                       context:(void *)context {
    if ([keyPath isEqualToString:BOUNDS_KEY_PATH] && self.expanded){
        self.height = [self expandedHeight];
    }
    [self setNeedsLayout];
    [self layoutIfNeeded];
}

-(void)makeHeader:(NSString *)sectionTitle {
    _header = [UIButton buttonWithType:UIButtonTypeCustom];
    [_header setTitle:sectionTitle forState:UIControlStateNormal];
    [_header setTitleColor:_sectionStyle.headerTitleLabelTextColor forState:UIControlStateNormal];
    [_header setTitleColor:_sectionStyle.headerTitleLabelHighlightedTextColor forState:UIControlStateHighlighted];
    _header.backgroundColor = _sectionStyle.headerBackgroundColor;
    _header.titleLabel.font = _sectionStyle.headerTitleLabelFont;
    [_header addTarget:self action:@selector(toggleButtonPressed:) forControlEvents:UIControlEventTouchUpInside];
    [self addSubview:_header];
}

-(void)addArrowIcon {
    _arrowIcon = [[KBArrowIcon alloc] initWithFrame:CGRectMake(0, 0, 30, _sectionStyle.arrowHeight)];
    [_arrowIcon setHidden:!_sectionStyle.arrowVisible];
    _arrowIcon.color = _sectionStyle.arrowColor;
    [self.header addSubview:_arrowIcon];
}

-(void)collapseSectionAnimated:(BOOL)animated {
    _expanded = NO;
    self.height = self.collapsedHeight;
    _sectionViewAlpha = 0.0;
    [self sectionViewAlphaChanged:animated];
    [_arrowIcon pointDownAnimated:animated];
}

-(void)expandSectionAnimated:(BOOL)animated {
    _expanded = YES;
    self.height = self.expandedHeight;
    _sectionViewAlpha = 1.0;
    [self sectionViewAlphaChanged:animated];
    [_arrowIcon pointUpAnimated:animated];
}

-(void)sectionViewAlphaChanged:(BOOL)animated {
    if (animated){
        [UIView animateWithDuration:_sectionStyle.animationDuration animations:^{ _sectionView.alpha = _sectionViewAlpha; }];
    } else {
        _sectionView.alpha = _sectionViewAlpha;
    }
}

-(void)toggleButtonPressed:(id)sectionPressed {
    if (_expanded){
        [self collapseSectionAnimated:YES];
    } else {
        [self expandSectionAnimated:YES];
    }
    [self setNeedsLayout];
}

-(CGFloat)headerHeight {
    return _sectionStyle.headerHeight;
}

-(void)layoutSubviews {
    [super layoutSubviews];
    [self layoutHeader];
    [self layoutSection];
}

-(void)layoutHeader {
    _header.frame = CGRectMake(_header.frame.origin.x, _header.frame.origin.y, self.width, self.headerHeight);
    CGSize arrowSize = _arrowIcon.frame.size;
    if (_sectionStyle.headerStyle == KBAccordionHeaderStyleLabelLeft){
        [_header setContentHorizontalAlignment:UIControlContentHorizontalAlignmentLeft];
        [_header setTitleEdgeInsets:UIEdgeInsetsMake(0, MARGIN, 0, 0)];
        _arrowIcon.frame = CGRectMake(self.width - MARGIN - arrowSize.width, self.headerHeight / 2 - arrowSize.height / 2 ,
                                      arrowSize.width, arrowSize.height);
    } else if (_sectionStyle.headerStyle == KBAccordionHeaderStyleLabelRight){
        [_header setContentHorizontalAlignment:UIControlContentHorizontalAlignmentRight];
        [_header setTitleEdgeInsets:UIEdgeInsetsMake(0, 0, 0, MARGIN)];
        _arrowIcon.frame = CGRectMake(MARGIN, self.headerHeight / 2 - arrowSize.height / 2,
                                      arrowSize.width, arrowSize.height);
    } else if (_sectionStyle.headerStyle == KBAccordionHeaderStyleLabelCentered) {
        [_header setContentVerticalAlignment:UIControlContentVerticalAlignmentTop];
        [_header setTitleEdgeInsets:UIEdgeInsetsZero];
        _arrowIcon.frame = CGRectMake(_header.center.x - (_arrowIcon.frame.size.width / 2),
                                      _header.frame.size.height - _arrowIcon.frame.size.height - MARGIN,
                                      _arrowIcon.frame.size.width, _arrowIcon.frame.size.height);
    }
}

-(void)dealloc {
    @try {
        [_sectionView removeObserver:self forKeyPath:BOUNDS_KEY_PATH];
    }
    @catch (NSException * __unused exception) {}
}

-(void)layoutSection {
    CGSize fittingSize = [_sectionView sizeThatFits:_sectionView.bounds.size];
    _sectionView.frame = CGRectMake(0, self.headerHeight, self.width, fittingSize.height);
}

-(CGFloat)expandedHeight {
    CGSize fittingSize = [_sectionView sizeThatFits:_sectionView.bounds.size];
    return fittingSize.height  + self.headerHeight;
}

-(CGFloat)collapsedHeight {
    return self.headerHeight;
}

-(CGFloat)width {
    return self.frame.size.width;
}

@end
