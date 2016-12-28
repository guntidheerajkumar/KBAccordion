

#import <UIKit/UIKit.h>

@interface KBArrowIcon : UIView

@property (nonatomic) UIColor *color; /// Defaults to [UIColor lightGreyColor]


-(void)pointDownAnimated:(BOOL)animated;
-(void)pointUpAnimated:(BOOL)animated;

@end
