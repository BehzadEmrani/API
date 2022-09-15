import { Directive, EventEmitter, HostListener, Output } from '@angular/core';

@Directive({
  selector: '[appHideEye]',
})
export class HideEyeDirective {
  @Output()
  keydown: EventEmitter<any> = new EventEmitter();

  @HostListener('click', ['$event']) myClick(e: any) {
    // console.log(e, 'left');
    alert('left click');
    this.keydown.emit(e.key);
  }

  @HostListener('document:contextmenu', ['$event']) myRightClick(e: any) {
    // console.log(e, 'right');
    alert('Right click');
    this.keydown.emit(e.key);

  }
  constructor() {}
}
