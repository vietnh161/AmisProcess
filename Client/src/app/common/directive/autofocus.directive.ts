import { AfterContentInit, Directive, ElementRef, Input, NgModule } from '@angular/core';

@Directive({
    selector: '[appAutoFocus]'
})
export class AutofocusDirective implements AfterContentInit {

    @Input() public appAutoFocus: boolean;

    public constructor(private el: ElementRef) {

    }

    public ngAfterContentInit() {

        setTimeout(() => {

            this.el.nativeElement.focus();
         //   console.log(this.el);
            
        }, 100);

    }

}

@NgModule({
    declarations: [ AutofocusDirective ],
    exports: [ AutofocusDirective ]
  })
  
export class AutofocusDirectiveModule {}