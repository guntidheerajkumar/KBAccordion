

#import <UIKit/UIKit.h>
#import "KBMacros.h"

@interface KBAccordionSection : NSObject

-(id)initWithTitle:(NSString *)sectionTitle andView:(UIView *)sectionView;
-(id)initWithTitle:(NSString *)sectionTitle andView:(UIView *)sectionView collapse:(BOOL)collapse NS_DESIGNATED_INITIALIZER;

@property (nonatomic) UIView *view;
@property (nonatomic) NSString *title;
@property (nonatomic) BOOL collapse;

@end
